using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clue_Analyzer
{
    public class PlayerWeaponCard : PlayerClueCard
    {
        //Constructors
        public PlayerWeaponCard(string cardname, StatusValues cardStatus) : base("weapon", cardname, cardStatus)
        {

        }

        public PlayerWeaponCard(int cardname, StatusValues cardStatus) : base("weapon", cardname, cardStatus)
        {

        }

        public PlayerWeaponCard(string cardname, StatusValues cardStatus, bool statusByDiscovery) : base("weapon", cardname, cardStatus, statusByDiscovery)
        {

        }

        public PlayerWeaponCard(int cardname, StatusValues cardStatus, bool statusByDiscovery) : base("weapon", cardname, cardStatus, statusByDiscovery)
        {

        }
    }
}
