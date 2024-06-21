using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clue_Analyzer
{
    public abstract class ClueCard : IEquatable<ClueCard>
    {
        //static card names
        public static List<string> Suspects = [ "Colonel Mustard", "Miss Scarlett", "Mr. Green", "Mrs. Peacock", "Mrs. White", "Professor Plum" ];
        public static List<string> Weapons = [ "Candlestick", "Knife", "Lead Pipe", "Revolver", "Rope", "Wrench" ];
        public static List<string> Rooms = [ "Ballroom", "Billiard Room", "Conservatory", "Dining Room", "Hall",
            "Kitchen", "Library", "Lounge", "Study" ];
        public static readonly List<string> CardTypes = ["Suspect", "Weapon", "Room"];

        //Fields
        private string cardType;
        private string cardName;
        private int cardTypeIdx;
        private int cardNameIdx;

        //Properties
        public string CardType {
            get
            {
                return cardType;
            }
            set
            {
                bool updated = false;
                //loop through all the card types and see if the new value matches one of them (case insensitive)
                for (int i = 0; i < CardTypes.Count; i++)
                {
                    if (value.Equals(CardTypes[i], StringComparison.OrdinalIgnoreCase)) //if lowered indicates suspect
                    {
                        cardType = CardTypes[i];
                        cardTypeIdx = i;
                        updated = true;
                        break;
                    }
                }
                //if the value wasn't updated, throw an exception, as obviously there wasn't a good value passed.
                if (!updated)
                {
                    throw new ArgumentOutOfRangeException(value.ToString(), "Card type is invalid");
                }
            }
        }
        
        public string CardName {
            get 
            { 
                return cardName; 
            }
            set 
            {
                if (CardType == CardTypes[0]) //if card type is a suspect
                {
                    bool updated = false;
                    //loop through all the suspect types and see if the new value matches one of them (case insensitive)
                    for (int i = 0; i < Suspects.Count; i++)
                    {
                        if (value.Equals(Suspects[i], StringComparison.OrdinalIgnoreCase)) //if equal, then update
                        {
                            cardName = Suspects[i];
                            cardNameIdx = i;
                            updated = true;
                            break; //updated, so break out
                        }
                    }
                    //if the value wasn't updated, throw an exception, as obviously there wasn't a good value passed.
                    if (!updated)
                    {
                        throw new ArgumentOutOfRangeException(value, "Suspect name is invalid");
                    }
                }
                else if (CardType == CardTypes[1]) //if card type is a weapon
                {
                    bool updated = false;
                    //loop through all the weapon types and see if the new value matches one of them (case insensitive)
                    for (int i = 0; i < Weapons.Count; i++)
                    {
                        if (value.Equals(Weapons[i], StringComparison.OrdinalIgnoreCase)) //if equal, then update
                        {
                            cardName = Weapons[i];
                            cardNameIdx = i;
                            updated = true;
                            break; //updated, so break out
                        }
                    }
                    //if the value wasn't updated, throw an exception, as obviously there wasn't a good value passed.
                    if (!updated)
                    {
                        throw new ArgumentOutOfRangeException(value, "Weapon name is invalid");
                    }
                }
                else if (CardType == CardTypes[2]) //if card type is a room
                {
                    bool updated = false;
                    //loop through all the room types and see if the new value matches one of them (case insensitive)
                    for (int i = 0; i < Rooms.Count; i++)
                    {
                        if (value.Equals(Rooms[i], StringComparison.OrdinalIgnoreCase)) //if equal, then update
                        {
                            cardName = Rooms[i];
                            cardNameIdx = i;
                            updated = true;
                            break; //updated, so break out
                        }
                    }
                    //if the value wasn't updated, throw an exception, as obviously there wasn't a good value passed.
                    if (!updated)
                    {
                        throw new ArgumentOutOfRangeException(value, "Room name is invalid");
                    }
                }
            }
        }

        public int CardTypeIdx
        {
            get
            {
                return cardTypeIdx;
            }
            set
            {
                if (value == 0) //if value indicates suspect
                {
                    cardTypeIdx = value;
                    cardType = CardTypes[0];
                }
                else if (value == 1) //if value indicates weapon
                {
                    cardTypeIdx = value;
                    cardType = CardTypes[1];
                }
                else if (value == 2) //if value indicates room
                {
                    cardTypeIdx = value;
                    cardType = CardTypes[2];
                }
                else //out of range
                {
                    throw new ArgumentOutOfRangeException(value.ToString(), "Card type index is invalid");
                }
            }
        }

        public int CardNameIdx
        {
            get
            {
                return cardNameIdx;
            }
            set
            {
                if (CardTypeIdx == 0)
                {
                    bool updated = false;
                    //loop through all the possible index values for suspects and see if the new value matches one of them
                    for (int i = 0; i < Suspects.Count; i++)
                    {
                        if (value == i) //if equal, then update
                        {
                            cardNameIdx = value;
                            cardName = Suspects[i];
                            updated = true;
                            break; //updated, so break out
                        }
                    }
                    //if the value wasn't updated, throw an exception, as obviously there wasn't a good value passed.
                    if (!updated)
                    {
                        throw new ArgumentOutOfRangeException(value.ToString(), "Card name suspect index is invalid");
                    }
                }
                else if (CardTypeIdx == 1)
                {
                    bool updated = false;
                    //loop through all the possible index values for weapons and see if the new value matches one of them
                    for (int i = 0; i < Weapons.Count; i++)
                    {
                        if (value == i) //if equal, then update
                        {
                            cardNameIdx = value;
                            cardName = Weapons[i];
                            updated = true;
                            break; //updated, so break out
                        }
                    }
                    //if the value wasn't updated, throw an exception, as obviously there wasn't a good value passed.
                    if (!updated)
                    {
                        throw new ArgumentOutOfRangeException(value.ToString(), "Card name weapon index is invalid");
                    }
                }
                else if (CardTypeIdx == 2)
                {
                    bool updated = false;
                    //loop through all the possible index values for rooms and see if the new value matches one of them
                    for (int i = 0; i < Rooms.Count; i++)
                    {
                        if (value == i) //if equal, then update
                        {
                            cardNameIdx = value;
                            cardName = Rooms[i];
                            updated = true;
                            break; //updated, so break out
                        }
                    }
                    //if the value wasn't updated, throw an exception, as obviously there wasn't a good value passed.
                    if (!updated)
                    {
                        throw new ArgumentOutOfRangeException(value.ToString(), "Card name room index is invalid");
                    }
                }
            }
        }

        public ClueCard(string cardtype, string cardname) 
        {
            CardType = cardtype;
            CardName = cardname;
        }

        public ClueCard(int cardtype, int cardname)
        {
            CardTypeIdx = cardtype;
            CardNameIdx = cardname;
        }

        public ClueCard(string cardtype, int cardname)
        {
            CardType = cardtype;
            CardNameIdx = cardname;
        }

        public ClueCard(int cardtype, string cardname) 
        {
            CardTypeIdx = cardtype;
            CardName = cardname;
        }

        public override bool Equals(object? other)
        {
            if (other == null || GetType() != other.GetType())
            {
                return false;
            }

            return Equals((ClueCard)other);
        }

        public bool Equals(ClueCard? other)
        {
            if (other == null)
            {
                return false;
            }
            if (CardNameIdx == other.CardNameIdx && cardTypeIdx == other.cardTypeIdx)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public override int GetHashCode()
        {
            return CardTypeIdx.GetHashCode() + cardNameIdx.GetHashCode();
        }

        public override string ToString()
        {
            return CardName;
        }

        
    }
}
