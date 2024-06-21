using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clue_Analyzer
{
    public class WeaponCard : RestrictedClueCard
    {
        public WeaponCard(string cardname) : base("weapon", cardname)
        {

        }

        public WeaponCard(int cardname) : base("weapon", cardname)
        {

        }
    }
}
