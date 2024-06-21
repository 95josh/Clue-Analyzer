using System.CodeDom.Compiler;

namespace Clue_Analyzer
{
    public class ClueAnalysisEngine
    {
        #region Constructors

        public ClueAnalysisEngine(List<ClueGuess> guesses, List<CluePlayer> players, GameDetails gd)
        {
            Guesses = guesses;
            Players = players;
            GameDetails = gd;
        }

        public ClueAnalysisEngine(AnalysisResult analysisResult)
        {
            Guesses = analysisResult.Guesses;
            Players = analysisResult.Players;
            GameDetails = analysisResult.GameDetails;
        }

        #endregion Constructors

        #region Properties

        public GameDetails GameDetails { get; set; } = new GameDetails();
        public List<ClueGuess> Guesses { get; set; } = new List<ClueGuess>();
        public List<CluePlayer> Players { get; set; } = new List<CluePlayer>();

        #endregion Properties

        #region Methods

        //this function handles the analysing process. Either takes in an analysisResult object
        //or creates one.
        public async Task<AnalysisResult> Analyze(AnalysisResult? analysisResult = null)
        {
            int initialResultCount = 0; //to keep track of how many results we had at the beginning (to see if we need to reanalyze)

            //if we need to create a new AnalysisResult object
            if (analysisResult == null)
            {
                analysisResult = new AnalysisResult(Guesses, Players, new List<string>(), GameDetails);
            }
            else
            {
                initialResultCount = analysisResult.Results.Count();
            }

            //Run the Analysis Methods
            GuessBasicAnalysis(ref analysisResult);
            OtherGuessAnalysis(ref analysisResult);
            MurderDetailCards(ref analysisResult);
            PlayerCardNumberAnalysis(ref analysisResult);
            bool reanalyze = CardPossibilityReduction(ref analysisResult);
            UpdateSpecialCardSet(ref analysisResult);

            //if we have new results, reanalyze
            if (analysisResult.Results.Count > initialResultCount || reanalyze)
            {
                analysisResult = await Analyze(analysisResult);
            }
            return analysisResult;
        }

        //returns if someone has a particular card, excluding a particular player
        private bool AnyoneHasExcept(int except, List<CluePlayer> players, ClueCard card)
        {
            //loop through all the players
            for (int i = 0; i < players.Count; i++)
            {
                //as long as the current player is not the excepted player
                if (i != except)
                {
                    //if the current player has the card return true
                    if (players[i].CardStatusYes(card))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //This method tries to find a set of guesses that have unique cards
        //for each user, and then uses that set of guesses to make certain deductions.
        //Also compares the set to other guesses to make further deductions.
        //This set of guesses and their cards is called a SpecialCardSet.
        //Generally, each guess and their cards is a called a set.
        //
        //General idea behind using other guesses to make further deductions:
        //If a guess is made that matches one of the sets of card (at least one card matching, but not all the cards matching)
        //and none of the other cards from the guess match any of the other guesses, then we happen
        //to know that the player doesn't have any of the cards that didn't match.
        //
        //This method tries to reduce the number of possible cards a player has,
        //hence the name CardPossibilityReduction
        public bool CardPossibilityReduction(ref AnalysisResult analysisResult)
        {
            bool results = false;

            //loop through all the players (except for the program user, we already know all of that player's cards.
            //The program user will always be the first user.)
            for (int i = 1; i < analysisResult.Players.Count; i++)
            {
                List<CluePlayer> players = analysisResult.Players;
                CluePlayer player = players[i];

                int cardsLeft = MissingCardCount(player);

                //if the missing cards for a player is greater than 0 (meaning he/she has x number of cards, but we don't know y of them),
                //and their special card set is empty
                if (cardsLeft > 0 && player.SpecialCardSet.Empty())
                {
                    //get the guesses that we don't know the shown card for and the responder is the current player
                    List<ClueGuess> unShownGuesses = (from guess in analysisResult.Guesses
                                                      where guess.ShownCard == null && guess.Responder == i
                                                      select guess).ToList();

                    int guessCount = 0;
                    List<ClueCard> possibleCards = new List<ClueCard>(); //a list of cards that could be the player's cards
                    SpecialCardsBucket guessBucket = new SpecialCardsBucket(); //a bucket to hold the player's special card info

                    //loop through all the unShownGuesses to determine which ones are useful
                    for (int j = 0; j < unShownGuesses.Count; j++)
                    {
                        ClueGuess currGuess = unShownGuesses[j];
                        SuspectCard suspect = currGuess.Suspect;
                        WeaponCard weapon = currGuess.Weapon;
                        RoomCard room = currGuess.Room;

                        //if all the guess's cards are unknown for the responder (current player in the loop)
                        if (player.CardStatusUnknown(suspect) && player.CardStatusUnknown(weapon) && player.CardStatusUnknown(room))
                        {
                            //as long as there are no duplicate cards coming in
                            if (!DuplicatesFound(ref possibleCards, currGuess.GuessedCardsToList()))
                            {
                                if (guessCount != cardsLeft)
                                {
                                    guessCount++;
                                    possibleCards.AddRange(currGuess.GuessedCardsToList());
                                    guessBucket.Add(currGuess.GuessedCardsToList());
                                }
                                else break;
                            }
                        }

                        //if two of the guess's cards are set to "unknown" and the final one is set to "no" for the responder
                        else if (player.CardStatusUnknown(suspect) && player.CardStatusUnknown(weapon) && player.CardStatusNo(room))
                        {
                            //as long as there are no duplicate cards coming in
                            if (!DuplicatesFound(ref possibleCards, [suspect, weapon]))
                            {
                                if (guessCount != cardsLeft)
                                {
                                    guessCount++;
                                    possibleCards.AddRange([suspect, weapon]);
                                    guessBucket.Add([suspect, weapon]);
                                }
                                else break;
                            }
                        }
                        else if (player.CardStatusUnknown(weapon) && player.CardStatusUnknown(room) && player.CardStatusNo(suspect))
                        {
                            //as long as there are no duplicate cards coming in
                            if (!DuplicatesFound(ref possibleCards, [weapon, room]))
                            {
                                if (guessCount != cardsLeft)
                                {
                                    guessCount++;
                                    possibleCards.AddRange([weapon, room]);
                                    guessBucket.Add([weapon, room]);
                                }
                                else break;
                            }
                        }
                        else if (player.CardStatusUnknown(room) && player.CardStatusUnknown(suspect) && player.CardStatusNo(weapon))
                        {
                            //as long as there are no duplicate cards coming in
                            if (!DuplicatesFound(ref possibleCards, [room, suspect]))
                            {
                                if (guessCount != cardsLeft)
                                {
                                    guessCount++;
                                    possibleCards.AddRange([room, suspect]);
                                    guessBucket.Add([room, suspect]);
                                }
                                else break;
                            }
                        }
                    }

                    //if we found enough appropriate guesses to continue, set all the player's other cards' statuses to "no"
                    //as long as they aren't already "yes"
                    if (cardsLeft == guessCount)
                    {
                        List<ClueCard> suspectCards = (from card in possibleCards
                                                       where card.CardTypeIdx == 0
                                                       select card).ToList();
                        List<ClueCard> weaponCards = (from card in possibleCards
                                                      where card.CardTypeIdx == 1
                                                      select card).ToList();
                        List<ClueCard> roomCards = (from card in possibleCards
                                                    where card.CardTypeIdx == 2
                                                    select card).ToList();

                        //set all the other cards to no (as long as they arn't already yes)
                        foreach (PlayerSuspectCard card in player.Suspects)
                        {
                            if (!suspectCards.Contains(card) && card.Status != PlayerClueCard.StatusValues.Yes)
                            {
                                card.Status = PlayerClueCard.StatusValues.No;
                            }
                        }
                        foreach (PlayerWeaponCard card in player.Weapons)
                        {
                            if (!weaponCards.Contains(card) && card.Status != PlayerClueCard.StatusValues.Yes)
                            {
                                card.Status = PlayerClueCard.StatusValues.No;
                            }
                        }
                        foreach (PlayerRoomCard card in player.Rooms)
                        {
                            if (!roomCards.Contains(card) && card.Status != PlayerClueCard.StatusValues.Yes)
                            {
                                card.Status = PlayerClueCard.StatusValues.No;
                            }
                        }
                        player.SpecialCardSet = guessBucket; //set the player's special card bucket to true
                        results = true;
                    }
                }

                //if the missing cards for a player is still greater than 0 and their special card set is not empty,
                //search for similarities between guesses (where the player responded) and the stored special cards
                //and eliminate dissimilarities
                if (cardsLeft > 0 && !player.SpecialCardSet.Empty())
                {
                    List<ClueGuess> unShownGuesses = (from guess in analysisResult.Guesses
                                                      where guess.Responder == i
                                                      select guess).ToList();

                    //debugging code
                    //string output = player.Name + "\r\n";
                    //foreach (List<ClueCard> list in player.SpecialCardSet.Sets)
                    //{
                    //    foreach (ClueCard card in list)
                    //    {
                    //        output += card.CardName + " ";
                    //    }
                    //    output += "\r\n";
                    //}
                    //output += "GUESSES \r\n";
                    //foreach (ClueGuess guess in unShownGuesses)
                    //{
                    //    foreach (ClueCard card in guess.GuessedCardsToList())
                    //    {
                    //        output += card.CardName + " ";
                    //    }
                    //    output += "\r\n";
                    //}
                    //MessageBox.Show(output);

                    //loop through all the guesses that didn't have a card shown
                    for (int j = 0; j < unShownGuesses.Count; j++)
                    {
                        ClueGuess currGuess = unShownGuesses[j];
                        List<ClueCard> guessSet = currGuess.GuessedCardsToList();
                        List<List<ClueCard>> playerAllSets = player.SpecialCardSet.Sets;

                        //loop through each of the special player card sets
                        for (int k = 0; k < playerAllSets.Count; k++)
                        {
                            List<ClueCard> currentSet = playerAllSets[k];

                            //cards that show up in the current set but not in the guess
                            List<ClueCard> currSetUnique = currentSet.Except(guessSet).ToList();
                            //cards that are in both sets (removing duplicates)
                            List<ClueCard> cardSetsUnion = currentSet.Union(guessSet).ToList();
                            //cards that show up in the current guess but not in the set
                            List<ClueCard> currGuessUnique = guessSet.Except(currentSet).ToList();
                            //cards that are unique to both sets
                            List<ClueCard> uniqueCards = currSetUnique.Union(currGuessUnique).ToList();

                            //as long as there is something different, but not everything different
                            //between the guess and the card set, and also that there is something similar,
                            //but not everything similar
                            if (cardSetsUnion.Count >= 1 && cardSetsUnion.Count < (guessSet.Count + currentSet.Count) && currSetUnique.Count != 0)
                            {
                                //if the current guess doesn't have cards that are in other sets and it also doesn't contain cards that the player
                                //has but aren't in the sets. We do this so that
                                if (!ContainsOtherSetCards(k, playerAllSets, currGuess) && !ContainsOtherPlayerCardsNotInSets(player, currGuess))
                                {
                                    //loop through all the unique cards and set them to no, as long as that card isn't already Yes or No
                                    foreach (ClueCard card in uniqueCards)
                                    {
                                        //if the player's card is set to unknown and the card is not
                                        if (player.GetCardStatus(card) == PlayerClueCard.StatusValues.Unknown)
                                        {
                                            player.SetCardStatus(card, PlayerClueCard.StatusValues.No); //set the player card status to no
                                            currentSet.Remove(card); //remove the card from the set
                                            results = true;
                                            //MessageBox.Show(card.CardName + " set to " + player.GetCardStatus(card));
                                        }
                                        //else
                                        //{
                                        //    MessageBox.Show(card.CardName + player.GetCardStatus(card));
                                        //}
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //loop through all the players that have special card sets. 
            //if two of the players have the an same card set that only has two cards,
            //the all the other players don't have those two cards.
            //Or if there are three players that have the same card set that has three cards,
            //then all the other players don't have those three cards.
            List<CluePlayer> playersWithSpecialCardSets = (from player in analysisResult.Players
                                                           where player.SpecialCardSet.Empty() == false
                                                           select player).ToList();

            //loop through each of the players with special card sets
            for (int i = 0; i < playersWithSpecialCardSets.Count; i++)
            {
                CluePlayer currentPlayer = playersWithSpecialCardSets[i];
                //loop through each of the special card sets
                for (int j = 0; j < currentPlayer.SpecialCardSet.Sets.Count; j++)
                {
                    List<ClueCard> currentSet = currentPlayer.SpecialCardSet.Sets[j];

                    List<CluePlayer> playersWithSameSet = new List<CluePlayer>();

                    //loop through all the special players to see if there are card sets that match.
                    for (int p = 0; p < playersWithSpecialCardSets.Count; p++)
                    {
                        if (playersWithSpecialCardSets[p].SpecialCardSet.ContainsExactList(currentSet))
                        {
                            playersWithSameSet.Add(playersWithSpecialCardSets[p]);
                        }
                    }

                    //if there are the same number of players as the number of cards in the current 
                    //set, then set all the other players' cards in that set to no (as long as they are set to Unknown)
                    //Also make sure that the current set has more cards than just one, as sets with only one card will be handled by other functions.
                    if (playersWithSameSet.Count == currentSet.Count && currentSet.Count > 1)
                    {
                        for ( int p = 0; p < analysisResult.Players.Count; p++)
                        {
                            CluePlayer player = analysisResult.Players[p];
                            //if the player is one of the players with the same special set, go to the next part of the loop
                            if (playersWithSameSet.Contains(player))
                            {
                                continue;
                            }
                            //loop through each of the cards in the currentSet and set the card's status to 
                            //no, as long as the current status of the card for the current player is unknown.
                            foreach (ClueCard card in currentSet)
                            {
                                //as long as the card is set to unknown for the player
                                if (player.CardStatusUnknown(card))
                                {
                                    player.SetCardStatus(card, PlayerClueCard.StatusValues.No);
                                    results = true; //we changed something!
                                }
                            }
                        }

                    }
                }
            }

            return results;
        }

        //looks for cards in a guess that a player has but are not in that player's sets of cards
        private bool ContainsOtherPlayerCardsNotInSets(CluePlayer player, ClueGuess guess)
        {
            //loop through all the cards in the guess list
            foreach (ClueCard card in guess.GuessedCardsToList())
            {
                //if the players' card set doesn't have it and the player has the card, then return true
                if (!player.SpecialCardSet.DeepContains(card) && player.CardStatusYes(card))
                {
                    return true;
                }
            }
            return false;
        }

        //returns if any of the cards in the passed guess are in the other sets
        private bool ContainsOtherSetCards(int setIdx, List<List<ClueCard>> cardSets, ClueGuess guess)
        {
            List<ClueCard> guessCards = guess.GuessedCardsToList();

            //loop through all the sets
            for (int i = 0; i < cardSets.Count; i++)
            {
                //as long as the current set is not the setIdx (the current set)
                if (i != setIdx)
                {
                    //loop through each of the guess cards and see if it is contained in the set
                    //if so, return true
                    foreach (ClueCard card in guessCards)
                    {
                        if (cardSets[i].Contains(card))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //this method checks for duplicate cards between two sets of cards. If there are duplicates, it returns true, else false.
        private bool DuplicatesFound(ref List<ClueCard> existingCards, List<ClueCard> newCards)
        {
            //get the cards that are duplicates across the two lists
            List<ClueCard> duplicates = existingCards.Where(newCards.Contains).ToList();

            //as long as thre are duplicates, return true, else return false
            if (duplicates.Count > 0) return true;
            else return false;
        }

        //This method does some basic card setting when a new guess comes out.
        //The idea is that players inbetween the Guesser and Responder
        //will not have any of the cards in the guess.
        private void GuessBasicAnalysis(ref AnalysisResult analysisResult)
        {
            //loop through all the guesses
            foreach (ClueGuess guess in analysisResult.Guesses)
            {
                List<CluePlayer> inbetweenPlayers = PlayersInbetween(guess.Guesser, guess.Responder, analysisResult.Players);
                List<CluePlayer> otherPlayers = PlayersInbetween(guess.Guesser, -1, analysisResult.Players);

                //if the program user gets shown a card, update responder to have it and the others to not have it.
                if (guess.Guesser == 0 && guess.Responder != -1)
                {
                    analysisResult.Players = SetPlayerHasOthersNo(guess.Responder, analysisResult.Players, guess.ShownCard);
                }

                //set all the "inbetween" players to not have the cards in the guess
                foreach (CluePlayer player in inbetweenPlayers)
                {
                    player.SetCardStatus(guess.Suspect, PlayerClueCard.StatusValues.No);
                    player.SetCardStatus(guess.Weapon, PlayerClueCard.StatusValues.No);
                    player.SetCardStatus(guess.Room, PlayerClueCard.StatusValues.No);
                }
            }
        }

        //This method gets run when it is figured out that a player has a card.
        //It determines if the card type, and creates an appropriate string
        //to be added onto the end of the analysis result later.
        private string GetCardResult(ClueCard card, CluePlayer player)
        {
            string output = player.Name;
            if (card.CardTypeIdx == 0)
            {
                output += " has " + card.CardName + ".";
            }
            else if (card.CardTypeIdx == 1)
            {
                output += " has the " + card.CardName + ".";
            }
            else if (card.CardTypeIdx == 2)
            {
                output += " has the " + card.CardName + ".";
            }
            return output;
        }

        //returns the number of cards the player has minus the number of cards we know the player has
        private int MissingCardCount(CluePlayer player)
        {
            int cardsHas = (from card in player.Suspects
                            where card.Status == PlayerClueCard.StatusValues.Yes
                            select card).Count();
            cardsHas += (from card in player.Weapons
                         where card.Status == PlayerClueCard.StatusValues.Yes
                         select card).Count();
            cardsHas += (from card in player.Rooms
                         where card.Status == PlayerClueCard.StatusValues.Yes
                         select card).Count();
            return player.CardCount - cardsHas;
        }

        //finds out if there are new murder details to be discovered.
        //If for example no one has a card, it is a murder detail
        //Or, if we know where all the rooms are except for one, then that room is the murder location
        public void MurderDetailCards(ref AnalysisResult analysisResult)
        {
            //loop through all the suspect cards to see if there is any one card no-one has.
            //If so, then that is the murderer
            bool newResult = false;
            List<CluePlayer> players = analysisResult.Players;
            GameDetails gd = analysisResult.GameDetails;
            for (int i = 0; i < ClueCard.Suspects.Count; i++)
            {
                bool someoneUnknown = false; //if there is someone the card is unknown for
                bool someoneHas = false; //if there is someone who has the card
                for (int k = 0; k < players.Count; k++)
                {
                    if (players[k].Suspects[i].StatusIdx == 0)
                    {
                        someoneHas = true;
                        break; //someone has it, so it isn't the murderer
                    }
                    else if (players[k].Suspects[i].StatusIdx == 2)
                    {
                        someoneUnknown = true;
                        break; //someone it is unknown for, so it isn't the suspect (yet)
                    }
                }
                if (!someoneHas && !someoneUnknown && gd.Suspect == "") // no one has this card, and the suspect hasn't been found yet
                {
                    newResult = true;
                    gd.Suspect = ClueCard.Suspects[i];
                    gd.Discoveries++;
                    analysisResult.Results.Add("The murderer is " + ClueCard.Suspects[i] + "!");
                }
            }

            //loop through all the weapon cards and see if there is any one card no-one has.
            //If so, that is the murder weapon
            for (int i = 0; i < ClueCard.Weapons.Count; i++)
            {
                bool someoneUnknown = false; //if there is someone the card is unknown for
                bool someoneHas = false; //if there is someone who has the card
                for (int k = 0; k < players.Count; k++)
                {
                    if (players[k].Weapons[i].StatusIdx == 0)
                    {
                        someoneHas = true;
                        break; //someone has it, so it isn't the murder weapon
                    }
                    else if (players[k].Weapons[i].StatusIdx == 2)
                    {
                        someoneUnknown = true;
                        break; //someone it is unknown for, so it isn't the murder weapon (yet)
                    }
                }
                if (!someoneHas && !someoneUnknown && gd.Weapon == "") // no one has this card, and the weapon hasn't been found yet
                {
                    newResult = true;
                    gd.Discoveries++;
                    gd.Weapon = ClueCard.Weapons[i];
                    analysisResult.Results.Add("The murder weapon is " + ClueCard.Weapons[i] + "!");
                }
            }

            //loop through all the room cards and see if there is any one card no-one has.
            //If so, that is the murder location
            for (int i = 0; i < ClueCard.Rooms.Count; i++)
            {
                bool someoneUnknown = false; //if there is someone the card is unknown for
                bool someoneHas = false; //if there is someone who has the card
                for (int k = 0; k < players.Count; k++)
                {
                    if (players[k].Rooms[i].StatusIdx == 0)
                    {
                        someoneHas = true;
                        break; //someone has it, so it isn't the murder location
                    }
                    else if (players[k].Rooms[i].StatusIdx == 2)
                    {
                        someoneUnknown = true;
                        break; //someone it is unknown for, so it isn't the murder location (yet)
                    }
                }
                if (!someoneHas && !someoneUnknown && gd.Room == "") // no one has this card, and the room hasn't been found yet
                {
                    newResult = true;
                    gd.Room = ClueCard.Rooms[i];
                    gd.Discoveries++;
                    analysisResult.Results.Add("The murder location is " + ClueCard.Rooms[i] + "!");
                }
            }

            //loop through all the suspect cards and see if there is only one card we don't
            //know where it is at. That will be the murder suspect.
            if (gd.Suspect == "") //only if the suspect hasn't been found yet
            {
                bool[] found = new bool[ClueCard.Suspects.Count];
                int count = 0;
                //populate "found" array
                for (int i = 0; i < ClueCard.Suspects.Count; i++)
                {
                    found[i] = false;
                }
                for (int i = 0; i < ClueCard.Suspects.Count; i++)
                {
                    for (int k = 0; k < players.Count; k++)
                    {
                        //only interested if someone has the card
                        if (players[k].Suspects[i].StatusIdx == 0)
                        {
                            count++;
                            found[i] = true; //a card was found!
                            break;
                        }
                    }
                }
                //if there is exactly one card not accounted for
                if (count == ClueCard.Suspects.Count - 1)
                {
                    //find the card that was not accounted for
                    int cardIdx = 0;
                    for (int i = 0; i < ClueCard.Suspects.Count; i++)
                    {
                        if (found[i] == false)
                        {
                            cardIdx = i;
                            break;
                        }
                    }
                    newResult = true;
                    gd.Suspect = ClueCard.Suspects[cardIdx];
                    gd.Discoveries++;
                    SetAllPlayersCardStatus(ref players, new SuspectCard(gd.Suspect), PlayerClueCard.StatusValues.No);
                    analysisResult.Results.Add("The murderer is " + ClueCard.Suspects[cardIdx] + "!");
                }
            }

            //loop through all the weapon cards and see if there is only one card we don't
            //know where it is at. That will be the murder weapon.
            if (gd.Weapon == "") //only if the weapon hasn't been found yet
            {
                bool[] found = new bool[ClueCard.Weapons.Count];
                int count = 0;
                //populate "found" array
                for (int i = 0; i < ClueCard.Weapons.Count; i++)
                {
                    found[i] = false;
                }
                for (int i = 0; i < ClueCard.Weapons.Count; i++)
                {
                    for (int k = 0; k < players.Count; k++)
                    {
                        //only interested if someone has the card
                        if (players[k].Weapons[i].StatusIdx == 0)
                        {
                            count++;
                            found[i] = true; //a card was found!
                            break;
                        }
                    }
                }
                //if there is exactly one card not accounted for
                if (count == ClueCard.Weapons.Count - 1)
                {
                    //find the card that was not accounted for
                    int cardIdx = 0;
                    for (int i = 0; i < ClueCard.Weapons.Count; i++)
                    {
                        if (found[i] == false)
                        {
                            cardIdx = i;
                            break;
                        }
                    }
                    newResult = true;
                    gd.Weapon = ClueCard.Weapons[cardIdx];
                    gd.Discoveries++;
                    SetAllPlayersCardStatus(ref players, new WeaponCard(gd.Weapon), PlayerClueCard.StatusValues.No);
                    analysisResult.Results.Add("The murder weapon is " + ClueCard.Weapons[cardIdx] + "!");
                }
            }

            //loop through all the room cards and see if there is only one card we don't
            //know where it is at. That will be the murder location.
            if (gd.Room == "") //only if the room hasn't been found yet
            {
                bool[] found = new bool[ClueCard.Rooms.Count];
                int count = 0;
                //populate "found" array
                for (int i = 0; i < ClueCard.Rooms.Count; i++)
                {
                    found[i] = false;
                }
                for (int i = 0; i < ClueCard.Rooms.Count; i++)
                {
                    for (int k = 0; k < players.Count; k++)
                    {
                        //only interested if someone has the card
                        if (players[k].Rooms[i].StatusIdx == 0)
                        {
                            count++;
                            found[i] = true; //a card was found!
                            break;
                        }
                    }
                }
                //if there is exactly one card not accounted for
                if (count == ClueCard.Rooms.Count - 1)
                {
                    //find the card that was not accounted for
                    int cardIdx = 0;
                    for (int i = 0; i < ClueCard.Rooms.Count; i++)
                    {
                        if (found[i] == false)
                        {
                            cardIdx = i;
                            break;
                        }
                    }
                    newResult = true;
                    gd.Room = ClueCard.Rooms[cardIdx];
                    gd.Discoveries++;
                    SetAllPlayersCardStatus(ref players, new RoomCard(gd.Room), PlayerClueCard.StatusValues.No);
                    analysisResult.Results.Add("The murder location is " + ClueCard.Rooms[cardIdx] + "!");
                }
            }

            if (newResult)
            {
                if (gd.Suspect != "" && gd.Weapon != "" && gd.Room != "")
                {
                    analysisResult.Results.Add("YOU KNOW ALL THE SECRET CARDS!");
                }
            }
            analysisResult.GameDetails = gd;
            analysisResult.Players = players;
        }

        //returns if no one has a particular card (for everyone it is marked as "No" or "Unknown")
        private bool NoOneHas(List<CluePlayer> players, ClueCard card)
        {
            //loop through all the players
            for (int i = 0; i < players.Count; i++)
            {
                //if the current player's card status is not set to No, this means that the player may have the card, so return false
                if (players[i].CardStatusUnknown(card) || players[i].CardStatusYes(card))
                {
                    return false;
                }
            }
            return true;
        }

        //does some general analysis on guesses to determine the card shown
        //for example, for the guess ballroom, wrench, green, if we know
        //that the Guesser has ballroom and wrench, then the responder
        //showed green. Or, if there was no responder, and we know the guesser
        //does not have the suspect (card status set to no), then the suspect is the murderer.
        public void OtherGuessAnalysis(ref AnalysisResult analysisResult)
        {
            //loop through all the guesses
            List<CluePlayer> players = analysisResult.Players;
            GameDetails gd = analysisResult.GameDetails;
            foreach (ClueGuess guess in analysisResult.Guesses)
            {
                CluePlayer guesser = players[guess.Guesser];
                CluePlayer? responder = guess.Responder != -1 ? players[guess.Responder] : null;
                SuspectCard suspect = guess.Suspect;
                WeaponCard weapon = guess.Weapon;
                RoomCard room = guess.Room;
                //if the shown card hasn't been figured out yet, and the responder is there,
                //do the following analysis
                if (guess.ShownCard == null && responder != null)
                {
                    //if anyone has two of the cards (excluding the responder)
                    if (AnyoneHasExcept(guess.Responder, players, suspect) && AnyoneHasExcept(guess.Responder, players, weapon))
                    {
                        guess.ShownCard = room;
                        RoomDiscoveryHandler(ref analysisResult, ref players, guess);
                    }
                    else if (AnyoneHasExcept(guess.Responder, players, suspect) && AnyoneHasExcept(guess.Responder, players, room))
                    {
                        guess.ShownCard = weapon;
                        WeaponDiscoveryHandler(ref analysisResult, ref players, guess);
                    }
                    else if (AnyoneHasExcept(guess.Responder, players, weapon) && AnyoneHasExcept(guess.Responder, players, room))
                    {
                        guess.ShownCard = suspect;
                        SuspectDiscoveryHandler(ref analysisResult, ref players, guess);
                    }

                    //if guess.showncard is still null, check if the responder doesn't have two of the cards
                    if (guess.ShownCard == null)
                    {
                        PlayerClueCard.StatusValues NoStatus = PlayerClueCard.StatusValues.No;
                        //if the responder doesn't have two of the cards, then surely the responder must have the last one
                        if (responder.GetCardStatus(suspect) == NoStatus && responder.GetCardStatus(weapon) == NoStatus)
                        {
                            guess.ShownCard = room;
                            RoomDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                        else if (responder.GetCardStatus(suspect) == NoStatus && responder.GetCardStatus(room) == NoStatus)
                        {
                            guess.ShownCard = weapon;
                            WeaponDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                        else if (responder.GetCardStatus(weapon) == NoStatus && responder.GetCardStatus(room) == NoStatus)
                        {
                            guess.ShownCard = suspect;
                            SuspectDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                    }

                    //if guess.showncard is still null, check if the responder doesn't have
                    //one of the cards but someone else does
                    if (guess.ShownCard == null)
                    {
                        PlayerClueCard.StatusValues NoStatus = PlayerClueCard.StatusValues.No;
                        //if the responder doesn't have one of the cards, and someone else has the other,
                        //then surely the responder must have the last one
                        if (responder.GetCardStatus(suspect) == NoStatus && AnyoneHasExcept(guess.Responder, players, weapon))
                        {
                            guess.ShownCard = room;
                            RoomDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                        else if (responder.GetCardStatus(suspect) == NoStatus && AnyoneHasExcept(guess.Responder, players, room))
                        {
                            guess.ShownCard = weapon;
                            WeaponDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                        else if (responder.GetCardStatus(weapon) == NoStatus && AnyoneHasExcept(guess.Responder, players, room))
                        {
                            guess.ShownCard = suspect;
                            SuspectDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                    }

                    //if guess.showncard is still null, check if two of the cards no one has,
                    //then we know the last one the responder must have
                    if (guess.ShownCard == null)
                    {
                        if (NoOneHas(players, suspect) && NoOneHas(players, weapon))
                        {
                            guess.ShownCard = room;
                            RoomDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                        else if (NoOneHas(players, suspect) && NoOneHas(players, room))
                        {
                            guess.ShownCard = weapon;
                            WeaponDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                        else if (NoOneHas(players, weapon) && NoOneHas(players, room))
                        {
                            guess.ShownCard = suspect;
                            SuspectDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                    }

                    //if guess.showncard is still null, check if one of the cards no one has,
                    //and the other card someone out there has (besides responder)
                    //then we know the last card is the responders'
                    if (guess.ShownCard == null)
                    {
                        if (NoOneHas(players, suspect) && AnyoneHasExcept(guess.Responder, players, weapon))
                        {
                            guess.ShownCard = room;
                            RoomDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                        else if (NoOneHas(players, suspect) && AnyoneHasExcept(guess.Responder, players, room))
                        {
                            guess.ShownCard = weapon;
                            WeaponDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                        else if (NoOneHas(players, weapon) && AnyoneHasExcept(guess.Responder, players, suspect))
                        {
                            guess.ShownCard = room;
                            RoomDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                        else if (NoOneHas(players, weapon) && AnyoneHasExcept(guess.Responder, players, room))
                        {
                            guess.ShownCard = suspect;
                            SuspectDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                        else if (NoOneHas(players, room) && AnyoneHasExcept(guess.Responder, players, suspect))
                        {
                            guess.ShownCard = weapon;
                            WeaponDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                        else if (NoOneHas(players, room) && AnyoneHasExcept(guess.Responder, players, weapon))
                        {
                            guess.ShownCard = suspect;
                            SuspectDiscoveryHandler(ref analysisResult, ref players, guess);
                        }
                    }
                }
                else if (responder == null)
                {
                    PlayerClueCard.StatusValues NoStatus = PlayerClueCard.StatusValues.No;
                    //for any of the following cases, we have found one of the murder details!
                    if (guesser.GetCardStatus(suspect) == NoStatus && analysisResult.GameDetails.Suspect == "")
                    {
                        analysisResult.GameDetails.Discoveries++;
                        analysisResult.GameDetails.Suspect = suspect.ToString();
                        analysisResult.Results.Add("The murderer is " + suspect + "!");
                    }
                    if (guesser.GetCardStatus(weapon) == NoStatus && analysisResult.GameDetails.Weapon == "")
                    {
                        analysisResult.GameDetails.Discoveries++;
                        analysisResult.GameDetails.Weapon = weapon.ToString();
                        analysisResult.Results.Add("The murder weapon is " + weapon + "!");
                    }
                    if (guesser.GetCardStatus(room) == NoStatus && analysisResult.GameDetails.Room == "")
                    {
                        analysisResult.GameDetails.Discoveries++;
                        analysisResult.GameDetails.Room = room.ToString();
                        analysisResult.Results.Add("The murder location is " + room + "!");
                    }
                }
            }

            analysisResult.Players = players;
            analysisResult.GameDetails = gd;
        }

        //this method does some card counting to determine if we should set the
        //rest of a player's cards's statuses to "No"
        public void PlayerCardNumberAnalysis(ref AnalysisResult analysisResult)
        {
            List<CluePlayer> players = analysisResult.Players;
            //loop through all the players
            for (int i = 0; i < players.Count; i++)
            {
                CluePlayer player = players[i];
                //get the number cards that are unknown for the player
                List<ClueCard> UnknownSuspectCards = (from card in player.Suspects
                                                      where card.Status == PlayerClueCard.StatusValues.Unknown
                                                      select card).ToList<ClueCard>();
                List<ClueCard> UnknownWeaponCards = (from card in player.Weapons
                                                     where card.Status == PlayerClueCard.StatusValues.Unknown
                                                     select card).ToList<ClueCard>();
                List<ClueCard> UnknownRoomCards = (from card in player.Rooms
                                                   where card.Status == PlayerClueCard.StatusValues.Unknown
                                                   select card).ToList<ClueCard>();
                List<ClueCard> KnownSuspectCards = (from card in player.Suspects
                                                    where card.Status == PlayerClueCard.StatusValues.Yes
                                                    select card).ToList<ClueCard>();
                List<ClueCard> KnownWeaponCards = (from card in player.Weapons
                                                   where card.Status == PlayerClueCard.StatusValues.Yes
                                                   select card).ToList<ClueCard>();
                List<ClueCard> KnownRoomCards = (from card in player.Rooms
                                                 where card.Status == PlayerClueCard.StatusValues.Yes
                                                 select card).ToList<ClueCard>();
                int unknownCardSum = UnknownSuspectCards.Count + UnknownWeaponCards.Count + UnknownRoomCards.Count;
                int knownCardSum = KnownSuspectCards.Count + KnownWeaponCards.Count + KnownRoomCards.Count;

                //if we already know all the player's cards
                //set the rest of the cards to "no" (as long as there is at least one unknown card)
                if (knownCardSum == player.CardCount && unknownCardSum > 0)
                {
                    foreach (ClueCard card in UnknownSuspectCards)
                    {
                        player.SetCardStatus(card, PlayerClueCard.StatusValues.No);
                    }
                    foreach (ClueCard card in UnknownWeaponCards)
                    {
                        player.SetCardStatus(card, PlayerClueCard.StatusValues.No);
                    }
                    foreach (ClueCard card in UnknownRoomCards)
                    {
                        player.SetCardStatus(card, PlayerClueCard.StatusValues.No);
                    }
                    analysisResult.Results.Add("You now know all of " + player.Name + "'s cards.");
                }
                //if there just happens to be a less than or equal to number of unknown cards
                //to the number the player's cards, the unknown card sum == the number of cards
                //that the player has and we don't know and the unknownCardSum > 0,
                //then set those cards' statuses to yes, and everyone else's cards status to no.
                else if (unknownCardSum <= player.CardCount &&
                    unknownCardSum == player.CardCount - knownCardSum &&
                    unknownCardSum > 0)
                {
                    foreach (ClueCard card in UnknownSuspectCards)
                    {
                        SetPlayerHasOthersNo(i, players, card);
                        analysisResult.GameDetails.Discoveries++;
                        analysisResult.Results.Add(player.Name + " has " + card.CardName + ".");
                    }
                    foreach (ClueCard card in UnknownWeaponCards)
                    {
                        SetPlayerHasOthersNo(i, players, card);
                        analysisResult.GameDetails.Discoveries++;
                        analysisResult.Results.Add(player.Name + " has the " + card.CardName + ".");
                    }
                    foreach (ClueCard card in UnknownRoomCards)
                    {
                        SetPlayerHasOthersNo(i, players, card);
                        analysisResult.GameDetails.Discoveries++;
                        analysisResult.Results.Add(player.Name + " has " + card.CardName + ".");
                    }
                    analysisResult.Results.Add("You now know all of " + player.Name + "'s cards.");
                }


                //if there are missing cards for the current player, and there is a card 
                //that no one has except that player and the murder item of that category is already known,
                //then the current player must have that card.
                if (MissingCardCount(player) > 0)
                {
                    List<ClueCard> applicableCards = new List<ClueCard>();


                    //if the suspect is not null (it has been found) add the unknown suspect cards to the applicable cards
                    if (analysisResult.GameDetails.Suspect != "")
                    {
                        UnknownSuspectCards = (from card in player.Suspects
                                               where card.Status == PlayerClueCard.StatusValues.Unknown
                                               select card).ToList<ClueCard>();
                        applicableCards.AddRange(UnknownSuspectCards);
                    }

                    //if the weapon is not null (it has been found) add the unknown weapon cards to the applicable cards
                    if (analysisResult.GameDetails.Weapon != "")
                    {
                        UnknownWeaponCards = (from card in player.Weapons
                                              where card.Status == PlayerClueCard.StatusValues.Unknown
                                              select card).ToList<ClueCard>();

                        applicableCards.AddRange(UnknownWeaponCards);
                    }

                    //if the room is not null (it has been found) add the unknown room cards to the applicable cards
                    if (analysisResult.GameDetails.Room != "")
                    {
                        UnknownRoomCards = (from card in player.Rooms
                                            where card.Status == PlayerClueCard.StatusValues.Unknown
                                            select card).ToList<ClueCard>();

                        applicableCards.AddRange(UnknownRoomCards);
                    }

                    //for each of the applicable cards, loop through all the players
                    for (int j = 0; j < applicableCards.Count; j++)
                    {
                        bool someoneUnknownOrYes = false;
                        for (int k = 0; k < analysisResult.Players.Count; k++)
                        {
                            //if we are looking at the same player, go to the next iteration of the loop
                            if (player == analysisResult.Players[k])
                            {
                                continue;
                            }
                            //if the current player has the card, or the card status is set to unknown, set the flag to true and exit out of the loop
                            if (analysisResult.Players[k].CardStatusYes(applicableCards[j]) ||
                            analysisResult.Players[k].CardStatusUnknown(applicableCards[j]))
                            {
                                someoneUnknownOrYes = true;
                                break;
                            }
                        }
                        //if no one else has the card, set the player to have the card and add that result to the analysis results
                        if (!someoneUnknownOrYes)
                        {
                            player.SetCardStatus(applicableCards[j], PlayerClueCard.StatusValues.Yes);
                            analysisResult.Results.Add(GetCardResult(applicableCards[j], player));
                        }
                    }
                }
            }

            analysisResult.Players = players;
        }

        //General idea behind finding the special card sets:
        //If a player has two cards we don't know what are, and that
        //player shows a card on two completely different sets of cards that player
        //(cards that we don't know if the player has) then we know that that player
        //has one card from those two sets, and doesn't have any of the other possible
        //cards.
        //this method gets the list of players inbetween the Guesser in the guess and the Responder
        private List<CluePlayer> PlayersInbetween(int start, int end, List<CluePlayer> players)
        {
            if (end == -1) //no one responded, so all the other players besides starting player should be outputted
            {
                List<CluePlayer> output = [.. players];
                output.RemoveAt(start);
                return output;
            }
            else
            {
                List<CluePlayer> output = new List<CluePlayer>();
                int idx = start + 1; //start at the player after the starting player
                if (start == players.Count - 1) //if the player is at the end of the list of players, then start at idx 0
                {
                    idx = 0;
                }
                //while we are not at the first player and not at the last player
                while (idx != start && idx != end)
                {
                    output.Add(players[idx]); //add player to output list
                    idx++;
                    if (idx > players.Count - 1) //if overstepping the boundaries of the list set idx back to 0
                    {
                        idx = 0;
                    }
                }
                return output;
            }
        }

        //Handles when a room card discovery happens (when it is figured out that a room was shown in a guess)
        private void RoomDiscoveryHandler(ref AnalysisResult analysisResult, ref List<CluePlayer> players, ClueGuess guess)
        {
            CluePlayer? responder = guess.Responder != -1 ? players[guess.Responder] : null;
            RoomCard room = guess.Room;

            //as long as the responder doesn't already have the card and the responder is not null
            if (responder != null && !responder.CardStatusYes(room))
            {
                SetPlayerHasOthersNo(guess.Responder, players, room);
                analysisResult.GameDetails.Discoveries++;
                guess.ShownCardByDiscovery = true;
                analysisResult.Results.Add(responder + " has the " + room + "."); //output results
            }
        }

        //takes all the players passed in and sets the card status to passed card status.
        private void SetAllPlayersCardStatus(ref List<CluePlayer> players, ClueCard card, PlayerClueCard.StatusValues status)
        {
            foreach (CluePlayer player in players)
            {
                player.SetCardStatus(card, status);
            }
        }

        //sets for all players except for one player a card's status to no. The other player's card to yes.
        private List<CluePlayer> SetPlayerHasOthersNo(int player, List<CluePlayer> players, ClueCard card)
        {
            if (MissingCardCount(players[player]) != 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (i == player)
                    {
                        players[player].SetCardStatus(card, PlayerClueCard.StatusValues.Yes); //set the selected player to have the card
                    }
                    else
                    {
                        players[i].SetCardStatus(card, PlayerClueCard.StatusValues.No); //set the rest to not have the card
                    }
                }
            }
            return players;
        }

        //Handles when a suspect card discovery happens (when it is figured out that a suspect was shown in a guess)
        private void SuspectDiscoveryHandler(ref AnalysisResult analysisResult, ref List<CluePlayer> players, ClueGuess guess)
        {
            CluePlayer? responder = guess.Responder != -1 ? players[guess.Responder] : null;
            SuspectCard suspect = guess.Suspect;

            //as long as the responder doesn't already have the card and the responder is not null
            if (responder != null && !responder.CardStatusYes(suspect))
            {
                SetPlayerHasOthersNo(guess.Responder, players, suspect);
                analysisResult.GameDetails.Discoveries++;
                guess.ShownCardByDiscovery = true;
                analysisResult.Results.Add(responder + " has " + suspect + "."); //output results
            }
        }

        //this method updates the special card sets for each user to remove cards that do not need to be in there.
        //For example, if player1 from other analysis is found to have the wrench, then all the other players 
        //do not need to have that card in their special card sets.
        //Additionally, this method will remove card sets if there are no cards in them.
        private void UpdateSpecialCardSet(ref AnalysisResult analysisResult)
        {
            List<CluePlayer> players = analysisResult.Players;

            //loop through all the players (except for the main program user)
            for (int i = 1; i < players.Count; i++)
            {
                CluePlayer player = players[i];
                List<List<ClueCard>> cardSetsToRemove = new List<List<ClueCard>>();

                //loop through each of the sets of cards for the current player
                for (int j = 0; j < player.SpecialCardSet.Count(); j++)
                {
                    //get the current player's sepcial card set
                    List<ClueCard> currentSet = player.SpecialCardSet.Sets[j];

                    //list of cards to remove from the current set
                    List<ClueCard> cardsToRemove = new List<ClueCard>();

                    //loop through all the cards in that set
                    for (int k = 0; k < currentSet.Count; k++)
                    {
                        ClueCard card = currentSet[k];
                        if (player.GetCardStatus(card) == PlayerClueCard.StatusValues.No || player.GetCardStatus(card) == PlayerClueCard.StatusValues.Yes)
                        {
                            cardsToRemove.Add(card);
                        }
                        if (AnyoneHasExcept(i, players, card))
                        {
                            cardsToRemove.Add(card);
                        }
                    }

                    //loop through all the cards to remove and remove them from currentSet
                    foreach (ClueCard card in cardsToRemove)
                    {
                        currentSet.Remove(card);
                    }

                    //if the set doesn't have any cards, put in into the remove set list
                    if (currentSet.Count == 0)
                    {
                        cardSetsToRemove.Add(currentSet);
                    }
                }

                //remove the sets with no cards (remove set list)
                foreach (List<ClueCard> set in cardSetsToRemove)
                {
                    player.SpecialCardSet.Sets.Remove(set);
                }
            }
        }

        //Handles when a weapon card discovery happens (when it is figured out that a weapon was shown in a guess)
        private void WeaponDiscoveryHandler(ref AnalysisResult analysisResult, ref List<CluePlayer> players, ClueGuess guess)
        {
            CluePlayer? responder = guess.Responder != -1 ? players[guess.Responder] : null;
            WeaponCard weapon = guess.Weapon;

            //as long as the responder doesn't already have the card and the responder is not null
            if (responder != null && !responder.CardStatusYes(weapon))
            {
                SetPlayerHasOthersNo(guess.Responder, players, weapon);
                analysisResult.GameDetails.Discoveries++;
                guess.ShownCardByDiscovery = true;
                analysisResult.Results.Add(responder + " has the " + weapon + "."); //output results
            }
        }

        #endregion Methods
    }
}