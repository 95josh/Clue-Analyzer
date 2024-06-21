using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Clue_Analyzer
{
    //the point of this class is to contain
    //sets of cards that can possibly result
    //in better analysis results
    public class SpecialCardsBucket
    {

        //fields
        private List<List<ClueCard>> cards = new List<List<ClueCard>>();

        //properties
        public List<List<ClueCard>> Sets { get => cards; }


        public SpecialCardsBucket()
        {

        }

        public bool DeepContains(ClueCard card)
        {
            int cnt = CountCardNumber(card);
            if (cnt > 0) return true;
            else return false;
        }

        public int CountCardNumber(ClueCard card)
        {
            int output = 0;
            foreach (List<ClueCard> list in cards)
            {
                if (list.Contains(card)) output++;
            }
            return output;
        }

        //returns if the cards list has a list inside that matches exactly this list (quantity and number of items, but not order)
        public bool ContainsExactList(List<ClueCard> compareList)
        {
            List<ClueCard> orderedCompareList = [.. compareList.OrderBy(x => x.CardName)];
            foreach (List<ClueCard> list in cards)
            {
                if (orderedCompareList.SequenceEqual(list.OrderBy(x => x.CardName))) return true;
            }
            return false;
        }

        public void Add(List<ClueCard> newCards) 
        {
            cards.Add(newCards);
        }

        public bool Empty()
        {
            if (cards.Count == 0) return true;
            else return false;
        }

        public int Count()
        {
            return cards.Count;
        }

        public override string ToString()
        {
            string output = "";
            foreach (List<ClueCard> list in Sets)
            {
                foreach (ClueCard card in list)
                {
                    output += card.CardTypeIdx.ToString() + "," + card.CardNameIdx.ToString();
                    output += ";";
                }
                output = output.Trim(';');
                output += "|";

            }
            output = output.Trim('|');
            return output;
        }

        public static SpecialCardsBucket FromString(string input)
        {
            if (input == null || input == "")
            {
                return new SpecialCardsBucket();
            }
            else
            {
                SpecialCardsBucket output = new SpecialCardsBucket();
                string[] sets = input.Split("|");
                foreach (string s in sets)
                {
                    List<ClueCard> set = new List<ClueCard>();
                    string[] cards = s.Split(";");
                    foreach (string c in cards)
                    {
                        string[] cardval = c.Split(",");
                        int cardType = int.Parse(cardval[0].Trim());
                        int cardName = int.Parse(cardval[1].Trim());
                        if (cardType == 0)
                        {
                            set.Add(new SuspectCard(cardName));
                        }
                        else if (cardType == 1)
                        {
                            set.Add(new WeaponCard(cardName));
                        }
                        else if (cardType == 2)
                        {
                            set.Add(new RoomCard(cardName));
                        }
                    }
                    output.Add(set);
                }
                return output; 
            }
        }
    }
}
