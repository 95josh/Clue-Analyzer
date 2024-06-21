using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clue_Analyzer
{
    public abstract class PlayerClueCard : ClueCard
    {

        //enums
        public enum StatusValues
        {
            Yes = 0,
            No = 1,
            Unknown = 2
        }        

        //Properties
        public StatusValues Status { get; set; }

        public int StatusIdx
        {
            get
            {
                return (int)Status;
            }
            set
            {
                Status = (StatusValues)value;
            }
        }

        public bool StatusByDiscovery { get; set; } = true;


        //Constructors
        public PlayerClueCard(string cardtype, string cardname) : base(cardtype, cardname)
        {

        }

        public PlayerClueCard(int cardtype, int cardname) : base(cardtype, cardname)
        {

        }

        public PlayerClueCard(string cardtype, int cardname) : base(cardtype, cardname)
        {

        }

        public PlayerClueCard(int cardtype, string cardname) : base(cardtype, cardname)
        {

        }

        public PlayerClueCard(string cardtype, string cardname, StatusValues cardStatus) : base(cardtype, cardname)
        {
            Status = cardStatus;
        }

        public PlayerClueCard(int cardtype, int cardname, StatusValues cardStatus) : base(cardtype, cardname)
        {
            Status = cardStatus;
        }

        public PlayerClueCard(string cardtype, int cardname, StatusValues cardStatus) : base(cardtype, cardname)
        {
            Status = cardStatus;
        }

        public PlayerClueCard(int cardtype, string cardname, StatusValues cardStatus) : base(cardtype, cardname)
        {
            Status = cardStatus;
        }

        public PlayerClueCard(string cardtype, string cardname, StatusValues cardStatus, bool statusByDiscovery) : base(cardtype, cardname)
        {
            Status = cardStatus;
            StatusByDiscovery = statusByDiscovery;
        }

        public PlayerClueCard(int cardtype, int cardname, StatusValues cardStatus, bool statusByDiscovery) : base(cardtype, cardname)
        {
            Status = cardStatus;
            StatusByDiscovery = statusByDiscovery;
        }

        public PlayerClueCard(string cardtype, int cardname, StatusValues cardStatus, bool statusByDiscovery) : base(cardtype, cardname)
        {
            Status = cardStatus;
            StatusByDiscovery = statusByDiscovery;
        }

        public PlayerClueCard(int cardtype, string cardname, StatusValues cardStatus, bool statusByDiscovery) : base(cardtype, cardname)
        {
            Status = cardStatus;
            StatusByDiscovery = statusByDiscovery;
        }


    }
}
