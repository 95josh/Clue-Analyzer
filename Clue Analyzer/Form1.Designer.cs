namespace Clue_Analyzer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            openRecentToolStripMenuItem = new ToolStripMenuItem();
            recentGame1ToolStripMenuItem = new ToolStripMenuItem();
            recentGame2ToolStripMenuItem = new ToolStripMenuItem();
            recentGame3ToolStripMenuItem = new ToolStripMenuItem();
            recentGame4ToolStripMenuItem = new ToolStripMenuItem();
            recentGame5ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            clearRecentFilesToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            gameToolStripMenuItem = new ToolStripMenuItem();
            analyzeToolStripMenuItem = new ToolStripMenuItem();
            editSelectedGuessToolStripMenuItem = new ToolStripMenuItem();
            newGuessToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            lblNumberOfDiscoveries = new Label();
            label7 = new Label();
            lblNumberOfGuesses = new Label();
            label6 = new Label();
            lblNumberOfPlayers = new Label();
            label5 = new Label();
            lblFileName = new Label();
            label1 = new Label();
            label3 = new Label();
            dgvGuesses = new DataGridView();
            Suspect = new DataGridViewTextBoxColumn();
            Weapon = new DataGridViewTextBoxColumn();
            Room = new DataGridViewTextBoxColumn();
            Guesser = new DataGridViewTextBoxColumn();
            Responder = new DataGridViewTextBoxColumn();
            ShownCard = new DataGridViewTextBoxColumn();
            ShownCardByDiscovery = new DataGridViewTextBoxColumn();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            lnklPlayer1 = new LinkLabel();
            label2 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            lblMurderDetailsSuspect = new Label();
            lblMurderDetailsWeapon = new Label();
            lblMurderDetailsRoom = new Label();
            panel1 = new Panel();
            label13 = new Label();
            label12 = new Label();
            panel2 = new Panel();
            lnklPlayer6 = new LinkLabel();
            lnklPlayer5 = new LinkLabel();
            lnklPlayer4 = new LinkLabel();
            lnklPlayer3 = new LinkLabel();
            lnklPlayer2 = new LinkLabel();
            label15 = new Label();
            label14 = new Label();
            pnlStartup = new Panel();
            label4 = new Label();
            lnkLRecentGame1 = new LinkLabel();
            label20 = new Label();
            btnNewGame = new Button();
            btnOpen = new Button();
            label18 = new Label();
            lnkLRecentGame5 = new LinkLabel();
            lnkLRecentGame4 = new LinkLabel();
            lnkLRecentGame3 = new LinkLabel();
            lnkLRecentGame2 = new LinkLabel();
            label19 = new Label();
            label17 = new Label();
            label16 = new Label();
            btnAddGuess = new Button();
            btnViewCardsStatuses = new Button();
            toolTip1 = new ToolTip(components);
            btnEditGuess = new Button();
            lnlLResetSort = new LinkLabel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGuesses).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            pnlStartup.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, gameToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(139, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, openToolStripMenuItem, openRecentToolStripMenuItem, toolStripMenuItem1, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripMenuItem2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newGameToolStripMenuItem.Size = new Size(229, 22);
            newGameToolStripMenuItem.Text = "&New Game";
            newGameToolStripMenuItem.Click += NewGame;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(229, 22);
            openToolStripMenuItem.Text = "&Open Game";
            openToolStripMenuItem.Click += OpenGame;
            // 
            // openRecentToolStripMenuItem
            // 
            openRecentToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { recentGame1ToolStripMenuItem, recentGame2ToolStripMenuItem, recentGame3ToolStripMenuItem, recentGame4ToolStripMenuItem, recentGame5ToolStripMenuItem, toolStripMenuItem3, clearRecentFilesToolStripMenuItem });
            openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            openRecentToolStripMenuItem.Size = new Size(229, 22);
            openRecentToolStripMenuItem.Text = "Open &Recent Game";
            // 
            // recentGame1ToolStripMenuItem
            // 
            recentGame1ToolStripMenuItem.Name = "recentGame1ToolStripMenuItem";
            recentGame1ToolStripMenuItem.Size = new Size(166, 22);
            recentGame1ToolStripMenuItem.Text = "RecentGame1";
            recentGame1ToolStripMenuItem.Click += RecentGameMenuClick;
            // 
            // recentGame2ToolStripMenuItem
            // 
            recentGame2ToolStripMenuItem.Name = "recentGame2ToolStripMenuItem";
            recentGame2ToolStripMenuItem.Size = new Size(166, 22);
            recentGame2ToolStripMenuItem.Text = "RecentGame2";
            recentGame2ToolStripMenuItem.Click += RecentGameMenuClick;
            // 
            // recentGame3ToolStripMenuItem
            // 
            recentGame3ToolStripMenuItem.Name = "recentGame3ToolStripMenuItem";
            recentGame3ToolStripMenuItem.Size = new Size(166, 22);
            recentGame3ToolStripMenuItem.Text = "RecentGame3";
            recentGame3ToolStripMenuItem.Click += RecentGameMenuClick;
            // 
            // recentGame4ToolStripMenuItem
            // 
            recentGame4ToolStripMenuItem.Name = "recentGame4ToolStripMenuItem";
            recentGame4ToolStripMenuItem.Size = new Size(166, 22);
            recentGame4ToolStripMenuItem.Text = "RecentGame4";
            recentGame4ToolStripMenuItem.Click += RecentGameMenuClick;
            // 
            // recentGame5ToolStripMenuItem
            // 
            recentGame5ToolStripMenuItem.Name = "recentGame5ToolStripMenuItem";
            recentGame5ToolStripMenuItem.Size = new Size(166, 22);
            recentGame5ToolStripMenuItem.Text = "RecentGame5";
            recentGame5ToolStripMenuItem.Click += RecentGameMenuClick;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(163, 6);
            // 
            // clearRecentFilesToolStripMenuItem
            // 
            clearRecentFilesToolStripMenuItem.Name = "clearRecentFilesToolStripMenuItem";
            clearRecentFilesToolStripMenuItem.Size = new Size(166, 22);
            clearRecentFilesToolStripMenuItem.Text = "&Clear Recent Files";
            clearRecentFilesToolStripMenuItem.Click += clearRecentFilesToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(226, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.RightToLeft = RightToLeft.No;
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(229, 22);
            saveToolStripMenuItem.Text = "&Save Game";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(229, 22);
            saveAsToolStripMenuItem.Text = "Save Game &As...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(226, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(229, 22);
            exitToolStripMenuItem.Text = "&Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { analyzeToolStripMenuItem, editSelectedGuessToolStripMenuItem, newGuessToolStripMenuItem });
            gameToolStripMenuItem.Enabled = false;
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(50, 20);
            gameToolStripMenuItem.Text = "&Game";
            // 
            // analyzeToolStripMenuItem
            // 
            analyzeToolStripMenuItem.Enabled = false;
            analyzeToolStripMenuItem.Name = "analyzeToolStripMenuItem";
            analyzeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            analyzeToolStripMenuItem.Size = new Size(215, 22);
            analyzeToolStripMenuItem.Text = "&Analyze";
            analyzeToolStripMenuItem.Click += analyzeToolStripMenuItem_Click;
            // 
            // editSelectedGuessToolStripMenuItem
            // 
            editSelectedGuessToolStripMenuItem.Enabled = false;
            editSelectedGuessToolStripMenuItem.Name = "editSelectedGuessToolStripMenuItem";
            editSelectedGuessToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            editSelectedGuessToolStripMenuItem.Size = new Size(215, 22);
            editSelectedGuessToolStripMenuItem.Text = "&Edit Selected Guess";
            editSelectedGuessToolStripMenuItem.Click += btnEditSelectedGuess;
            // 
            // newGuessToolStripMenuItem
            // 
            newGuessToolStripMenuItem.Enabled = false;
            newGuessToolStripMenuItem.Name = "newGuessToolStripMenuItem";
            newGuessToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            newGuessToolStripMenuItem.Size = new Size(215, 22);
            newGuessToolStripMenuItem.Text = "&New Guess";
            newGuessToolStripMenuItem.Click += AddNewGuess;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // lblNumberOfDiscoveries
            // 
            lblNumberOfDiscoveries.AutoSize = true;
            lblNumberOfDiscoveries.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNumberOfDiscoveries.Location = new Point(150, 107);
            lblNumberOfDiscoveries.Name = "lblNumberOfDiscoveries";
            lblNumberOfDiscoveries.Size = new Size(13, 15);
            lblNumberOfDiscoveries.TabIndex = 17;
            lblNumberOfDiscoveries.Text = "1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(14, 107);
            label7.Name = "label7";
            label7.Size = new Size(130, 15);
            label7.TabIndex = 16;
            label7.Text = "Number of Discoveries:";
            // 
            // lblNumberOfGuesses
            // 
            lblNumberOfGuesses.AutoSize = true;
            lblNumberOfGuesses.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNumberOfGuesses.Location = new Point(133, 80);
            lblNumberOfGuesses.Name = "lblNumberOfGuesses";
            lblNumberOfGuesses.Size = new Size(19, 15);
            lblNumberOfGuesses.TabIndex = 15;
            lblNumberOfGuesses.Text = "12";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(14, 80);
            label6.Name = "label6";
            label6.Size = new Size(113, 15);
            label6.TabIndex = 14;
            label6.Text = "Number of Guesses:";
            // 
            // lblNumberOfPlayers
            // 
            lblNumberOfPlayers.AutoSize = true;
            lblNumberOfPlayers.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNumberOfPlayers.Location = new Point(128, 53);
            lblNumberOfPlayers.Name = "lblNumberOfPlayers";
            lblNumberOfPlayers.Size = new Size(13, 15);
            lblNumberOfPlayers.TabIndex = 13;
            lblNumberOfPlayers.Text = "5";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 53);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 12;
            label5.Text = "Number of Players:";
            // 
            // lblFileName
            // 
            lblFileName.AutoEllipsis = true;
            lblFileName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFileName.Location = new Point(83, 26);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(109, 15);
            lblFileName.TabIndex = 11;
            lblFileName.Text = "game1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 26);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 9;
            label1.Text = "File Name:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(408, 151);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 5;
            label3.Text = "Guesses";
            // 
            // dgvGuesses
            // 
            dgvGuesses.AllowUserToAddRows = false;
            dgvGuesses.AllowUserToDeleteRows = false;
            dgvGuesses.AllowUserToOrderColumns = true;
            dgvGuesses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGuesses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvGuesses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGuesses.Columns.AddRange(new DataGridViewColumn[] { Suspect, Weapon, Room, Guesser, Responder, ShownCard, ShownCardByDiscovery });
            dgvGuesses.Location = new Point(408, 174);
            dgvGuesses.MultiSelect = false;
            dgvGuesses.Name = "dgvGuesses";
            dgvGuesses.ReadOnly = true;
            dgvGuesses.RowHeadersWidth = 25;
            dgvGuesses.ShowEditingIcon = false;
            dgvGuesses.Size = new Size(625, 391);
            dgvGuesses.TabIndex = 6;
            dgvGuesses.CellDoubleClick += CellClickGuessEdit;
            dgvGuesses.CellToolTipTextNeeded += GuessCellToolTipTextNeeded;
            // 
            // Suspect
            // 
            Suspect.DataPropertyName = "Suspect";
            Suspect.HeaderText = "Suspect";
            Suspect.Name = "Suspect";
            Suspect.ReadOnly = true;
            Suspect.Width = 73;
            // 
            // Weapon
            // 
            Weapon.DataPropertyName = "Weapon";
            Weapon.HeaderText = "Weapon";
            Weapon.Name = "Weapon";
            Weapon.ReadOnly = true;
            Weapon.Width = 76;
            // 
            // Room
            // 
            Room.DataPropertyName = "Room";
            Room.HeaderText = "Room";
            Room.Name = "Room";
            Room.ReadOnly = true;
            Room.Width = 64;
            // 
            // Guesser
            // 
            Guesser.DataPropertyName = "Guesser";
            Guesser.HeaderText = "Guesser";
            Guesser.Name = "Guesser";
            Guesser.ReadOnly = true;
            Guesser.Width = 73;
            // 
            // Responder
            // 
            Responder.DataPropertyName = "Responder";
            Responder.HeaderText = "Responder";
            Responder.Name = "Responder";
            Responder.ReadOnly = true;
            Responder.Width = 88;
            // 
            // ShownCard
            // 
            ShownCard.DataPropertyName = "ShownCard";
            ShownCard.HeaderText = "Card Shown";
            ShownCard.Name = "ShownCard";
            ShownCard.ReadOnly = true;
            ShownCard.Width = 96;
            // 
            // ShownCardByDiscovery
            // 
            ShownCardByDiscovery.DataPropertyName = "ShownCardByDiscovery";
            ShownCardByDiscovery.HeaderText = "ShownCardByDiscovery";
            ShownCardByDiscovery.Name = "ShownCardByDiscovery";
            ShownCardByDiscovery.ReadOnly = true;
            ShownCardByDiscovery.Visible = false;
            ShownCardByDiscovery.Width = 157;
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "cagf";
            openFileDialog1.FileName = "game1.cagf";
            openFileDialog1.Filter = "Clue Analyzer Game Files (*.cagf, *.cg)|*.cagf;*.cg|SQLite db files(*.db, *.sqlite, *.sqlite3, *.db3)|*.db;*.sqlite;*.sqlite3;*.db3|All Files (*.*)|*.*";
            openFileDialog1.SelectReadOnly = false;
            openFileDialog1.Title = "Open game";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "cagf";
            saveFileDialog1.FileName = "game1.cagf";
            saveFileDialog1.Filter = "Clue Analyzer Game Files (*.cagf, *.cg)|*.cagf;*.cg|SQLite db files(*.db, *.sqlite, *.sqlite3, *.db3)|*.db;*.sqlite;*.sqlite3;*.db3";
            saveFileDialog1.Title = "Save game as...";
            // 
            // lnklPlayer1
            // 
            lnklPlayer1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lnklPlayer1.Location = new Point(3, 50);
            lnklPlayer1.Name = "lnklPlayer1";
            lnklPlayer1.Size = new Size(193, 23);
            lnklPlayer1.TabIndex = 0;
            lnklPlayer1.TabStop = true;
            lnklPlayer1.Text = "Player 1";
            lnklPlayer1.TextAlign = ContentAlignment.TopCenter;
            lnklPlayer1.Click += PlayerLinkClicked;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(413, 20);
            label2.Name = "label2";
            label2.Size = new Size(218, 45);
            label2.TabIndex = 9;
            label2.Text = "Clue Analyzer";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(14, 148);
            label8.Name = "label8";
            label8.Size = new Size(93, 15);
            label8.TabIndex = 18;
            label8.Text = "Murder Details:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(14, 168);
            label9.Name = "label9";
            label9.Size = new Size(51, 15);
            label9.TabIndex = 19;
            label9.Text = "Suspect:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(14, 191);
            label10.Name = "label10";
            label10.Size = new Size(54, 15);
            label10.TabIndex = 19;
            label10.Text = "Weapon:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(14, 214);
            label11.Name = "label11";
            label11.Size = new Size(42, 15);
            label11.TabIndex = 19;
            label11.Text = "Room:";
            // 
            // lblMurderDetailsSuspect
            // 
            lblMurderDetailsSuspect.AutoSize = true;
            lblMurderDetailsSuspect.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMurderDetailsSuspect.Location = new Point(80, 168);
            lblMurderDetailsSuspect.Name = "lblMurderDetailsSuspect";
            lblMurderDetailsSuspect.Size = new Size(29, 15);
            lblMurderDetailsSuspect.TabIndex = 19;
            lblMurderDetailsSuspect.Text = "N/A";
            // 
            // lblMurderDetailsWeapon
            // 
            lblMurderDetailsWeapon.AutoSize = true;
            lblMurderDetailsWeapon.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMurderDetailsWeapon.Location = new Point(80, 191);
            lblMurderDetailsWeapon.Name = "lblMurderDetailsWeapon";
            lblMurderDetailsWeapon.Size = new Size(29, 15);
            lblMurderDetailsWeapon.TabIndex = 19;
            lblMurderDetailsWeapon.Text = "N/A";
            // 
            // lblMurderDetailsRoom
            // 
            lblMurderDetailsRoom.AutoSize = true;
            lblMurderDetailsRoom.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMurderDetailsRoom.ForeColor = SystemColors.ControlText;
            lblMurderDetailsRoom.Location = new Point(80, 214);
            lblMurderDetailsRoom.Name = "lblMurderDetailsRoom";
            lblMurderDetailsRoom.Size = new Size(29, 15);
            lblMurderDetailsRoom.TabIndex = 19;
            lblMurderDetailsRoom.Text = "N/A";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Ivory;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(lblNumberOfPlayers);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(lblFileName);
            panel1.Controls.Add(lblMurderDetailsRoom);
            panel1.Controls.Add(lblNumberOfGuesses);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(lblMurderDetailsWeapon);
            panel1.Controls.Add(lblNumberOfDiscoveries);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(lblMurderDetailsSuspect);
            panel1.Controls.Add(label9);
            panel1.Location = new Point(12, 93);
            panel1.Name = "panel1";
            panel1.Size = new Size(201, 248);
            panel1.TabIndex = 20;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(14, 6);
            label13.Name = "label13";
            label13.Size = new Size(95, 15);
            label13.TabIndex = 20;
            label13.Text = "General Details:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(12, 70);
            label12.Name = "label12";
            label12.Size = new Size(102, 20);
            label12.TabIndex = 21;
            label12.Text = "Game Details";
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lnklPlayer6);
            panel2.Controls.Add(lnklPlayer5);
            panel2.Controls.Add(lnklPlayer4);
            panel2.Controls.Add(lnklPlayer3);
            panel2.Controls.Add(lnklPlayer2);
            panel2.Controls.Add(lnklPlayer1);
            panel2.Controls.Add(label15);
            panel2.Location = new Point(12, 372);
            panel2.Name = "panel2";
            panel2.Size = new Size(201, 192);
            panel2.TabIndex = 9;
            // 
            // lnklPlayer6
            // 
            lnklPlayer6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lnklPlayer6.Location = new Point(3, 165);
            lnklPlayer6.Name = "lnklPlayer6";
            lnklPlayer6.Size = new Size(193, 23);
            lnklPlayer6.TabIndex = 5;
            lnklPlayer6.TabStop = true;
            lnklPlayer6.Text = "Player 6";
            lnklPlayer6.TextAlign = ContentAlignment.TopCenter;
            lnklPlayer6.Click += PlayerLinkClicked;
            // 
            // lnklPlayer5
            // 
            lnklPlayer5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lnklPlayer5.Location = new Point(3, 142);
            lnklPlayer5.Name = "lnklPlayer5";
            lnklPlayer5.Size = new Size(193, 23);
            lnklPlayer5.TabIndex = 4;
            lnklPlayer5.TabStop = true;
            lnklPlayer5.Text = "Player 5";
            lnklPlayer5.TextAlign = ContentAlignment.TopCenter;
            lnklPlayer5.Click += PlayerLinkClicked;
            // 
            // lnklPlayer4
            // 
            lnklPlayer4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lnklPlayer4.Location = new Point(3, 119);
            lnklPlayer4.Name = "lnklPlayer4";
            lnklPlayer4.Size = new Size(193, 23);
            lnklPlayer4.TabIndex = 3;
            lnklPlayer4.TabStop = true;
            lnklPlayer4.Text = "Player 4";
            lnklPlayer4.TextAlign = ContentAlignment.TopCenter;
            lnklPlayer4.Click += PlayerLinkClicked;
            // 
            // lnklPlayer3
            // 
            lnklPlayer3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lnklPlayer3.Location = new Point(3, 96);
            lnklPlayer3.Name = "lnklPlayer3";
            lnklPlayer3.Size = new Size(193, 23);
            lnklPlayer3.TabIndex = 2;
            lnklPlayer3.TabStop = true;
            lnklPlayer3.Text = "Player 3";
            lnklPlayer3.TextAlign = ContentAlignment.TopCenter;
            lnklPlayer3.Click += PlayerLinkClicked;
            // 
            // lnklPlayer2
            // 
            lnklPlayer2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lnklPlayer2.Location = new Point(3, 73);
            lnklPlayer2.Name = "lnklPlayer2";
            lnklPlayer2.Size = new Size(193, 23);
            lnklPlayer2.TabIndex = 1;
            lnklPlayer2.TabStop = true;
            lnklPlayer2.Text = "Player 2";
            lnklPlayer2.TextAlign = ContentAlignment.TopCenter;
            lnklPlayer2.Click += PlayerLinkClicked;
            // 
            // label15
            // 
            label15.Location = new Point(16, 6);
            label15.Name = "label15";
            label15.Size = new Size(176, 32);
            label15.TabIndex = 6;
            label15.Text = "Click on a player name to see their cards and more details";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(12, 349);
            label14.Name = "label14";
            label14.Size = new Size(59, 20);
            label14.TabIndex = 21;
            label14.Text = "Players";
            // 
            // pnlStartup
            // 
            pnlStartup.Controls.Add(label4);
            pnlStartup.Controls.Add(lnkLRecentGame1);
            pnlStartup.Controls.Add(label20);
            pnlStartup.Controls.Add(btnNewGame);
            pnlStartup.Controls.Add(btnOpen);
            pnlStartup.Controls.Add(label18);
            pnlStartup.Controls.Add(lnkLRecentGame5);
            pnlStartup.Controls.Add(lnkLRecentGame4);
            pnlStartup.Controls.Add(lnkLRecentGame3);
            pnlStartup.Controls.Add(lnkLRecentGame2);
            pnlStartup.Controls.Add(label19);
            pnlStartup.Controls.Add(label17);
            pnlStartup.Controls.Add(label16);
            pnlStartup.Location = new Point(250, 571);
            pnlStartup.Name = "pnlStartup";
            pnlStartup.Size = new Size(1045, 576);
            pnlStartup.TabIndex = 7;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(414, 20);
            label4.Name = "label4";
            label4.Size = new Size(218, 45);
            label4.TabIndex = 1;
            label4.Text = "Clue Analyzer";
            // 
            // lnkLRecentGame1
            // 
            lnkLRecentGame1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lnkLRecentGame1.Location = new Point(392, 328);
            lnkLRecentGame1.Name = "lnkLRecentGame1";
            lnkLRecentGame1.Size = new Size(260, 20);
            lnkLRecentGame1.TabIndex = 7;
            lnkLRecentGame1.TabStop = true;
            lnkLRecentGame1.Text = "RecentGame1";
            lnkLRecentGame1.TextAlign = ContentAlignment.MiddleCenter;
            lnkLRecentGame1.Visible = false;
            lnkLRecentGame1.Click += RecentGameLinkClick;
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label20.Location = new Point(454, 328);
            label20.Name = "label20";
            label20.Size = new Size(137, 20);
            label20.TabIndex = 4;
            label20.Text = "No Recent Games";
            label20.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNewGame
            // 
            btnNewGame.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnNewGame.Location = new Point(554, 218);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(99, 37);
            btnNewGame.TabIndex = 5;
            btnNewGame.Text = "New Game";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += NewGame;
            // 
            // btnOpen
            // 
            btnOpen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnOpen.Location = new Point(391, 218);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(99, 37);
            btnOpen.TabIndex = 0;
            btnOpen.Text = "Open Game";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += OpenGame;
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.Location = new Point(470, 295);
            label18.Name = "label18";
            label18.Size = new Size(107, 19);
            label18.TabIndex = 6;
            label18.Text = "Recent Games:";
            label18.TextAlign = ContentAlignment.TopCenter;
            // 
            // lnkLRecentGame5
            // 
            lnkLRecentGame5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lnkLRecentGame5.Location = new Point(392, 434);
            lnkLRecentGame5.Name = "lnkLRecentGame5";
            lnkLRecentGame5.Size = new Size(260, 20);
            lnkLRecentGame5.TabIndex = 11;
            lnkLRecentGame5.TabStop = true;
            lnkLRecentGame5.Text = "RecentGame5";
            lnkLRecentGame5.TextAlign = ContentAlignment.MiddleCenter;
            lnkLRecentGame5.Visible = false;
            lnkLRecentGame5.Click += RecentGameLinkClick;
            // 
            // lnkLRecentGame4
            // 
            lnkLRecentGame4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lnkLRecentGame4.Location = new Point(392, 407);
            lnkLRecentGame4.Name = "lnkLRecentGame4";
            lnkLRecentGame4.Size = new Size(260, 20);
            lnkLRecentGame4.TabIndex = 10;
            lnkLRecentGame4.TabStop = true;
            lnkLRecentGame4.Text = "RecentGame4";
            lnkLRecentGame4.TextAlign = ContentAlignment.MiddleCenter;
            lnkLRecentGame4.Visible = false;
            lnkLRecentGame4.Click += RecentGameLinkClick;
            // 
            // lnkLRecentGame3
            // 
            lnkLRecentGame3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lnkLRecentGame3.Location = new Point(392, 380);
            lnkLRecentGame3.Name = "lnkLRecentGame3";
            lnkLRecentGame3.Size = new Size(260, 20);
            lnkLRecentGame3.TabIndex = 9;
            lnkLRecentGame3.TabStop = true;
            lnkLRecentGame3.Text = "RecentGame3";
            lnkLRecentGame3.TextAlign = ContentAlignment.MiddleCenter;
            lnkLRecentGame3.Visible = false;
            lnkLRecentGame3.Click += RecentGameLinkClick;
            // 
            // lnkLRecentGame2
            // 
            lnkLRecentGame2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lnkLRecentGame2.Location = new Point(392, 353);
            lnkLRecentGame2.Name = "lnkLRecentGame2";
            lnkLRecentGame2.Size = new Size(260, 20);
            lnkLRecentGame2.TabIndex = 8;
            lnkLRecentGame2.TabStop = true;
            lnkLRecentGame2.Text = "RecentGame2";
            lnkLRecentGame2.TextAlign = ContentAlignment.MiddleCenter;
            lnkLRecentGame2.Visible = false;
            lnkLRecentGame2.Click += RecentGameLinkClick;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label19.AutoSize = true;
            label19.Location = new Point(306, 168);
            label19.Name = "label19";
            label19.Size = new Size(434, 15);
            label19.TabIndex = 4;
            label19.Text = "Click \"Open Game\" to open a previous game and \"New Game\" to start a new one";
            label19.TextAlign = ContentAlignment.TopCenter;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label17.AutoSize = true;
            label17.Location = new Point(284, 150);
            label17.Name = "label17";
            label17.Size = new Size(479, 15);
            label17.TabIndex = 3;
            label17.Text = "This program is built to ease the deductive reasoning process required for a game of Clue.";
            label17.TextAlign = ContentAlignment.TopCenter;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(415, 115);
            label16.Name = "label16";
            label16.Size = new Size(216, 21);
            label16.TabIndex = 2;
            label16.Text = "Welcome to Clue Analyzer!";
            label16.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnAddGuess
            // 
            btnAddGuess.Location = new Point(408, 100);
            btnAddGuess.Name = "btnAddGuess";
            btnAddGuess.Size = new Size(107, 39);
            btnAddGuess.TabIndex = 1;
            btnAddGuess.Text = "Add Guess";
            btnAddGuess.UseVisualStyleBackColor = true;
            btnAddGuess.Click += AddNewGuess;
            // 
            // btnViewCardsStatuses
            // 
            btnViewCardsStatuses.Location = new Point(521, 100);
            btnViewCardsStatuses.Name = "btnViewCardsStatuses";
            btnViewCardsStatuses.Size = new Size(131, 39);
            btnViewCardsStatuses.TabIndex = 5;
            btnViewCardsStatuses.Text = "View Cards Statuses";
            btnViewCardsStatuses.UseVisualStyleBackColor = true;
            btnViewCardsStatuses.Click += btnViewCardsStatuses_Click;
            // 
            // btnEditGuess
            // 
            btnEditGuess.Location = new Point(658, 100);
            btnEditGuess.Name = "btnEditGuess";
            btnEditGuess.Size = new Size(131, 39);
            btnEditGuess.TabIndex = 6;
            btnEditGuess.Text = "Edit Selected Guess";
            btnEditGuess.UseVisualStyleBackColor = true;
            btnEditGuess.Click += btnEditSelectedGuess;
            // 
            // lnlLResetSort
            // 
            lnlLResetSort.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lnlLResetSort.AutoSize = true;
            lnlLResetSort.Location = new Point(480, 155);
            lnlLResetSort.Name = "lnlLResetSort";
            lnlLResetSort.Size = new Size(59, 15);
            lnlLResetSort.TabIndex = 22;
            lnlLResetSort.TabStop = true;
            lnlLResetSort.Text = "Reset Sort";
            lnlLResetSort.LinkClicked += lnlLResetSort_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 576);
            Controls.Add(pnlStartup);
            Controls.Add(panel2);
            Controls.Add(label14);
            Controls.Add(label12);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(dgvGuesses);
            Controls.Add(label3);
            Controls.Add(menuStrip1);
            Controls.Add(btnAddGuess);
            Controls.Add(btnViewCardsStatuses);
            Controls.Add(btnEditGuess);
            Controls.Add(lnlLResetSort);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Clue Analyzer - Untitled *";
            FormClosing += FormClosingSaveConfirm;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGuesses).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            pnlStartup.ResumeLayout(false);
            pnlStartup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Label label3;
        private DataGridView dgvGuesses;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem newGuessToolStripMenuItem;
        private ToolStripMenuItem analyzeToolStripMenuItem;
        private Label lblFileName;
        private Label label1;
        private Label label5;
        private Label label2;
        private Label lblNumberOfPlayers;
        private Label lblNumberOfGuesses;
        private Label label6;
        private Label lblNumberOfDiscoveries;
        private Label label7;
        private LinkLabel lnklPlayer1;
        private Label label9;
        private Label label8;
        private Label label11;
        private Label label10;
        private Label lblMurderDetailsRoom;
        private Label lblMurderDetailsWeapon;
        private Label lblMurderDetailsSuspect;
        private Panel panel1;
        private Label label13;
        private Label label12;
        private Panel panel2;
        private Label label14;
        private LinkLabel lnklPlayer6;
        private LinkLabel lnklPlayer5;
        private LinkLabel lnklPlayer4;
        private LinkLabel lnklPlayer3;
        private LinkLabel lnklPlayer2;
        private Label label15;
        private Button btnViewAllCardStatuses;
        private DataGridViewTextBoxColumn Suspect;
        private DataGridViewTextBoxColumn Weapon;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewTextBoxColumn Guesser;
        private DataGridViewTextBoxColumn Responder;
        private DataGridViewTextBoxColumn ShownCard;
        private DataGridViewTextBoxColumn ShownCardByDiscovery;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private Panel pnlStartup;
        private LinkLabel lnkLRecentGame5;
        private LinkLabel lnkLRecentGame4;
        private LinkLabel lnkLRecentGame3;
        private LinkLabel lnkLRecentGame2;
        private LinkLabel lnkLRecentGame1;
        private Label label17;
        private Label label16;
        private Button btnNewGame;
        private Button btnOpen;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label4;
        private ToolStripMenuItem openRecentToolStripMenuItem;
        private ToolStripMenuItem recentGame1ToolStripMenuItem;
        private ToolStripMenuItem recentGame2ToolStripMenuItem;
        private ToolStripMenuItem recentGame3ToolStripMenuItem;
        private ToolStripMenuItem recentGame4ToolStripMenuItem;
        private ToolStripMenuItem recentGame5ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem clearRecentFilesToolStripMenuItem;
        private Button btnAddGuess;
        private Button btnViewCardsStatuses;
        private ToolTip toolTip1;
        private ToolStripMenuItem editSelectedGuessToolStripMenuItem;
        private Button btnEditGuess;
        private LinkLabel lnlLResetSort;
    }
}
