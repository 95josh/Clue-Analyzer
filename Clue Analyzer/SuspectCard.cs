using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clue_Analyzer
{
    public class SuspectCard : RestrictedClueCard
    {

        public SuspectCard(string cardname) : base("suspect", cardname)
        {

        }

        public SuspectCard(int cardname) : base("suspect", cardname)
        {

        }
    }


}
