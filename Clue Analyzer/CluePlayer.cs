using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Clue_Analyzer
{
    public class CluePlayer : IEquatable<ClueCard>
    {
        //Fields
        private string name;
        private int cardCount;
        public List<PlayerSuspectCard> Suspects = new List<PlayerSuspectCard>();
        public List<PlayerWeaponCard> Weapons = new List<PlayerWeaponCard>();
        public List<PlayerRoomCard> Rooms = new List<PlayerRoomCard>();
        public SpecialCardsBucket SpecialCardSet = new SpecialCardsBucket();

        //Properties
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                //require specific length, so that there isn't text overflow
                if (value.Length <= 15 || value.Length >= 3)
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(value, "Name length must be between 3 and 15");
                }
            }
        }

        public int CardCount
        {
            get
            {
                return cardCount;
            }
            set
            {
                //there is a minimum three players and a maximum of 6
                //there is a maxiumum of 7 cards/player
                //there is a minimum of 3 cards/player (3 out of the 6 would have 4 cards)

                //catch basic value problems
                if (value > 7)
                {
                    throw new ArgumentOutOfRangeException(value.ToString(), "Cardcount value must be between (inclusive) 3 and 7");
                }
                else if (value < 3)
                {
                    throw new ArgumentOutOfRangeException(value.ToString(), "Cardcount value must be between (inclusive) 3 and 7");
                }
                else
                {
                    cardCount = value;
                }
            }
        }
        
        public CluePlayer(string playerName, int cardcount)
        {
            Name = playerName;

            //populate the cards
            //populate the suspects
            for (int i = 0; i < ClueCard.Suspects.Count; i++)
            {
                Suspects.Add(new PlayerSuspectCard(i, PlayerClueCard.StatusValues.Unknown)); //set the card status to unknown
            }
            //populate the weapons
            for (int i = 0; i < ClueCard.Weapons.Count; i++)
            {
                Weapons.Add(new PlayerWeaponCard(i, PlayerClueCard.StatusValues.Unknown)); //set the card status to unknown
            }
            //populate the rooms
            for (int i = 0; i < ClueCard.Rooms.Count; i++)
            {
                Rooms.Add(new PlayerRoomCard(i, PlayerClueCard.StatusValues.Unknown)); //set the card status to unknown
            }

            CardCount = cardcount;
        }

        public CluePlayer(string playerName, List<PlayerSuspectCard> suspects, 
            List<PlayerWeaponCard> weapons, List<PlayerRoomCard> rooms, int cardcount, SpecialCardsBucket specialCardsSet) 
        { 
            Name = playerName;

            //set suspects
            if (suspects.Count == ClueCard.Suspects.Count) Suspects = suspects;
            else throw new ArgumentOutOfRangeException(suspects.ToString(), "Suspects array must contain " + ClueCard.Suspects.Count.ToString() + " elements");

            //set weapons
            if (weapons.Count == ClueCard.Weapons.Count) Weapons = weapons;
            else throw new ArgumentOutOfRangeException(weapons.ToString(), "Weapons array must contain " + ClueCard.Weapons.Count.ToString() + " elements");

            //set rooms
            if (rooms.Count == ClueCard.Rooms.Count) Rooms = rooms;
            else throw new ArgumentOutOfRangeException(rooms.ToString(), "Rooms array must contain " + ClueCard.Rooms.Count.ToString() + " elements");

            CardCount = cardcount;
        }

        public void SetCardStatus(int CardTypeIdx, int CardNameIdx, PlayerClueCard.StatusValues Status)
        {
            if (CardTypeIdx == 0)
            {
                Suspects[CardNameIdx].Status = Status;
            }
            else if (CardTypeIdx == 1)
            {
                Weapons[CardNameIdx].Status = Status;
            }
            else if (CardTypeIdx == 2)
            {
                Rooms[CardNameIdx].Status = Status;
            }
        }

        public void SetCardStatus(int CardTypeIdx, string CardNameIdx, PlayerClueCard.StatusValues Status)
        {
            if (CardTypeIdx == 0)
            {
                int cardname = Array.IndexOf(ClueCard.Suspects.ToArray(), CardNameIdx);
                SetCardStatus(CardTypeIdx, cardname, Status);
            }
            else if (CardTypeIdx == 1)
            {
                int cardname = Array.IndexOf(ClueCard.Weapons.ToArray(), CardNameIdx);
                SetCardStatus(CardTypeIdx, cardname, Status);
            }
            else if (CardTypeIdx == 2)
            {
                int cardname = Array.IndexOf(ClueCard.Rooms.ToArray(), CardNameIdx);
                SetCardStatus(CardTypeIdx, cardname, Status);
            }
        }

        public void SetCardStatus(ClueCard cc, PlayerClueCard.StatusValues status)
        {
            SetCardStatus(cc.CardTypeIdx, cc.CardNameIdx, status);
        }

        public PlayerClueCard.StatusValues GetCardStatus(ClueCard cc)
        {
            int cardTypeIdx = cc.CardTypeIdx;
            int cardNameIdx = cc.CardNameIdx;
            if (cardTypeIdx == 0)
            {
                return Suspects[cardNameIdx].Status;
            }
            else if (cardTypeIdx == 1)
            {
                return Weapons[cardNameIdx].Status;
            }
            else
            {
                return Rooms[cardNameIdx].Status;
            }
        }

        public int GetCardStatusIdx(ClueCard cc)
        {
            int cardTypeIdx = cc.CardTypeIdx;
            int cardNameIdx = cc.CardNameIdx;
            if (cardTypeIdx == 0)
            {
                return Suspects[cardNameIdx].StatusIdx;
            }
            else if (cardTypeIdx == 1)
            {
                return Weapons[cardNameIdx].StatusIdx;
            }
            else
            {
                return Rooms[cardNameIdx].StatusIdx;
            }
        }

        public bool CardStatusYes(ClueCard cc)
        {
            if (GetCardStatus(cc) == PlayerClueCard.StatusValues.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CardStatusUnknown(ClueCard cc)
        {
            if (GetCardStatus(cc) == PlayerClueCard.StatusValues.Unknown)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CardStatusNo(ClueCard cc)
        {
            if (GetCardStatus(cc) == PlayerClueCard.StatusValues.No)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(ClueCard? other)
        {
            if (other != null)
            {

            }
            return false;
        }
    }
}
