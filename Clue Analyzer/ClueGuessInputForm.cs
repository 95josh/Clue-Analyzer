using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Clue_Analyzer
{
    public partial class ClueGuessInputForm : Form
    {
        public enum FormMode
        {
            Add,
            Edit
        }
        
        private List<RadioButton> radioButtonOptions = new List<RadioButton>();
        private List<LinkLabel> infoLinks = new List<LinkLabel>();
        //variables to hold values before creating a guess
        private SuspectCard? SuspectCard;
        private WeaponCard? WeaponCard;
        private RoomCard? RoomCard;
        private int Guesser = -1;
        private int Responder = -1;
        private ClueCard? ShownCard;
        private int shownCardCategory = -1;
        private FormMode Mode = FormMode.Add;

        /* List of ReturnTo numbers and their values
         * -1 - not yet set
         * 0 - Suspect
         * 1 - Weapon
         * 2 - Room
         * 3 - GuessingPlayer
         * 4 - RespondingPlayer
         * */

        private int returnTo = -1; //the value to set after a radio button is clicked.

        public ClueGuessInputForm()
        {
            InitializeComponent();
            //set up the radioButtonOptions array
            radioButtonOptions = new List<RadioButton> { rbOption1, rbOption2, rbOption3, rbOption4,
                rbOption5, rbOption6, rbOption7, rbOption8, rbOption9 };
            infoLinks = new List<LinkLabel> { lnkLSuspect, lnkLWeapon, lnkLRoom, lnkLGuesser, lnkLResponder, lnkLShownCard };
        }

        public ClueGuessInputForm(FormMode mode, ClueGuess guess)
        {
            InitializeComponent();
            if (mode == FormMode.Edit)
            {
                Mode = mode;
                SuspectCard = guess.Suspect;
                WeaponCard = guess.Weapon;
                RoomCard = guess.Room;
                Guesser = guess.Guesser;
                Responder = guess.Responder;

            }
            //set up the radioButtonOptions array
            radioButtonOptions = new List<RadioButton> { rbOption1, rbOption2, rbOption3, rbOption4,
                rbOption5, rbOption6, rbOption7, rbOption8, rbOption9 };
            infoLinks = new List<LinkLabel> { lnkLSuspect, lnkLWeapon, lnkLRoom, lnkLGuesser, lnkLResponder, lnkLShownCard };
        }

        private void lnkLSuspect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int rbButtonIdx = -1;
            if (SuspectCard != null)
            {
                rbButtonIdx = SuspectCard.CardNameIdx;
            }
            DisplayChoicePicker(ClueCard.Suspects, "Choose the suspect", 0, rbButtonIdx);
        }

        private void DisplayChoicePicker(List<string> items, string prompt, int returnTo, int checkedBox = -1)
        {
            pnlPick.Dock = DockStyle.Fill;

            string selectedCheckbox = "";
            //set the selected checkbox's name, if need-be, and if checkedBox is a valid range.
            if (checkedBox != -1 && (checkedBox <= radioButtonOptions.Count - 1))
            {
                selectedCheckbox = radioButtonOptions[checkedBox].Name;
            }

            //reset all of the radio buttons(hide, enable, etc)
            foreach (RadioButton radioButton in radioButtonOptions)
            {
                radioButton.Visible = false;
                radioButton.Enabled = true;
                radioButton.Checked = false;
                if (radioButton.Name == selectedCheckbox)
                {
                    radioButton.Checked = true;
                }
            }

            //loop through all the items, make the appropriate radio button visible, and change its text
            for (int i = 0; i < items.Count; i++)
            {
                radioButtonOptions[i].Text = items[i];
                radioButtonOptions[i].Visible = true;
            }

            //update the prompt on the panel
            lblPrompt.Text = prompt;

            //set returnTo
            this.returnTo = returnTo;

            //show the panel
            pnlPick.Visible = true;
        }

        private void OptionSelected(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            LinkLabel returnLinkLabel = infoLinks[returnTo];

            int selectedIndex = int.Parse(rb.Name.Replace("rbOption", "")) - 1;
            returnLinkLabel.Text = rb.Text;

            switch (returnTo)
            {
                case 0: //return to the guess suspect
                    SuspectCard = new SuspectCard(rb.Text);
                    break;
                case 1: //return to the guess weapon
                    WeaponCard = new WeaponCard(rb.Text);
                    break;
                case 2: //return to the guess room
                    RoomCard = new RoomCard(rb.Text);
                    break;
                case 3: //return to the guess guesser player
                    //var players = from pl in Form1.Players where pl.Name == rb.Text select pl;
                    //List<CluePlayer> players2 = players.ToList();
                    Guesser = selectedIndex;
                    //if this is the first player in the list, and someone other than no-one responded,
                    //then the card that was shown is known.
                    if (selectedIndex == 0 && Responder != -1)
                    {
                        pnlShownCard.Visible = true;
                    }
                    //if the responder is the program user
                    else if (Responder == 0)
                    {
                        pnlShownCard.Visible = true;
                    }
                    else //no reason to show the ShowedCard panel
                    {
                        pnlShownCard.Visible = false;
                    }
                    break;
                case 4: //return to the guess responder player
                    //If the first element, then Responder should be null
                    if (selectedIndex == 0)
                    {
                        Responder = -1;
                        ShownCard = null;
                        shownCardCategory = -1;
                    }
                    else
                    {
                        Responder = selectedIndex - 1;
                    }

                    //if this is the first player in the list (there was a "no-one" added so it isn't 0),
                    //then the card that was shown is known.
                    if (selectedIndex == 1)
                    {
                        pnlShownCard.Visible = true;
                    }
                    //if the program user is the guesser, and the reponder is not null, then show the ShowedCard panel
                    else if (Guesser == 0 && Responder != -1)
                    {
                        pnlShownCard.Visible = true;
                    }
                    else //no reason to show the ShowedCard panel
                    {
                        pnlShownCard.Visible = false;
                    }
                    break;
                default: //do nothing, who knows what that idx was supposed to do
                    break;
            }

            //hide the panel
            pnlPick.Visible = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlPick.Visible = false;
            pnlPickShownCard.Visible = false;
        }

        private void lnkLWeapon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int rbButtonIdx = -1;
            if (WeaponCard != null)
            {
                rbButtonIdx = WeaponCard.CardNameIdx;
            }
            DisplayChoicePicker(ClueCard.Weapons, "Choose the weapon", 1, rbButtonIdx);
        }

        private void lnkLRoom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int rbButtonIdx = -1;
            if (RoomCard != null)
            {
                rbButtonIdx = RoomCard.CardNameIdx;
            }
            DisplayChoicePicker(ClueCard.Rooms, "Choose the room", 2, rbButtonIdx);
        }

        private void lnkLGuesser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int rbButtonIdx = -1;
            List<string> playerNames = new List<string>();
            foreach (CluePlayer pl in Form1.Players)
            {
                playerNames.Add(pl.Name);
            }
            if (Guesser != -1)
            {
                rbButtonIdx = Guesser;
            }
            DisplayChoicePicker(playerNames, "Choose the player who made the guess", 3, rbButtonIdx);
        }

        private void lnkLResponder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int rbButtonIdx = -1;
            List<string> playerNames = new List<string>();
            foreach (CluePlayer pl in Form1.Players)
            {
                playerNames.Add(pl.Name);
            }
            playerNames.Insert(0, "N/A");
            if (Responder != -1)
            {
                rbButtonIdx = Responder + 1;
            }
            DisplayChoicePicker(playerNames, "Choose the player who responded to the guess", 4, rbButtonIdx);
            //disable the appropriate rb button if need-be
            if (Guesser != -1)
            {
                radioButtonOptions[Guesser + 1].Enabled = false;
            }
        }

        private void CardCategoryChange(object sender, EventArgs e)
        {
            pnlPickShownCard.Visible = false;
            pnlPick.Visible = false;

            lnkLShownCard.Text = cmbCardCategory.Text;

            shownCardCategory = cmbCardCategory.SelectedIndex;
        }

        private void lnkLShownCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //set up combo box
            if (shownCardCategory != -1)
            {
                cmbCardCategory.SelectedIndex = shownCardCategory;
            }
            else
            {
                cmbCardCategory.SelectedIndex = -1;
            }

            //show form
            pnlPick.Visible = true;
            pnlPickShownCard.Visible = true;
            pnlPick.Dock = DockStyle.Fill;

            lblPrompt.Text = "Use the dropdowns to choose the card that was shown";
        }


        private void btnAddGuess_Click(object sender, EventArgs e)
        {
            if (shownCardCategory != -1)
            {
                if (shownCardCategory == 0)
                {
                    if (SuspectCard != null)
                    {
                        ShownCard = SuspectCard;
                    }
                }
                else if (shownCardCategory == 1)
                {
                    if (WeaponCard != null)
                    {
                        ShownCard = WeaponCard;
                    }
                }
                else if (shownCardCategory == 2)
                {
                    if (RoomCard != null)
                    {
                        ShownCard = RoomCard;
                    }
                }
            }
            if (Guesser == Responder && Guesser != -1 && Responder != -1)
            {
                MessageBox.Show("The guessing player and responding player cannot be the same player. \r\nTry instead setting Responder to \"N/A\".", "Invalid Input");
                return;
            }
            //make sure the user isn't saying he/she has something he/she doesn't
            if (Responder == 0 && ShownCard != null && !(Form1.Players[0].GetCardStatus(ShownCard) == PlayerClueCard.StatusValues.Yes))
            {
                string msg = "You do not have ";
                if (ShownCard.CardTypeIdx == 0)
                {
                    msg += ShownCard.CardName + ".";
                }
                else msg += "the " + ShownCard.CardName + ".";
                msg += "\r\nPlease select a different shown card.";
                MessageBox.Show(msg, "Incorrect Selection");
                return;
            }
            //make sure the user isn't saying that the responder has something he/she obviously doesn't (only when adding a guess, otherwise it is ok to say someone has something they don't have)
            else if (Guesser == 0 && ShownCard != null && Form1.Players[Responder].GetCardStatus(ShownCard) == PlayerClueCard.StatusValues.No && Mode == FormMode.Add)
            {
                string msg = Form1.Players[Responder].Name + " does not have ";
                if (ShownCard.CardTypeIdx == 0)
                {
                    msg += ShownCard.CardName + ".";
                }
                else msg += "the " + ShownCard.CardName + ".";
                msg += "\r\nPlease select a different shown card.";
                MessageBox.Show(msg, "Incorrect Selection");
                return;
            }

            ClueGuess thisGuess;
            if (SuspectCard != null && WeaponCard != null && RoomCard != null)
            {
                thisGuess = new ClueGuess(SuspectCard, WeaponCard, RoomCard, Guesser, Responder, ShownCard);

                //if the guess is valid, transfer to Form1
                if (thisGuess.IsValid())
                {
                    Form1.transfer = thisGuess;
                    Close();
                }
                else
                {
                    MessageBox.Show("The guess information is not completely filled out.", "Information Missing");
                }
            }
            else
            {
                MessageBox.Show("The guess information is not completely filled out.", "Information Missing");
            }

        }

        private void ClueGuessInputForm_Load(object sender, EventArgs e)
        {
            if (Mode == FormMode.Edit)
            {
                Text = "Edit a guess";
                lblHeader.Text = "Edit a guess";
                lblInstructions.Text = "Click each of the links to edit a guess";
                btnAddGuess.Text = "Save";

                lnkLSuspect.Text = SuspectCard.CardName;
                lnkLWeapon.Text = WeaponCard.CardName;
                lnkLRoom.Text = RoomCard.CardName;
                lnkLGuesser.Text = Form1.Players[Guesser].Name;
                lnkLResponder.Text = Responder == -1 ? "N/A" : Form1.Players[Responder].Name;
                if (ShownCard != null && Responder != -1)
                {
                    shownCardCategory = ShownCard.CardTypeIdx;
                    lnkLShownCard.Text = cmbCardCategory.Items[shownCardCategory].ToString();
                    pnlShownCard.Visible = true;
                }
            }
            
        }
    }
}
