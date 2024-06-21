using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Clue_Analyzer
{
    public class GameDetails
    {
        //this is a simple data storage class

        private string suspect;
        private string weapon;
        private string room;
        private int discoveries;

        public string Suspect {
            get
            {
                return suspect;
            }
            set 
            {
                if (value == null) suspect = "";
                else suspect = value;
            } 
        }
        public string Weapon 
        {
            get
            {
                return weapon;
            }
            set
            {
                if (value == null) weapon = "";
                else weapon = value;
            }
        }
        public string Room 
        {
            get
            {
                return room;
            }
            set
            {
                if (value == null) room = "";
                else room = value;
            }
        }
        public int Discoveries
        {
            get
            {
                return discoveries;
            }
            set
            {
                discoveries = value;
            }
        }

        public string Cards { get; set; }

        public GameDetails() 
        {
            suspect = "";
            weapon = "";
            room = "";
            Cards = "";
            discoveries = 0;
        }
    }
}
