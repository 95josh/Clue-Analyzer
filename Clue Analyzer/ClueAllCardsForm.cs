using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clue_Analyzer
{
    public partial class ClueAllCardsForm : Form
    {
        private List<Label> suspectLabels = new List<Label>();
        private List<PictureBox> suspectPBs = new List<PictureBox>();
        private List<Label> weaponLabels = new List<Label>();
        private List<PictureBox> weaponPBs = new List<PictureBox>();
        private List<Label> roomLabels = new List<Label>();
        private List<PictureBox> roomPBs = new List<PictureBox>();
        private List<CluePlayer> players = new List<CluePlayer>();
        private List<Color> statusColors = [Color.ForestGreen, Color.Red, Color.Gray];

        private Form1 parent;

        public ClueAllCardsForm(List<CluePlayer> playersList, List<Color> sc, Form1 p)
        {
            players = playersList;
            statusColors = sc;
            parent = p;
            InitializeComponent();
        }

        private void ClueAllCardsForm_Load(object sender, EventArgs e)
        {
            //load weapon and picturebox lists
            suspectLabels = [lblSuspect1, lblSuspect2, lblSuspect3, lblSuspect4, lblSuspect5, lblSuspect6];
            weaponLabels = [lblWeapon1, lblWeapon2, lblWeapon3, lblWeapon4, lblWeapon5, lblWeapon6];
            roomLabels = [lblRoom1, lblRoom2, lblRoom3, lblRoom4, lblRoom5, lblRoom6, lblRoom7, lblRoom8, lblRoom9];
            suspectPBs = [pbSuspect1, pbSuspect2, pbSuspect3, pbSuspect4, pbSuspect5, pbSuspect6];
            weaponPBs = [pbWeapon1, pbWeapon2, pbWeapon3, pbWeapon4, pbWeapon5, pbWeapon6];
            roomPBs = [pbRoom1, pbRoom2, pbRoom3, pbRoom4, pbRoom5, pbRoom6, pbRoom7, pbRoom8, pbRoom9];

            ResetLabelsAndPictureboxes();
            //load data onto form
            LoadData();
        }

        private void LoadData()
        {
            ResetLabelsAndPictureboxes();

            
            //loop through all the suspect cards and see which ones which players have
            for (int i = 0; i < ClueCard.Suspects.Count; i++)
            {
                bool someoneUnknown = false; //if there is someone the card is unknown for
                bool someoneHas = false; //if there is someone who has the card
                string result = ClueCard.Suspects[i];
                for (int k = 0; k < players.Count; k++)
                {
                    if (players[k].Suspects[i].StatusIdx == 0)
                    {
                        result = players[k].Name + " has this card";
                        someoneHas = true;
                        break;
                    }
                    else if (players[k].Suspects[i].StatusIdx == 1)
                    {
                        result += "\r\n" + players[k].Name + " does not have this card";
                    }
                    else if (players[k].Suspects[i].StatusIdx == 2)
                    {
                        someoneUnknown = true;
                        result += "\r\n" + players[k].Name + " may or may not have this card";
                    }
                    else
                    {
                        result += "\r\n" + players[k].Name + " does not have this card";
                    }
                }
                if (someoneHas)
                {
                    suspectLabels[i].ForeColor = statusColors[0];
                    suspectLabels[i].Text = ClueCard.Suspects[i];
                    toolTip1.SetToolTip(suspectLabels[i], result);

                    suspectPBs[i].BackColor = statusColors[0];
                    suspectPBs[i].Image = imglstStatusIcons.Images[0];
                    toolTip1.SetToolTip(suspectPBs[i], result);
                }
                else if (someoneUnknown)
                {
                    suspectLabels[i].ForeColor = statusColors[2];
                    suspectLabels[i].Text = ClueCard.Suspects[i];
                    toolTip1.SetToolTip(suspectLabels[i], result);

                    suspectPBs[i].BackColor = statusColors[2];
                    suspectPBs[i].Image = imglstStatusIcons.Images[2];
                    toolTip1.SetToolTip(suspectPBs[i], result);
                }
                else // no one has this card
                {
                    result = "This is the murder suspect";
                    suspectLabels[i].ForeColor = statusColors[1];
                    suspectLabels[i].Text = ClueCard.Suspects[i];
                    toolTip1.SetToolTip(suspectLabels[i], result);

                    suspectPBs[i].BackColor = statusColors[1];
                    suspectPBs[i].Image = imglstStatusIcons.Images[1];
                    toolTip1.SetToolTip(suspectPBs[i], result);
                }
            }

            //loop through all the weapon cards and see which ones which players have
            for (int i = 0; i < ClueCard.Weapons.Count; i++)
            {
                bool someoneUnknown = false; //if there is someone the card is unknown for
                bool someoneHas = false; //if there is someone who has the card
                string result = ClueCard.Weapons[i];
                for (int k = 0; k < players.Count; k++)
                {
                    if (players[k].Weapons[i].StatusIdx == 0)
                    {
                        result = players[k].Name + " has this card";
                        someoneHas = true;
                        break;
                    }
                    else if (players[k].Weapons[i].StatusIdx == 1)
                    {
                        result += "\r\n" + players[k].Name + " does not have this card";
                    }
                    else if (players[k].Weapons[i].StatusIdx == 2)
                    {
                        someoneUnknown = true;
                        result += "\r\n" + players[k].Name + " may or may not have this card";
                    }
                }
                if (someoneHas)
                {
                    weaponLabels[i].ForeColor = statusColors[0];
                    weaponLabels[i].Text = ClueCard.Weapons[i];
                    toolTip1.SetToolTip(weaponLabels[i], result);

                    weaponPBs[i].BackColor = statusColors[0];
                    weaponPBs[i].Image = imglstStatusIcons.Images[0];
                    toolTip1.SetToolTip(weaponPBs[i], result);
                }
                else if (someoneUnknown)
                {
                    weaponLabels[i].ForeColor = statusColors[2];
                    weaponLabels[i].Text = ClueCard.Weapons[i];
                    toolTip1.SetToolTip(weaponLabels[i], result);

                    weaponPBs[i].BackColor = statusColors[2];
                    weaponPBs[i].Image = imglstStatusIcons.Images[2];
                    toolTip1.SetToolTip(weaponPBs[i], result);
                }
                else // no one has this card
                {
                    result = "This is the murder weapon";
                    weaponLabels[i].ForeColor = statusColors[1];
                    weaponLabels[i].Text = ClueCard.Weapons[i];
                    toolTip1.SetToolTip(weaponLabels[i], result);

                    weaponPBs[i].BackColor = statusColors[1];
                    weaponPBs[i].Image = imglstStatusIcons.Images[1];
                    toolTip1.SetToolTip(weaponPBs[i], result);
                }
            }

            //loop through all the room cards and see which ones which players have
            for (int i = 0; i < ClueCard.Rooms.Count; i++)
            {
                bool someoneUnknown = false; //if there is someone the card is unknown for
                bool someoneHas = false; //if there is someone who has the card
                string result = ClueCard.Rooms[i];
                for (int k = 0; k < players.Count; k++)
                {
                    if (players[k].Rooms[i].StatusIdx == 0)
                    {
                        result = players[k].Name + " has this card";
                        someoneHas = true;
                        break;
                    }
                    else if (players[k].Rooms[i].StatusIdx == 1)
                    {
                        result += "\r\n" + players[k].Name + " does not have this card";
                    }
                    else if (players[k].Rooms[i].StatusIdx == 2)
                    {
                        someoneUnknown = true;
                        result += "\r\n" + players[k].Name + " may or may not have this card";
                    }
                }
                if (someoneHas)
                {
                    roomLabels[i].ForeColor = statusColors[0];
                    roomLabels[i].Text = ClueCard.Rooms[i];
                    toolTip1.SetToolTip(roomLabels[i], result);

                    roomPBs[i].BackColor = statusColors[0];
                    roomPBs[i].Image = imglstStatusIcons.Images[0];
                    toolTip1.SetToolTip(roomPBs[i], result);
                }
                else if (someoneUnknown)
                {
                    roomLabels[i].ForeColor = statusColors[2];
                    roomLabels[i].Text = ClueCard.Rooms[i];
                    toolTip1.SetToolTip(roomLabels[i], result);

                    roomPBs[i].BackColor = statusColors[2];
                    roomPBs[i].Image = imglstStatusIcons.Images[2];
                    toolTip1.SetToolTip(roomPBs[i], result);
                }
                else // no one has this card
                {
                    result = "This is the murder weapon";
                    roomLabels[i].ForeColor = statusColors[1];
                    roomLabels[i].Text = ClueCard.Rooms[i];
                    toolTip1.SetToolTip(roomLabels[i], result);

                    roomPBs[i].BackColor = statusColors[1];
                    roomPBs[i].Image = imglstStatusIcons.Images[1];
                    toolTip1.SetToolTip(roomPBs[i], result);
                }
            }

        }

        public void DataRefresh(List<CluePlayer> clueplayers, List<Color> sc)
        {
            players = clueplayers;
            statusColors = sc;
            LoadData();
        }

        private void ResetLabelsAndPictureboxes()
        {
            List<Label> labels = [.. suspectLabels, .. weaponLabels, .. roomLabels];
            List<PictureBox> pictureBoxes = [.. suspectPBs, .. weaponPBs, .. roomPBs];
            //set all the labels/pictureboxes to Unknown
            foreach (Label l in labels)
            {
                l.ForeColor = statusColors[2];
                toolTip1.SetToolTip(l, "");
            }
            
            foreach (PictureBox pb in pictureBoxes)
            {
                pb.BackColor = statusColors[2];
                pb.Image = imglstStatusIcons.Images[2];
                toolTip1.SetToolTip(pb, "");
            }
        }

        private void RemoveRefFromParent(object sender, FormClosingEventArgs e)
        {
            parent.PopClueAllCardsForm(this);
        }

    }
}
