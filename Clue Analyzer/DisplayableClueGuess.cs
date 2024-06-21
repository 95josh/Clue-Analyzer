using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clue_Analyzer
{
    public class DisplayableClueGuess
    {
        public string Suspect { get; set; }
        public string Weapon { get; set; }
        public string Room { get; set; }
        public string Guesser { get; set; }
        public string Responder { get; set; }
        public string ShownCard { get; set; }
        public bool ShownCardByDiscovery { get; set; }

        public DisplayableClueGuess(string suspect, string weapon, string room, string guesser, string responder, string showncard, bool showncardbydiscovery)
        {
            Suspect = suspect;
            Weapon = weapon;
            Room = room;
            Guesser = guesser;
            Responder = responder;
            ShownCard = showncard;
            ShownCardByDiscovery = showncardbydiscovery;
        }

        public static DisplayableClueGuess FromClueGuess(ClueGuess cg, List<CluePlayer> players)
        {
            if (cg.IsValid())
            {
                string responder = "N/A";
                string showncard = "N/A";
                if (cg.Responder != -1)
                {
                    responder = players[cg.Responder].Name;
                }
                if (cg.ShownCard != null)
                {
                    showncard = cg.ShownCard.CardName;
                }

                return new DisplayableClueGuess(cg.Suspect.CardName, cg.Weapon.CardName, cg.Room.CardName, players[cg.Guesser].Name, responder, showncard, cg.ShownCardByDiscovery);
            }
            else
            {
                throw new ArgumentOutOfRangeException(cg.ToString(), "Clue Guess is invalid");
            }
            
        }
    }
}
