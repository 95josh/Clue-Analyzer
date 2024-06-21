using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clue_Analyzer
{
    public class PlayerSuspectCard : PlayerClueCard
    {
        //Constructors
        public PlayerSuspectCard(string cardname, StatusValues cardStatus) : base("suspect", cardname, cardStatus)
        {

        }

        public PlayerSuspectCard(int cardname, StatusValues cardStatus) : base("suspect", cardname, cardStatus)
        {

        }

        public PlayerSuspectCard(string cardname, StatusValues cardStatus, bool statusByDiscovery) : base("suspect", cardname, cardStatus, statusByDiscovery)
        {

        }

        public PlayerSuspectCard(int cardname, StatusValues cardStatus, bool statusByDiscovery) : base("suspect", cardname, cardStatus, statusByDiscovery)
        {

        }
    }
}
