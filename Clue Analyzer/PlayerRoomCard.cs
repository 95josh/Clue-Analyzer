using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clue_Analyzer
{
    public class PlayerRoomCard : PlayerClueCard
    {
        //Constructors
        public PlayerRoomCard(string cardname, StatusValues cardStatus) : base("room", cardname, cardStatus)
        {

        }

        public PlayerRoomCard(int cardname, StatusValues cardStatus) : base("room", cardname, cardStatus)
        {

        }

        public PlayerRoomCard(string cardname, StatusValues cardStatus, bool statusByDiscovery) : base("room", cardname, cardStatus, statusByDiscovery)
        {

        }

        public PlayerRoomCard(int cardname, StatusValues cardStatus, bool statusByDiscovery) : base("room", cardname, cardStatus, statusByDiscovery)
        {

        }
    }
}
