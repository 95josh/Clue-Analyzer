using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms.Design;
using Dapper;
using System.Data.SQLite;
using System.ComponentModel.Design;
using System.Numerics;
using System.Data.Common;

namespace Clue_Analyzer
{
    public class SQLiteClueStorageHandler
    {
        public string Filename { get; set; }

        public SQLiteClueStorageHandler(string filename)
        {
            Filename = filename;
        }

        public async Task SaveClueGuesses(List<ClueGuess> guesses)
        {
            await VerifyClueSQLiteTables();
            try
            {
                using (IDbConnection db = new SQLiteConnection(GetConnectionString()))
                {
                    db.Open();

                    using (var transaction = db.BeginTransaction())
                    {
                        try
                        {
                            string sql = "delete from Guesses"; //delete all the previous guesses
                            var res = await db.QueryAsync(sql);

                            string insertSQL = "insert into guesses (Suspect, Weapon, Room, Guesser, Responder, ShownCard, " +
                                "ShownCardByDiscovery) VALUES (@Suspect, @Weapon, @Room, @Guesser, @Responder, @ShownCard, " +
                                "@ShownCardByDiscovery);";

                            foreach (var guess in guesses)
                            {
                                DynamicParameters dp = new DynamicParameters();
                                dp.Add("Suspect", guess.Suspect.CardNameIdx);
                                dp.Add("Weapon", guess.Weapon.CardNameIdx);
                                dp.Add("Room", guess.Room.CardNameIdx);
                                dp.Add("Guesser", guess.Guesser);
                                dp.Add("Responder", guess.Responder);
                                dp.Add("ShownCard", guess.ShownCard == null ? "null" : guess.ShownCard.CardType + "," + guess.ShownCard.CardNameIdx);
                                dp.Add("ShownCardByDiscovery", guess.ShownCardByDiscovery == false ? 0 : 1);

                                var insert = await db.ExecuteAsync(insertSQL, dp);
                            }
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error occurred saving guess data to disk. \r\n" + ex.Message);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred saving guess data to disk. \r\n" + ex.Message);
            }
        }

        public async Task<List<ClueGuess>> LoadClueGuesses()
        {
            await VerifyClueSQLiteTables();
            try
            {
                using (IDbConnection db = new SQLiteConnection(GetConnectionString()))
                {
                    string sql = "select * from Guesses";
                    //load all the guesses in!
                    var res = await db.QueryAsync(sql);

                    List<ClueGuess> output = new List<ClueGuess>();
                    foreach (var guess in res)
                    {
                        if (guess != null)
                        {
                            //ClueGuess newCG = new ClueGuess();

                            SuspectCard suspect = new SuspectCard((int)guess.Suspect);
                            WeaponCard weapon = new WeaponCard((int)guess.Weapon);
                            RoomCard room = new RoomCard((int)guess.Room);
                            int Guesser = (int)guess.Guesser;
                            int Responder = (int)guess.Responder;
                            ClueCard ShownCard;
                            bool ShownCardByDiscovery;

                            //get the shown card
                            if (guess.ShownCard == "null")
                            {
                                ShownCard = null;
                            }
                            else
                            {
                                string[] split = guess.ShownCard.Split(',');
                                if (split[0].Trim() == "Suspect")
                                {
                                    ShownCard = new SuspectCard(int.Parse(split[1].Trim()));
                                }
                                else if (split[0].Trim() == "Weapon")
                                {
                                    ShownCard = new WeaponCard(int.Parse(split[1].Trim()));
                                }
                                else
                                {
                                    ShownCard = new RoomCard(int.Parse(split[1].Trim()));
                                }
                            }

                            //get if the card was shown by discovery
                            if (guess.ShownCardByDiscovery == 0) ShownCardByDiscovery = false;
                            else ShownCardByDiscovery = true;

                            //create guess

                            output.Add(new ClueGuess(suspect, weapon, room, Guesser, Responder, ShownCard, ShownCardByDiscovery));
                        }
                    }

                    return output;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred loading guess data from disk. \r\n" + ex.Message);
                return new List<ClueGuess>();
            }

        }

        public async Task SaveCluePlayers(List<CluePlayer> players)
        {
            await VerifyClueSQLiteTables();
            try
            {
                using (IDbConnection db = new SQLiteConnection(GetConnectionString()))
                {
                    db.Open();

                    using (var transaction = db.BeginTransaction())
                    {
                        try
                        {
                            string sql = "delete from Players"; //delete all the previous players
                            var res = await db.QueryAsync(sql);

                            string insertSQL = "insert into Players (Name, Suspects, Weapons, Rooms, CardCount, SpecialCardSet)" +
                                " VALUES (@Name, @Suspects, @Weapons, @Rooms, @CardCount, @SpecialCardSet);";

                            foreach (var player in players)
                            {
                                DynamicParameters dp = new DynamicParameters();
                                dp.Add("Name", player.Name);
                                dp.Add("Suspects", PlayerCardListToString(player.Suspects));
                                dp.Add("Weapons", PlayerCardListToString(player.Weapons));
                                dp.Add("Rooms", PlayerCardListToString(player.Rooms));
                                dp.Add("CardCount", player.CardCount);
                                dp.Add("SpecialCardSet", player.SpecialCardSet.ToString());

                                var insert = await db.ExecuteAsync(insertSQL, dp);
                            }
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error occurred saving player data to disk. \r\n" + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred saving player data to disk. \r\n" + ex.Message);
            }

        }

        public async Task<List<CluePlayer>> LoadCluePlayers()
        {
            await VerifyClueSQLiteTables();
            try
            {
                using (IDbConnection db = new SQLiteConnection(GetConnectionString()))
                {
                    string sql = "select * from Players";
                    //load all the guesses in!
                    var res = await db.QueryAsync(sql);

                    List<CluePlayer> output = new List<CluePlayer>();
                    foreach (var player in res)
                    {
                        if (player != null)
                        {

                            CluePlayer newPlayer = new CluePlayer(player.Name,
                                StringToPlayerCardSuspectList(player.Suspects), StringToPlayerCardWeaponList(player.Weapons),
                                StringToPlayerCardRoomList(player.Rooms), (int)player.CardCount, SpecialCardsBucket.FromString(player.SpecialCardSet));

                            output.Add(newPlayer);
                        }
                    }

                    return output;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred loading player data from disk. \r\n" + ex.Message);
                return new List<CluePlayer>();
            }
        }

        public async Task SaveGameInfo(GameDetails details)
        {
            await VerifyClueSQLiteTables();
            try
            {
                using (IDbConnection db = new SQLiteConnection(GetConnectionString()))
                {
                    db.Open();

                    using (var transaction = db.BeginTransaction())
                    {
                        try
                        {
                            string sql = "delete from GameInfo"; //delete all data from GameInfo
                            var res = await db.QueryAsync(sql);

                            string insertSQL = "insert into GameInfo (Suspect, Weapon, Room, Discoveries, Cards)" +
                                " VALUES (@Suspect, @Weapon, @Room, @Discoveries, @Cards);";

                            var insert = await db.ExecuteAsync(insertSQL, details);
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error occurred saving game info to disk. \r\n" + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred saving game info to disk. \r\n" + ex.Message);
            }
        }

        public async Task<GameDetails> LoadGameInfo()
        {
            await VerifyClueSQLiteTables();
            try
            {
                using (IDbConnection db = new SQLiteConnection(GetConnectionString()))
                {
                    string sql = "select * from GameInfo";

                    //load the game info in!
                    var res = await db.QuerySingleAsync<GameDetails>(sql);
                    
                    return res;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred loading game info from disk. \r\n" + ex.Message);
                return new GameDetails();
            }
        }

        public async Task SaveEverything(List<ClueGuess> guesses, List<CluePlayer> players, GameDetails murderdetails)
        {
            await Task.WhenAll(SaveClueGuesses(guesses), SaveCluePlayers(players), SaveGameInfo(murderdetails));
        }

        private string GetConnectionString()
        {
            return @"Data Source=" + Filename + ";";
        }

        private async Task VerifyClueSQLiteTables()
        {
            //check for existance of appropriate tables in the file
            using (IDbConnection idb = new SQLiteConnection(GetConnectionString()))
            {
                string[] tableNames = ["Guesses", "Players", "GameInfo"];
                string baseQuery = "select * from sqlite_master where type = 'table' and name = @TableName";
                string baseColumnQuery = "pragma table_info(";
                List<TableColumn> guessColumns = [
                    new TableColumn("gid", "INTEGER", 1, "", 1),
                    new TableColumn("Suspect", "INTEGER", 0, "", 0),
                    new TableColumn("Weapon", "INTEGER", 0, "", 0),
                    new TableColumn("Room", "INTEGER", 0, "", 0),
                    new TableColumn("Guesser", "INTEGER", 0, "", 0),
                    new TableColumn("Responder", "INTEGER", 0, "", 0),
                    new TableColumn("ShownCard", "TEXT", 0, "", 0),
                    new TableColumn("ShownCardByDiscovery", "INTEGER", 0, "0", 0)
                    ];
                List<TableColumn> playerColumns = [
                    new TableColumn("pid", "INTEGER", 1, "", 1),
                    new TableColumn("Name", "TEXT", 0, "", 0),
                    new TableColumn("Suspects", "TEXT", 0, "", 0),
                    new TableColumn("Weapons", "TEXT", 0, "", 0),
                    new TableColumn("Rooms", "TEXT", 0, "", 0),
                    new TableColumn("CardCount", "INTEGER", 1, "", 0),
                    new TableColumn("SpecialCardSet", "TEXT", 0, "", 0)
                    ];
                List<TableColumn> gameInfoColumns = [
                    new TableColumn("giID", "INTEGER", 1, "", 1),
                    new TableColumn("Suspect", "TEXT", 0, "", 0),
                    new TableColumn("Weapon", "TEXT", 0, "", 0),
                    new TableColumn("Room", "TEXT", 0, "", 0),
                    new TableColumn("Discoveries", "INTEGER", 0, "", 0),
                    new TableColumn("Cards", "TEXT", 0, "", 0)
                    ];
                List<List<TableColumn>> tableColumns = [guessColumns, playerColumns, gameInfoColumns];
                string[] createTableSQLs = [
                    "CREATE TABLE \"Guesses\" (\"gid\" INTEGER NOT NULL,\"Suspect\" INTEGER,\"Weapon\" " +
                    "INTEGER, \"Room\" INTEGER, \"Guesser\" INTEGER,\"Responder\" INTEGER,\"ShownCard\" TEXT,\"" +
                    "ShownCardByDiscovery\" INTEGER DEFAULT 0, PRIMARY KEY(\"gid\" AUTOINCREMENT));",

                    "CREATE TABLE \"Players\" (\"pid\"INTEGER NOT NULL, \"Name\" TEXT, " +
                    "\"Suspects\" TEXT, \"Weapons\" TEXT, \"Rooms\" TEXT, \"CardCount\" INTEGER NOT NULL, " +
                    "\"SpecialCardSet\" TEXT, PRIMARY KEY(\"pid\" AUTOINCREMENT));",

                    "CREATE TABLE \"GameInfo\" (\"giID\" INTEGER NOT NULL,\"Suspect\" " +
                    "TEXT, \"Weapon\" TEXT, \"Room\" TEXT, \"Discoveries\" INTEGER, " +
                    "\"Cards\" TEXT, " + 
                    "PRIMARY KEY(\"giID\" AUTOINCREMENT));"

                    ];

                //loop through all the table names that should be there
                for (int i = 0; i < tableNames.Length; i++)
                {
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("TableName", tableNames[i]);
                    //check if table exists, if not, create it.
                    var res = await idb.QueryAsync(baseQuery, dp);
                    if (res.FirstOrDefault() == null)
                    {
                        await idb.QueryAsync(createTableSQLs[i]);
                    }
                    else //table exists, now check to make sure the table has the right column names
                    {
                        var res2 = await idb.QueryAsync<TableColumn>(baseColumnQuery + tableNames[i] + ")");
                        List<TableColumn> currentColumns = res2.ToList();

                        List<TableColumn> nonExistantColumns = tableColumns[i].Where(item => !currentColumns.Contains(item)).ToList();

                        //if there are some columns that should exist but don't
                        if (nonExistantColumns.Count() > 0)
                        {
                            foreach(TableColumn col in nonExistantColumns)
                            {
                                await idb.QueryAsync(col.GetStatementAdd(tableNames[i])); //add the column to the database
                            }
                        }
                    }

                    

                }

            }

        }

        private string cardTypesToString()
        {
            string output = "";
            foreach(string cardname in ClueCard.Suspects)
            {
                output += cardname + ",";
            }
            output = output.Trim(',');
            output += ";";
            foreach (string cardname in ClueCard.Weapons)
            {
                output += cardname + ",";
            }
            output = output.Trim(',');
            output += ";";
            foreach (string cardname in ClueCard.Rooms)
            {
                output += cardname + ",";
            }
            output = output.Trim(',');
            return output;
        }

        private string PlayerCardListToString<T>(List<T> cards) where T: PlayerClueCard
        {
            StringBuilder sb = new StringBuilder();
            foreach (T card in cards)
            {
                sb.Append(card.CardType + ";" + card.CardNameIdx + ";" + card.Status + ";" + card.StatusByDiscovery.ToString() + ",");
            }
            return sb.ToString().Trim(',');
        }

        private List<PlayerSuspectCard> StringToPlayerCardSuspectList(string input)
        {
            List<PlayerSuspectCard> output = new List<PlayerSuspectCard>();
            string[] firstSplit = input.Split(',');
            foreach (string card in firstSplit)
            {
                string[] secondSplit = card.Split(';');

                if (Enum.TryParse(typeof(PlayerClueCard.StatusValues), secondSplit[2].Trim(), out var temp))
                {
                    bool thisbool = bool.Parse(secondSplit[3].Trim());
                    PlayerSuspectCard outputItem = new PlayerSuspectCard(int.Parse(secondSplit[1].Trim()), (PlayerClueCard.StatusValues)temp, thisbool);
                    output.Add(outputItem);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Status", "Card status value was invalid");
                }
                
            }
            return output;

        }

        private List<PlayerWeaponCard> StringToPlayerCardWeaponList(string input)
        {
            List<PlayerWeaponCard> output = new List<PlayerWeaponCard>();
            string[] firstSplit = input.Split(',');
            foreach (string card in firstSplit)
            {
                string[] secondSplit = card.Split(';');

                if (Enum.TryParse(typeof(PlayerClueCard.StatusValues), secondSplit[2].Trim(), out var temp))
                {
                    bool thisbool = bool.Parse(secondSplit[3].Trim());
                    PlayerWeaponCard outputItem = new PlayerWeaponCard(int.Parse(secondSplit[1].Trim()), (PlayerClueCard.StatusValues)temp, thisbool);
                    output.Add(outputItem);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Status", "Card status value was invalid");
                }
            }
            return output;

        }

        private List<PlayerRoomCard> StringToPlayerCardRoomList(string input)
        {
            List<PlayerRoomCard> output = new List<PlayerRoomCard>();
            string[] firstSplit = input.Split(',');
            foreach (string card in firstSplit)
            {
                string[] secondSplit = card.Split(';');

                if (Enum.TryParse(typeof(PlayerClueCard.StatusValues), secondSplit[2].Trim(), out var temp))
                {
                    bool thisbool = bool.Parse(secondSplit[3].Trim());
                    PlayerRoomCard outputItem = new PlayerRoomCard(int.Parse(secondSplit[1].Trim()), (PlayerClueCard.StatusValues)temp, thisbool);
                    output.Add(outputItem);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Status", "Card status value was invalid");
                }
            }
            return output;

        }
    }
}
