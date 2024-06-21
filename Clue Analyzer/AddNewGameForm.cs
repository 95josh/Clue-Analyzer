using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clue_Analyzer
{
    public partial class AddNewGameForm : Form
    {
        private TextBox[] playerNames;
        private NumericUpDown[] playerNumberCards;
        private int playerCount = 3;
        private List<CluePlayer> playerlist = new List<CluePlayer>();
        private string cardSet = "Colonel Mustard,Miss Scarlet,Mr. Green,Mrs. Peacock,Mrs. White,Professor Plum;Candlestick,Knife,Lead Pipe,Revolver,Rope,Wrench;Ballroom,Billiard Room,Conservatory,Dining Room,Hall,Kitchen,Library,Lounge,Study"; //default card set - north american Card Set from 1963 - 2015
        private string cardSetName = "";
        private string fileLocation = "";

        public string transferSet = "";
        public string transferSetName = "";

        public AddNewGameForm()
        {
            InitializeComponent();
            playerNames = [txtPlayer1, txtPlayer2, txtPlayer3, txtPlayer4, txtPlayer5, txtPlayer6];
            playerNumberCards = [numPlayer1, numPlayer2, numPlayer3, numPlayer4, numPlayer5, numPlayer6];
        }

        private void PlayerNumChanged(object sender, EventArgs e)
        {
            NumericUpDown nu = (NumericUpDown)sender;

            if ((int)nu.Value > 6)
            {
                nu.Value = 6;
                MessageBox.Show("Maximum number of players is 6.", "Invalid Input");
            }
            else if ((int)nu.Value < 3)
            {
                nu.Value = 3;
                MessageBox.Show("Minimum number of players is 3.", "Invalid Input");
            }
            else
            {
                //do nothing
            }

            RedisplayPlayers();
        }

        private void btnGoPlayerNumber_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = true;

            //show the panel to enter in the player information
            pnlPlayerInfo.Visible = true;
            RedisplayPlayers();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            //validate to make sure all the player information is filled out and that it is not invalid
            //(name length, and number of cards)

            int totalNumberOfCards = 0; //to keep track of how many cards the user has reported
            for (int i = 0; i < playerCount; i++)
            {
                if (playerNames[i].Text.Length > 15 || playerNames[i].Text.Length < 3)
                {
                    MessageBox.Show("Player number " + (i + 1) + "'s name should be longer than 2 " +
                        "characters and less than 16 characters.", "Invalid Input");
                    return;
                }
                totalNumberOfCards += (int)playerNumberCards[i].Value;
            }

            //if we have too many or too little cards among the players
            if (totalNumberOfCards > 18 || totalNumberOfCards < 18)
            {
                MessageBox.Show("There is an inaccurate total number of cards among the players. \r\n" +
                    "The current total is " + totalNumberOfCards + " but it should be 18.", "Invalid Input");
                return;
            }

            List<CluePlayer> newPlayerList = new List<CluePlayer>();
            for (int i = 0; i < playerCount; i++)
            {
                CluePlayer cp = new CluePlayer(playerNames[i].Text, (int)playerNumberCards[i].Value);
                newPlayerList.Add(cp);
            }

            playerlist = newPlayerList;

            //load up the ClueCard class with the new details
            GameDetails gd = new GameDetails();
            gd.Cards = cardSet;
            Form1.LoadGameCardNames(gd);

            //populate the checkbox list with card values
            clbPlayerItems.Items.Clear();
            clbPlayerItems.Items.AddRange(ClueCard.Suspects.ToArray());
            clbPlayerItems.Items.AddRange(ClueCard.Weapons.ToArray());
            clbPlayerItems.Items.AddRange(ClueCard.Rooms.ToArray());

            //show the finilization form
            pnlFinalize.Dock = DockStyle.Fill;
            pnlFinalize.Visible = true;
        }

        private void PlayerNumberOfCardsChanged(object sender, EventArgs e)
        {
            NumericUpDown nu = (NumericUpDown)sender;

            if ((int)nu.Value > 6)
            {
                nu.Value = 6;
                MessageBox.Show("Maximum number of cards is 6.", "Invalid Input");
            }
            else if ((int)nu.Value < 3)
            {
                nu.Value = 3;
                MessageBox.Show("Minimum number of cards is 3.", "Invalid Input");
            }
            else
            {
                //do nothing
            }

        }

        //displays the proper number of players info pairs
        //, but does not display the panel that hides them
        private void RedisplayPlayers()
        {
            playerCount = (int)numPlayers.Value;

            //loop through all the player names and number of cards and set their visibility to false
            for (int i = 0; i < playerNames.Length; i++)
            {
                playerNames[i].Visible = false;
                playerNumberCards[i].Visible = false;
            }

            //loop through the number of players we have and set the visibility to true for the
            //player name textboxes and number of cards
            for (int i = 0; i < playerCount; i++)
            {
                playerNames[i].Visible = true;
                playerNumberCards[i].Visible = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlFinalize.Visible = false;
        }

        private async void btnDone_Click(object sender, EventArgs e)
        {
            if (clbPlayerItems.CheckedItems.Count > playerlist[0].CardCount)
            {
                int temp = clbPlayerItems.CheckedItems.Count - playerlist[0].CardCount;
                MessageBox.Show("You have too many cards selected. " +
                    "Deselect " + temp + (temp == 1 ? " card." : " cards."),
                    "Incomplete");
                return;
            }
            else if (clbPlayerItems.CheckedItems.Count < playerlist[0].CardCount)
            {
                int temp = playerlist[0].CardCount - clbPlayerItems.CheckedItems.Count;
                MessageBox.Show("You have too little cards selected. " +
                    "Select " + (temp) + " more " + (temp == 1 ? "card." : "cards."),
                    "Incomplete");
                return;
            }
            else if (fileLocation == "")
            {
                MessageBox.Show("Please choose a file location before continuing.",
                    "Incomplete");
                return;
            }

            btnDone.Enabled = false;
            btnDone.Text = "Loading...";

            //loop through all the cards of the user and set their status to "no"
            //also indicate that this wasn't found out by analysis
            foreach (PlayerSuspectCard c in playerlist[0].Suspects)
            {
                c.Status = PlayerClueCard.StatusValues.No;
                c.StatusByDiscovery = false;
            }
            foreach (PlayerWeaponCard c in playerlist[0].Weapons)
            {
                c.Status = PlayerClueCard.StatusValues.No;
                c.StatusByDiscovery = false;
            }
            foreach (PlayerRoomCard c in playerlist[0].Rooms)
            {
                c.Status = PlayerClueCard.StatusValues.No;
                c.StatusByDiscovery = false;
            }

            //loop through the possible cards to add the right cards to the user,
            //and set them to no on the other players
            foreach (string s in clbPlayerItems.CheckedItems.Cast<string>().ToList())
            {
                if (ClueCard.Suspects.Contains(s))
                {
                    int idx = ClueCard.Suspects.IndexOf(s);
                    playerlist[0].Suspects[idx].Status = PlayerClueCard.StatusValues.Yes;
                    //loop through players (excluding the first one, which is the user)
                    //and set the current card status to no
                    for (int i = 1; i < playerlist.Count; i++)
                    {
                        playerlist[i].Suspects[idx].Status = PlayerClueCard.StatusValues.No;
                        playerlist[i].Suspects[idx].StatusByDiscovery = false;
                    }
                }
                else if (ClueCard.Weapons.Contains(s))
                {
                    int idx = ClueCard.Weapons.IndexOf(s);
                    playerlist[0].Weapons[idx].Status = PlayerClueCard.StatusValues.Yes;
                    //loop through players (excluding the first one, which is the user)
                    //and set the current card status to no
                    for (int i = 1; i < playerlist.Count; i++)
                    {
                        playerlist[i].Weapons[idx].Status = PlayerClueCard.StatusValues.No;
                        playerlist[i].Weapons[idx].StatusByDiscovery = false;
                    }
                }
                else if (ClueCard.Rooms.Contains(s))
                {
                    int idx = ClueCard.Rooms.IndexOf(s);
                    playerlist[0].Rooms[idx].Status = PlayerClueCard.StatusValues.Yes;
                    //loop through players (excluding the first one, which is the user)
                    //and set the current card status to no
                    for (int i = 1; i < playerlist.Count; i++)
                    {
                        playerlist[i].Rooms[idx].Status = PlayerClueCard.StatusValues.No;
                        playerlist[i].Rooms[idx].StatusByDiscovery = false;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid card type");
                }
            }

            SQLiteClueStorageHandler sq = new SQLiteClueStorageHandler(fileLocation);
            GameDetails gd = new GameDetails();
            gd.Cards = cardSet;
            await sq.SaveEverything(new List<ClueGuess>(), playerlist, gd);
            Form1.newGameLoc = fileLocation;
            Close();
        }

        private void btnChooseLocation_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                fileLocation = saveFileDialog1.FileName;
                lblFileLocation.Text = fileLocation;
                lblFileLocation.Visible = true;
            }
        }

        private void NumericFocused(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            num.Select(0, num.Text.Length);
        }

        private void lnkLCardSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetCardSetForm scsf = new SetCardSetForm(this, lnkLCardSet.Text);
            scsf.ShowDialog();

            if (transferSet != "")
            {
                cardSet = transferSet;
                cardSetName = transferSetName;
                transferSet = "";
                transferSetName = "";
                lnkLCardSet.Text = cardSetName;
            }
        }
    }
}
