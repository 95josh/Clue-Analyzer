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
    public partial class SetCardSetForm : Form
    {
        private string rbTextInput;
        private string currentSetName = "";
        private string currentSet = "";
        private AddNewGameForm returnForm;
        private List<RadioButton> rbs = new List<RadioButton>();
        private List<string> cardSets = [
            "Colonel Mustard,Miss Scarlett,Mr. Green,Mrs. Peacock,Mrs. White,Professor Plum;Candlestick,Knife,Lead Pipe,Revolver,Rope,Wrench;Ballroom,Billiard Room,Conservatory,Dining Room,Hall,Kitchen,Library,Lounge,Study",
            "Colonel Mustard,Miss Scarlet,Mr. Green,Mrs. Peacock,Mrs. White,Professor Plum;Candlestick,Knife,Lead Pipe,Revolver,Rope,Wrench;Ballroom,Billiard Room,Conservatory,Dining Room,Hall,Kitchen,Library,Lounge,Study",
            "Colonel Mustard,Miss Scarlett,Mr. Green,Mrs. Peacock,Dr. Orchid,Professor Plum;Candlestick,Dagger,Lead Pipe,Revolver,Rope,Wrench;Ballroom,Billiard Room,Conservatory,Dining Room,Hall,Kitchen,Library,Lounge,Study",
            "Colonel Mustard,Miss Scarlett,Reverend Green,Mrs. Peacock,Mrs. White,Professor Plum;Candlestick,Dagger,Lead Piping,Revolver,Rope,Spanner;Ballroom,Billiard Room,Conservatory,Dining Room,Hall,Kitchen,Library,Lounge,Study"
            ];

        public SetCardSetForm(AddNewGameForm angf, string rbText = "")
        {
            rbTextInput = rbText;
            returnForm = angf;
            InitializeComponent();
        }

        private void SetCardSetForm_Load(object sender, EventArgs e)
        {
            rbs = [rbEdition1, rbEdition2, rbEdition3, rbEdition4];
            if (rbTextInput != "")
            {
                bool didChecked = false;
                foreach (RadioButton rb in rbs)
                {
                    if (rb.Text == rbTextInput)
                    {
                        rb.Checked = true;
                        didChecked = true;
                        break;
                    }
                }

                if (!didChecked)
                {
                    rbEdition2.Checked = true;
                }
            }
            else
            {
                rbEdition2.Checked = true;
            }

            //set up the card sets

        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            returnForm.transferSet = currentSet;
            returnForm.transferSetName = currentSetName;
            Close();
        }

        private void CardSetChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            int idx = int.Parse(rb.Name.Replace("rbEdition", "")) - 1;
            currentSet = cardSets[idx];
            currentSetName = rb.Text;

        }
    }
}
