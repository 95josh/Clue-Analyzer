using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clue_Analyzer
{
    public abstract class RestrictedClueCard : ClueCard
    {
        //hide two of the old Properties
        public new string CardType
        {
            set
            {
                throw new ArgumentOutOfRangeException(value, "Card type cannot be set on a RestrictedClueCard class");
            }
            get
            {
                return base.CardType;
            }
        }

        public new int CardTypeIdx
        {
            set
            {
                throw new ArgumentOutOfRangeException(value.ToString(), "Card type index cannot be set on a RestrictedClueCard class");
            }
            get
            {
                return base.CardTypeIdx;
            }
        }

        public RestrictedClueCard(string cardtype, string cardname) : base(cardtype, cardname)
        {

        }

        public RestrictedClueCard(int cardtype, int cardname) : base(cardtype, cardname)
        {

        }

        public RestrictedClueCard(string cardtype, int cardname) : base(cardtype, cardname)
        {

        }

        public RestrictedClueCard(int cardtype, string cardname) : base(cardtype, cardname)
        {

        }
    }
}
