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
    public partial class ViewPlayerForm : Form
    {
        private int playerIdx;
        private CluePlayer player;
        private List<Label> suspectLabels = new List<Label>();
        private List<PictureBox> suspectPBs = new List<PictureBox>();
        private List<Label> weaponLabels = new List<Label>();
        private List<PictureBox> weaponPBs = new List<PictureBox>();
        private List<Label> roomLabels = new List<Label>();
        private List<PictureBox> roomPBs = new List<PictureBox>();
        private List<ClueGuess> guesses = new List<ClueGuess>();
        private Form1 parent;

        private List<Color> statusColors = [Color.ForestGreen, Color.Red, Color.Gray];
        private string[] toolTipText = [" has this card", " does not have this card", " may or may not have this card"];


        public ViewPlayerForm(int playerIdx, List<CluePlayer> clueplayers, List<ClueGuess> guesses, Form1 form1)
        {
            this.playerIdx = playerIdx;
            player = clueplayers[playerIdx];
            this.guesses = guesses;
            parent = form1;
            InitializeComponent();
        }

        private void ViewPlayerForm_Load(object sender, EventArgs e)
        {
            //load weapon and picturebox lists
            suspectLabels = [lblSuspect1, lblSuspect2, lblSuspect3, lblSuspect4, lblSuspect5, lblSuspect6];
            weaponLabels = [lblWeapon1, lblWeapon2, lblWeapon3, lblWeapon4, lblWeapon5, lblWeapon6];
            roomLabels = [lblRoom1, lblRoom2, lblRoom3, lblRoom4, lblRoom5, lblRoom6, lblRoom7, lblRoom8, lblRoom9];
            suspectPBs = [pbSuspect1, pbSuspect2, pbSuspect3, pbSuspect4, pbSuspect5, pbSuspect6];
            weaponPBs = [pbWeapon1, pbWeapon2, pbWeapon3, pbWeapon4, pbWeapon5, pbWeapon6];
            roomPBs = [pbRoom1, pbRoom2, pbRoom3, pbRoom4, pbRoom5, pbRoom6, pbRoom7, pbRoom8, pbRoom9];

            //load data onto form
            LoadData();
        }

        private void LoadData()
        {
            //set the player name in the title of the page and form text bar
            lblPlayerName.Text = "Player Data for " + player.Name;
            this.Text = "View Player Data for " + player.Name;

            //load information into general stats area
            //load number of gueses made by player
            lblNumberOfGuesses.Text = (from guess in guesses
                                       where guess.Guesser == playerIdx
                                       select guess).Count().ToString();

            //load number of guesses that player was involved in
            lblNumberOfGuessesWithPlayer.Text = (from guess in guesses
                                                 where guess.Guesser == playerIdx || guess.Responder == playerIdx
                                                 select guess).Count().ToString();

            //load number of cards the player has
            lblNumberOfCards.Text = player.CardCount.ToString();

            //load the number of cards known
            int knownCards = (from card in player.Suspects
                              where card.Status == PlayerClueCard.StatusValues.Yes
                              select card).Count();
            knownCards += (from card in player.Weapons
                           where card.Status == PlayerClueCard.StatusValues.Yes
                           select card).Count();
            knownCards += (from card in player.Rooms
                           where card.Status == PlayerClueCard.StatusValues.Yes
                           select card).Count();
            lblNumberCardsKnown.Text = knownCards.ToString();

            LoadCardData();
        }

        private void LoadCardData()
        {
            List<PictureBox>[] pbs = [suspectPBs, weaponPBs, roomPBs];
            List<Label>[] labels = [suspectLabels, weaponLabels, roomLabels];
            List<string>[] cardNames = [ClueCard.Suspects, ClueCard.Weapons, ClueCard.Rooms];

            //loop through each of the card categories
            for (int i = 0; i < pbs.Length; i++)
            {
                //set the current list of items
                List<PictureBox> currentPbs = pbs[i];
                List<Label> currentLabels = labels[i];
                List<string> labelText = cardNames[i];
                //set the card count for the inner loop
                int cardCount;
                if (i == 0) cardCount = player.Suspects.Count;
                else if (i == 1) cardCount = player.Weapons.Count;
                else cardCount = player.Rooms.Count;



                //loop through each of the cards in the categories and update the interface
                for (int j = 0; j < cardCount; j++)
                {
                    //get the current card status (0, 1, 2) ("Yes", "No", "Unknown")
                    int currentCardStatus;
                    if (i == 0) currentCardStatus = player.Suspects[j].StatusIdx;
                    else if (i == 1) currentCardStatus = player.Weapons[j].StatusIdx;
                    else currentCardStatus = player.Rooms[j].StatusIdx;

                    //set the label color, text, and tooltip
                    currentLabels[j].ForeColor = statusColors[currentCardStatus];
                    currentLabels[j].Text = labelText[j];
                    tpCardStatus.SetToolTip(currentLabels[j], player.Name + toolTipText[currentCardStatus]);

                    //set the pictureBox icon, backcolor, and tooltip
                    currentPbs[j].BackColor = statusColors[currentCardStatus];
                    currentPbs[j].Image = imglstStatusIcons.Images[currentCardStatus];
                    tpCardStatus.SetToolTip(currentPbs[j], player.Name + toolTipText[currentCardStatus]);
                }
            }
        }

        //when a datarefresh gets triggered from Form1
        public void DataRefresh(List<CluePlayer> clueplayers, List<ClueGuess> guesses, List<Color> colors)
        {
            player = clueplayers[playerIdx];
            statusColors = colors;
            this.guesses = guesses;
            LoadData();
        }
        
        private void RemoveRefFromParent(object sender, FormClosingEventArgs e)
        {
            //when the form closes, remove reference from parent
            parent.PopViewPlayerForm(this);
        }
    }
}
