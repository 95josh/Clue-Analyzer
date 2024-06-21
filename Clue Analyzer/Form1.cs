using System.Data.SqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Policy;
using System.Transactions;
using System.Numerics;

namespace Clue_Analyzer
{
    public partial class Form1 : Form
    {
        //game data
        public static List<CluePlayer> Players = new List<CluePlayer>();
        public static List<ClueGuess> Guesses = new List<ClueGuess>();
        public GameDetails gameDetails = new GameDetails();

        //lists of controls
        private List<LinkLabel> playerLinks;
        private static List<ViewPlayerForm> viewPlayerForms = new List<ViewPlayerForm>(); //dynamically populated as program runs
        private static List<ClueAllCardsForm> clueAllCardsForms = new List<ClueAllCardsForm>(); //dynamically populated as program runs
        private static List<LinkLabel> recentFileLinks = new List<LinkLabel>();
        private static List<ToolStripMenuItem> recentFileMenuLinks = new List<ToolStripMenuItem>();

        //static transfer variables (transfer from other forms)
        public static ClueGuess? transfer = null;
        public static string newGameLoc = "";

        //file and saving variables
        private bool saved = true; //keeps track if the file has been fully saved or not.
        private string fileLoc = ""; //the game file location
        private string fileName = ""; //the name of the file

        //preferences
        private List<Color> statusColors = new List<Color>(); //color preferences
        private List<string> recentFiles = new List<string>(); //list of recent files

        //misc objects
        ClueAnalysisEngine analysisEngine;


        public Form1()
        {
            InitializeComponent();
            //Players = new List<CluePlayer> { new CluePlayer("Joshua Stahl", 6), new CluePlayer("Jakin Bacon", 5), new CluePlayer("Gracie Bean", 5), new CluePlayer("Laura", 5) };

            //initialize control lists
            playerLinks = [lnklPlayer1, lnklPlayer2, lnklPlayer3, lnklPlayer4, lnklPlayer5, lnklPlayer6];
            recentFileLinks = [lnkLRecentGame1, lnkLRecentGame2, lnkLRecentGame3, lnkLRecentGame4, lnkLRecentGame5];
            recentFileMenuLinks = [recentGame1ToolStripMenuItem, recentGame2ToolStripMenuItem, recentGame3ToolStripMenuItem,
                                    recentGame4ToolStripMenuItem, recentGame5ToolStripMenuItem];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pnlStartup.Left = 0;
            //pnlStartup.Top = 64;
            LoadRecentFiles();
            LoadColorPreferences();
            pnlStartup.Dock = DockStyle.Fill;
            pnlStartup.Visible = true;
            AutoScroll = true;
        }

        //***************************************** METHODS *****************************************

        //this closes all the other open forms, usually triggered when a new game is started or opened
        private void CloseOtherForms()
        {
            for (int i = 0; i < viewPlayerForms.Count; i++)
            {
                viewPlayerForms[i].Close();
            }
            viewPlayerForms.Clear();
            for (int i = 0; i < clueAllCardsForms.Count; i++)
            {
                clueAllCardsForms[i].Close();
            }
            clueAllCardsForms.Clear();
        }

        //this disables menus (so that they don't work if there isn't a game loaded)
        private void DisableMenus(bool set)
        {
            if (set)
            {
                gameToolStripMenuItem.Enabled = false;
                newGuessToolStripMenuItem.Enabled = false;
                editSelectedGuessToolStripMenuItem.Enabled = false;
                analyzeToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
            }
            else
            {
                gameToolStripMenuItem.Enabled = true;
                newGuessToolStripMenuItem.Enabled = true;
                editSelectedGuessToolStripMenuItem.Enabled = true;
                analyzeToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
            }
        }

        //this takes an index of a guess and passes it to the ClueGuesInputForm to start the edit process
        //afterwards, resets the discoveries if need be.
        private void EditGuess(int idx)
        {
            ClueGuess g = Guesses[idx];
            ClueGuessInputForm cgif = new ClueGuessInputForm(ClueGuessInputForm.FormMode.Edit, g);
            cgif.ShowDialog();
            if (transfer != null)
            {
                Guesses[idx] = transfer;
                transfer = null;
                ResetDiscoveries();
            }
        }

        //this gets the right cell tool tip value for the guesses table
        private string GetCellToolTipValue(string search)
        {
            //find the right card we are looking for
            ClueCard? cc = null;
            foreach (string s in ClueCard.Suspects)
            {
                if (search == s)
                {
                    cc = new SuspectCard(search);
                    break;
                }
            }
            if (cc == null)
            {
                foreach (string s in ClueCard.Weapons)
                {
                    if (search == s)
                    {
                        cc = new WeaponCard(search);
                        break;
                    }
                }
            }
            if (cc == null)
            {
                foreach (string s in ClueCard.Rooms)
                {
                    if (search == s)
                    {
                        cc = new RoomCard(search);
                        break;
                    }
                }
            }

            //now search the players to see if anyone has it
            string output = "";
            if (cc == null)
            {
                return output;
            }
            else
            {
                for (int i = 0; i < Players.Count; i++)
                {
                    if (Players[i].CardStatusYes(cc))
                    {
                        output = Players[i].Name + " has this card";
                        break;
                    }
                    else if (Players[i].GetCardStatus(cc) == PlayerClueCard.StatusValues.Unknown)
                    {
                        output = "Unknown who has this card";
                    }
                }
                if (output == "") //if still no one has this card
                {
                    if (cc.CardType == "Room")
                    {
                        output = "This is the murder location";
                    }
                    else if (cc.CardType == "Weapon")
                    {
                        output = "This is the murder weapon";
                    }
                    else
                    {
                        output = "This is the murderer";
                    }
                }
            }
            return output;
        }

        //preforms analysis, result retrieval, and result display for guesses/players etc.
        private async Task HandleAnalysis()
        {
            //if analysisEngine is null, create it
            analysisEngine ??= new ClueAnalysisEngine(Guesses, Players, gameDetails);

            //refresh the analysis engine with new data
            analysisEngine.Guesses = Guesses;
            analysisEngine.Players = Players;
            analysisEngine.GameDetails = gameDetails;

            //analyse
            AnalysisResult anResult = await analysisEngine.Analyze();
            Guesses = anResult.Guesses;
            Players = anResult.Players;
            gameDetails = anResult.GameDetails;

            //display results if necessary
            if (anResult.Results.Count != 0)
            {
                string output = "Discoveries: \r\n";
                foreach (string res in anResult.Results)
                {
                    output += "\r\n" + res;
                }
                MessageBox.Show(output, "Analysis Results");
            }

            //refresh screen details
            Saved(false);
            PopulateGameStats();
            PopulateGuessesTable(Guesses);
            UpdateOtherForms();
            PopulatePlayers();
        }

        //this handles the list of recent files. Saves and keeps them up to date.
        private void HandleRecentFiles(string dir)
        {
            //if new file is already in recentfiles, move to top of list
            if (recentFiles.Contains(dir))
            {
                recentFiles.Remove(dir);
                recentFiles.Insert(0, dir);
            }
            else
            {
                recentFiles.Insert(0, dir); //add new file at front instead of at end
                while (recentFiles.Count > 5)
                {
                    recentFiles.RemoveAt(5); //remove the last file at the end of the list
                }
            }

            //Save recent files to settings file
            string output = "";
            foreach (string s in recentFiles)
            {
                output += s + ";";
            }
            output = output.Trim(';'); //get rid of trailing ;

            UpdateRecentFileViews();
            Properties.Settings.Default["recentFiles"] = output;
            Properties.Settings.Default.Save();
        }

        //this loads color sets from the app setting storage
        private void LoadColorPreferences()
        {
            List<Color> colors = [
                (Color)Properties.Settings.Default["yesColor"],
                (Color)Properties.Settings.Default["noColor"],
                (Color)Properties.Settings.Default["unknownColor"]
            ];
            statusColors = colors;
        }

        //this method loads all the game information into the program, given a path to a file e.g C:/mygame.cg
        private async Task LoadGame(string file)
        {
            if (file != "")
            {
                if (!File.Exists(file))
                {
                    DialogResult dr = MessageBox.Show("This file does not currently exist. " +
                        "Do you want to remove it from the recent game list?", "File does not exist",
                        MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.Yes)
                    {
                        RemoveRecentFile(file);
                    }
                    if (file == fileLoc) //if tried to reopen current file
                    {
                        //reset game location
                        fileName = "Untitled";
                        fileLoc = "";
                        PopulateGameStats();
                        Saved(false);
                    }
                    return; //cancel the file open because the file does not exist
                }
                else
                {
                    ToggleCursor();
                    SQLiteClueStorageHandler csh = new SQLiteClueStorageHandler(file);
                    gameDetails = await csh.LoadGameInfo();
                    LoadGameCardNames(gameDetails);
                    Players = await csh.LoadCluePlayers();
                    Guesses = await csh.LoadClueGuesses();


                    //set file variables
                    fileLoc = file;
                    fileName = Path.GetFileName(file);

                    //set up screen
                    PopulatePlayers();
                    PopulateGameStats();
                    PopulateGuessesTable(Guesses);
                    Saved(true);
                    DisableMenus(false);
                    HandleRecentFiles(file);
                    CloseOtherForms();
                    pnlStartup.Visible = false;
                    ToggleCursor();
                }
            }
        }

        //loads in the card names from the game details
        public static void LoadGameCardNames(GameDetails gd)
        {
            if (gd.Cards != "" && gd.Cards != null)
            {
                string[] split1 = gd.Cards.Split(';');

                string input = split1[0];
                List<string> suspects = new List<string>();
                string[] split2 = input.Split(',');
                foreach (string s in split2)
                {
                    suspects.Add(s);
                }

                input = split1[1];
                List<string> weapons = new List<string>();
                split2 = input.Split(',');
                foreach (string s in split2)
                {
                    weapons.Add(s);
                }

                input = split1[2];
                List<string> rooms = new List<string>();
                split2 = input.Split(',');
                foreach (string s in split2)
                {
                    rooms.Add(s);
                }

                ClueCard.Suspects = suspects;
                ClueCard.Weapons = weapons;
                ClueCard.Rooms = rooms;
            }
        }

        //this handles loading recent files from app setting storage
        private void LoadRecentFiles()
        {
            string input = (string)Properties.Settings.Default["recentFiles"];
            string[] split = input.Split(';');
            List<string> dirs = new List<string>();
            foreach (string s in split)
            {
                if (s != string.Empty)
                {
                    dirs.Add(s.Trim());
                }
            }

            recentFiles = dirs;
            UpdateRecentFileViews();
        }

        //takes a clue cards form off of the clue cards form list, so that it isn't tried to be closed with CloseOtherForms()
        public void PopClueAllCardsForm(ClueAllCardsForm cacf)
        {
            clueAllCardsForms.Remove(cacf);
        }

        //takes a view player form off of the clue cards form list, so that it isn't tried to be closed with CloseOtherForms()
        public void PopViewPlayerForm(ViewPlayerForm vpf)
        {
            viewPlayerForms.Remove(vpf);
        }

        //this populates the guesses datagridview given a list of guesses
        public void PopulateGuessesTable(List<ClueGuess> guesses)
        {
            //dgvGuesses.DataSource
            DataTable dt = new DataTable();

            dt.Columns.Add("Suspect");
            dt.Columns.Add("Weapon");
            dt.Columns.Add("Room");
            dt.Columns.Add("Guesser");
            dt.Columns.Add("Responder");
            dt.Columns.Add("ShownCard");
            dt.Columns.Add("ShownCardByDiscovery");
            foreach (ClueGuess guess in guesses)
            {
                DisplayableClueGuess dcg = DisplayableClueGuess.FromClueGuess(guess, Players);
                dt.Rows.Add(dcg.Suspect, dcg.Weapon, dcg.Room, dcg.Guesser, dcg.Responder, dcg.ShownCard, dcg.ShownCardByDiscovery);
            }
            dgvGuesses.DataSource = dt.DefaultView;
        }

        //updates the game stats area on the main screen
        private void PopulateGameStats()
        {
            lblFileName.Text = fileName;
            toolTip1.SetToolTip(lblFileName, fileName);
            lblNumberOfPlayers.Text = Players.Count.ToString();
            lblNumberOfGuesses.Text = Guesses.Count.ToString();
            lblNumberOfDiscoveries.Text = gameDetails.Discoveries.ToString();

            if (gameDetails.Suspect != "")
            {
                lblMurderDetailsSuspect.Text = gameDetails.Suspect;
                lblMurderDetailsSuspect.ForeColor = statusColors[0];
            }
            else
            {
                lblMurderDetailsSuspect.Text = "N/A";
                lblMurderDetailsSuspect.ForeColor = Color.Black;
            }
            if (gameDetails.Weapon != "")
            {
                lblMurderDetailsWeapon.Text = gameDetails.Weapon;
                lblMurderDetailsWeapon.ForeColor = statusColors[0];
            }
            else
            {
                lblMurderDetailsWeapon.Text = "N/A";
                lblMurderDetailsWeapon.ForeColor = Color.Black;
            }
            if (gameDetails.Room != "")
            {
                lblMurderDetailsRoom.Text = gameDetails.Room;
                lblMurderDetailsRoom.ForeColor = statusColors[0];
            }
            else
            {
                lblMurderDetailsRoom.Text = "N/A";
                lblMurderDetailsRoom.ForeColor = Color.Black;
            }

        }

        //this populates the player list
        public void PopulatePlayers()
        {
            //hide all of the links
            foreach (LinkLabel ll in playerLinks)
            {
                ll.Visible = false;
            }

            //show the right amount of links and change their names
            for (int i = 0; i < Players.Count; i++)
            {
                playerLinks[i].Text = Players[i].Name;
                playerLinks[i].Visible = true;
                toolTip1.SetToolTip(playerLinks[i], "Click to view player information for " + Players[i].Name);
            }
        }

        //takes all the cards that have been discovered by analysis, and resets them back to Unknown
        private async void ResetDiscoveries()
        {
            //reset the guesses and cards for the players, the cards that are 
            //"discovered" by analysis
            foreach (ClueGuess guess in Guesses)
            {
                if (guess.ShownCardByDiscovery)
                {
                    guess.ShownCard = null;
                }
            }

            //loop through all the cards for all players (except user) and set their cards that
            //were found by analysis to Unknown
            for (int i = 1; i < Players.Count; i++)
            {

                //set all the cards to no, as long as StatusByDiscovery is true
                CluePlayer player = Players[i];
                foreach (PlayerClueCard card in player.Suspects)
                {
                    if (card.StatusByDiscovery == true)
                    {
                        card.Status = PlayerClueCard.StatusValues.Unknown;
                    }
                }
                foreach (PlayerClueCard card in player.Weapons)
                {
                    if (card.StatusByDiscovery == true)
                    {
                        card.Status = PlayerClueCard.StatusValues.Unknown;
                    }
                }
                foreach (PlayerClueCard card in player.Rooms)
                {
                    if (card.StatusByDiscovery == true)
                    {
                        card.Status = PlayerClueCard.StatusValues.Unknown;
                    }
                }

                //reset the special cards
                player.SpecialCardSet = new SpecialCardsBucket();

            }

            //reset the game details
            gameDetails = new GameDetails();

            //run analysis on everything
            await HandleAnalysis();
        }

        //removes a recent file from the recent file list
        private void RemoveRecentFile(string dir)
        {
            if (recentFiles.Contains(dir))
            {
                recentFiles.Remove(dir);
                UpdateRecentFileViews();

                //Save recent files to settings file
                string output = "";
                foreach (string s in recentFiles)
                {
                    output += s + ";";
                }
                output = output.Trim(';'); //get rid of trailing ;
                Properties.Settings.Default["recentFiles"] = output;
                Properties.Settings.Default.Save();
            }

        }

        //handles saving the current file (if there is no current file, this calls SaveAs())
        private async Task Save()
        {
            //if for some reason the current file is non-existant
            if (fileLoc == "" || fileName == "")
            {
                await SaveAs();
            }
            else
            {
                ToggleCursor();
                SQLiteClueStorageHandler csh = new SQLiteClueStorageHandler(fileLoc);
                StoreGameCardNames();
                await csh.SaveEverything(Guesses, Players, gameDetails);
                HandleRecentFiles(fileLoc);
                Saved(true);
                ToggleCursor();
            }
        }

        //handles saving the current game as a different one
        private async Task SaveAs()
        {
            saveFileDialog1.InitialDirectory = fileLoc;
            saveFileDialog1.FileName = "game1.cagf";
            DialogResult dr = saveFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                ToggleCursor();
                fileName = Path.GetFileName(saveFileDialog1.FileName);
                fileLoc = saveFileDialog1.FileName;
                SQLiteClueStorageHandler csh = new SQLiteClueStorageHandler(fileLoc);
                StoreGameCardNames();
                await csh.SaveEverything(Guesses, Players, gameDetails);
                HandleRecentFiles(fileLoc);
                PopulateGameStats();
                Saved(true);
                ToggleCursor();
            }
        }

        //sets if the game is fully saved or not
        private void Saved(bool sv)
        {
            saved = sv;
            if (saved)
            {
                Text = "Clue Analyzer - " + fileName;
                saveToolStripMenuItem.Text = "Save Game";
            }
            else
            {
                Text = "Clue Analyzer - " + fileName + " *";
                saveToolStripMenuItem.Text = "Save Game*";
            }
        }

        //this stores the current game's card names into the gameDetails
        private void StoreGameCardNames()
        {
            string output = "";
            foreach (string cardname in ClueCard.Suspects)
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
            gameDetails.Cards = output;
        }

        //this toggles the cursor of the application from spinning to not spinning
        private void ToggleCursor()
        {
            if (Cursor == Cursors.AppStarting)
            {
                Cursor = Cursors.Default;
            }
            else
            {
                Cursor = Cursors.AppStarting;
            }
        }

        //this refreshes all the data in the viewplayerforms and cluecardsforms forms
        private void UpdateOtherForms() //refreshes the data in each of the viewplayerforms and clueallcardsforms
        {
            foreach (ViewPlayerForm vpf in viewPlayerForms)
            {
                vpf.DataRefresh(Players, Guesses, statusColors);
            }
            foreach (ClueAllCardsForm cacf in clueAllCardsForms)
            {
                cacf.DataRefresh(Players, statusColors);
            }
        }

        //This function updates the visible lists of recent files
        private void UpdateRecentFileViews()
        {
            //hide all the recent file links
            foreach (LinkLabel ll in recentFileLinks)
            {
                ll.Visible = false;
            }

            //hide all the recent file menu links
            foreach (ToolStripMenuItem ts in recentFileMenuLinks)
            {
                ts.Visible = false;
            }

            //populate file links and menu links!
            for (int i = 0; i < recentFiles.Count; i++)
            {
                if (recentFiles[i] != string.Empty)
                {
                    string filename = Path.GetFileName(recentFiles[i]);
                    //populate recent link
                    recentFileLinks[i].Text = filename;
                    recentFileLinks[i].Visible = true;

                    //popuate recent menu link
                    recentFileMenuLinks[i].Text = filename;
                    recentFileMenuLinks[i].Visible = true;
                }
            }
        }

        //************************************** EVENT HANDLERS **************************************

        private async void AddNewGuess(object sender, EventArgs e)
        {
            ClueGuessInputForm cgif = new ClueGuessInputForm();
            cgif.ShowDialog();
            if (transfer != null)
            {
                Guesses.Add(transfer);
                PopulateGuessesTable(Guesses);
                UpdateOtherForms();
                Saved(false);
                await HandleAnalysis();
                transfer = null; //reset transfer for next time
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClueAnalyzerAbout caa = new ClueAnalyzerAbout();
            caa.ShowDialog();
        }

        private async void analyzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await HandleAnalysis();
        }

        private void btnEditSelectedGuess(object sender, EventArgs e)
        {
            if (dgvGuesses.SelectedCells.Count > 0)
            {
                EditGuess(dgvGuesses.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("Please select a guess cell first.", "No Guess Selected");
            }
        }

        private void btnViewCardsStatuses_Click(object sender, EventArgs e)
        {
            if (clueAllCardsForms.Count > 0)
            {
                clueAllCardsForms[0].Focus();
            }
            else
            {
                ClueAllCardsForm cacf = new ClueAllCardsForm(Players, statusColors, this);
                clueAllCardsForms.Add(cacf);
                cacf.Show();
            }
        }

        private void CellClickGuessEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) //as long as player didn't click on table header
            {
                EditGuess(e.RowIndex);
            }
        }

        private void clearRecentFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["recentFiles"] = "";
            Properties.Settings.Default.Save();
            LoadRecentFiles(); //to refresh the views
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormClosingSaveConfirm(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult dr = MessageBox.Show("Your game is not saved. Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    e.Cancel = true; //cancel the event, player still wants to 
                }
            }
        }

        private void GuessCellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView table = (DataGridView)sender;
                DataGridViewRow row = table.Rows[e.RowIndex];
                //if the column is not -1, Responder, Guesser, or ShownCard
                if (e.ColumnIndex != -1)
                {
                    DataGridViewCell cell = row.Cells[e.ColumnIndex];
                    //if one of the regular card columns
                    if (e.ColumnIndex != dgvGuesses.Columns["Guesser"].Index
                    && e.ColumnIndex != dgvGuesses.Columns["Responder"].Index
                    && e.ColumnIndex != dgvGuesses.Columns["ShownCard"].Index)
                    {
                        e.ToolTipText = GetCellToolTipValue(cell.Value.ToString());
                    }
                    else if (e.ColumnIndex == dgvGuesses.Columns["ShownCard"].Index) //if the column is ShownCard
                    {
                        if (cell.Value.ToString() == "N/A")
                        {
                            e.ToolTipText = "Card is unknown";
                        }
                        else
                        {
                            e.ToolTipText = GetCellToolTipValue(cell.Value.ToString());
                        }
                    }
                }

            }

        }

        private void lnlLResetSort_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PopulateGuessesTable(Guesses);
        }

        private async void NewGame(object sender, EventArgs e)
        {
            if (!saved)
            {
                DialogResult dr = MessageBox.Show("Your game is not saved. Are you sure you want to create a new one?", "Game Creation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return; //cancel creating new game
                }
            }
            AddNewGameForm angf = new AddNewGameForm();
            angf.ShowDialog();
            if (newGameLoc != "")
            {
                await LoadGame(newGameLoc);
                newGameLoc = "";
            }
        }

        private async void OpenGame(object sender, EventArgs e)
        {
            if (!saved)
            {
                DialogResult dr1 = MessageBox.Show("Your game is not saved. Are you sure you want to open a new file?", "Open File Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (dr1 == DialogResult.No)
                {
                    return; //not desired to open file, so return
                }
            }
            openFileDialog1.FileName = fileName;
            openFileDialog1.RestoreDirectory = true;
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return; //no file loaded in
            }

            await LoadGame(openFileDialog1.FileName);
        }

        private void PlayerLinkClicked(object sender, EventArgs e)
        {
            LinkLabel ll = sender as LinkLabel;

            int playerIdx = int.Parse(ll.Name.Replace("lnklPlayer", "")); //get the number at the end of the name of the linklabel
            playerIdx--; //decrement number to get player index number

            ViewPlayerForm vpf = new ViewPlayerForm(playerIdx, Players, Guesses, this);
            viewPlayerForms.Add(vpf);
            vpf.Show();
        }

        private async void RecentGameLinkClick(object sender, EventArgs e)
        {
            if (!saved)
            {
                DialogResult dr1 = MessageBox.Show("Your game is not saved. Are you sure you want to open a new file?", "Open File Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (dr1 == DialogResult.No)
                {
                    return; //not desired to open file, so return
                }
            }
            LinkLabel ll = (LinkLabel)sender;
            ///name is in format of lnkLRecentGame1
            int idx = int.Parse(ll.Name.Replace("lnkLRecentGame", "")) - 1; //the index number of the recent file
            await LoadGame(recentFiles[idx]); //load game!
        }

        private async void RecentGameMenuClick(object sender, EventArgs e)
        {
            if (!saved)
            {
                DialogResult dr1 = MessageBox.Show("Your game is not saved. Are you sure you want to open a new file?", "Open File Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (dr1 == DialogResult.No)
                {
                    return; //not desired to open file, so return
                }
            }
            ToolStripMenuItem ll = (ToolStripMenuItem)sender;
            //name is in format of recentGame1ToolStripMenuItem
            string idxPreParse = ll.Name.Replace("recentGame", "").Replace("ToolStripMenuItem", "");
            int idx = int.Parse(idxPreParse) - 1; //the index number of the recent file
            await LoadGame(recentFiles[idx]); //load game!
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Save();
        }

        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await SaveAs();
        }
    }
}
