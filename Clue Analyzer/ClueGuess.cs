using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clue_Analyzer
{
    public class ClueGuess
    {
        //instance variables
        public SuspectCard Suspect;
        public WeaponCard Weapon;
        public RoomCard Room;
        public int Guesser = -1;
        public int Responder = -1;
        public ClueCard? ShownCard = null;
        public bool ShownCardByDiscovery = false;

        
        public ClueGuess(SuspectCard sc, WeaponCard wp, RoomCard rm, int pGuesser, int pResponder, ClueCard cardshown, bool showncardbydisc = false)
        {
            Suspect = sc;
            Weapon = wp;
            Room = rm;
            Guesser = pGuesser;
            Responder = pResponder;
            ShownCard = cardshown;
            ShownCardByDiscovery = showncardbydisc;
        }

        //checks to make sure the guess is valid, the required items are not null, such as 
        //Suspect, Weapon, Room, Guesser. Responder, ShownCard and ShownCardByDiscovery are sometimes optional
        //However, if Responder is not null and Guesser is the program user, than ShownCard is required.
        //Ff Responder is the program user, then ShownCard is required
        //If responder and guesser are then same, then it is not valid (responder would probably have to be -1)
        public bool IsValid()
        {
            if (Suspect == null || Weapon == null || Room == null || Guesser == -1) return false;
            else if (Responder != -1 && Guesser == 0 && ShownCard == null) return false;
            else if (Responder == 0 && ShownCard == null) return false;
            else if (Responder == Guesser) return false;
            else return true;
        }

        public List<ClueCard> GuessedCardsToList()
        {
            List<ClueCard> output = [Suspect, Weapon, Room];
            return output;
        }

        public override string ToString()
        {
            if (IsValid())
            {
                string res = Suspect.CardName + "," + Weapon.CardName + "," + Room.CardName + "," +
                    Guesser + "," + Responder + "," + ShownCard.CardName;
                return res;
            }
            else
            {
                throw new ArgumentOutOfRangeException("", "ClueGuess is not valid");
            }
        }

    }
}
