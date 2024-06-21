using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clue_Analyzer
{
    //This is a basic data storage class
    public class AnalysisResult
    {

        //Properties
        //public int Discoveries { get; set; } = 0;
        public List<ClueGuess> Guesses { get; set; } = new List<ClueGuess>();
        public List<CluePlayer> Players { get; set; } = new List<CluePlayer>();
        public List<string> Results { get; set; } = new List<string>();
        public GameDetails GameDetails { get; set; } = new GameDetails();

        public AnalysisResult() 
        { 

        }

        public AnalysisResult(List<ClueGuess> guesses, List<CluePlayer> players, List<string> results, GameDetails gd)
        {
            Guesses = guesses;
            Players = players;
            Results = results;
            GameDetails = gd;
        }

        public AnalysisResult(List<ClueGuess> guesses, List<CluePlayer> players)
        {
            Guesses = guesses;
            Players = players;
        }
    }
}
