namespace Clue_Analyzer
{
    partial class AddNewGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewGameForm));
            btnNext = new Button();
            label5 = new Label();
            label4 = new Label();
            numPlayer6 = new NumericUpDown();
            numPlayer5 = new NumericUpDown();
            numPlayer4 = new NumericUpDown();
            numPlayer3 = new NumericUpDown();
            numPlayer2 = new NumericUpDown();
            numPlayer1 = new NumericUpDown();
            pnlPlayerInfo = new Panel();
            lnkLCardSet = new LinkLabel();
            label9 = new Label();
            txtPlayer6 = new TextBox();
            txtPlayer5 = new TextBox();
            txtPlayer4 = new TextBox();
            txtPlayer3 = new TextBox();
            txtPlayer2 = new TextBox();
            label3 = new Label();
            txtPlayer1 = new TextBox();
            label2 = new Label();
            numPlayers = new NumericUpDown();
            label1 = new Label();
            saveFileDialog1 = new SaveFileDialog();
            btnGoPlayerNumber = new Button();
            pnlFinalize = new Panel();
            btnBack = new Button();
            lblFileLocation = new Label();
            btnChooseLocation = new Button();
            label8 = new Label();
            label7 = new Label();
            clbPlayerItems = new CheckedListBox();
            btnDone = new Button();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)numPlayer6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPlayer5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPlayer4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPlayer3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPlayer2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPlayer1).BeginInit();
            pnlPlayerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPlayers).BeginInit();
            pnlFinalize.SuspendLayout();
            SuspendLayout();
            // 
            // btnNext
            // 
            btnNext.Enabled = false;
            btnNext.Location = new Point(227, 422);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(110, 36);
            btnNext.TabIndex = 5;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(207, 61);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 2;
            label5.Text = "Number Of Cards";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(64, 61);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 1;
            label4.Text = "Player Name";
            // 
            // numPlayer6
            // 
            numPlayer6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numPlayer6.Location = new Point(204, 225);
            numPlayer6.Name = "numPlayer6";
            numPlayer6.Size = new Size(104, 23);
            numPlayer6.TabIndex = 14;
            numPlayer6.ValueChanged += PlayerNumberOfCardsChanged;
            numPlayer6.Enter += NumericFocused;
            // 
            // numPlayer5
            // 
            numPlayer5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numPlayer5.Location = new Point(204, 196);
            numPlayer5.Name = "numPlayer5";
            numPlayer5.Size = new Size(104, 23);
            numPlayer5.TabIndex = 12;
            numPlayer5.ValueChanged += PlayerNumberOfCardsChanged;
            numPlayer5.Enter += NumericFocused;
            // 
            // numPlayer4
            // 
            numPlayer4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numPlayer4.Location = new Point(204, 167);
            numPlayer4.Name = "numPlayer4";
            numPlayer4.Size = new Size(104, 23);
            numPlayer4.TabIndex = 10;
            numPlayer4.ValueChanged += PlayerNumberOfCardsChanged;
            numPlayer4.Enter += NumericFocused;
            // 
            // numPlayer3
            // 
            numPlayer3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numPlayer3.Location = new Point(204, 138);
            numPlayer3.Name = "numPlayer3";
            numPlayer3.Size = new Size(104, 23);
            numPlayer3.TabIndex = 8;
            numPlayer3.ValueChanged += PlayerNumberOfCardsChanged;
            numPlayer3.Enter += NumericFocused;
            // 
            // numPlayer2
            // 
            numPlayer2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numPlayer2.Location = new Point(204, 109);
            numPlayer2.Name = "numPlayer2";
            numPlayer2.Size = new Size(104, 23);
            numPlayer2.TabIndex = 6;
            numPlayer2.ValueChanged += PlayerNumberOfCardsChanged;
            numPlayer2.Enter += NumericFocused;
            // 
            // numPlayer1
            // 
            numPlayer1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numPlayer1.Location = new Point(204, 80);
            numPlayer1.Name = "numPlayer1";
            numPlayer1.Size = new Size(104, 23);
            numPlayer1.TabIndex = 4;
            numPlayer1.ValueChanged += PlayerNumberOfCardsChanged;
            numPlayer1.Enter += NumericFocused;
            // 
            // pnlPlayerInfo
            // 
            pnlPlayerInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPlayerInfo.Controls.Add(lnkLCardSet);
            pnlPlayerInfo.Controls.Add(label9);
            pnlPlayerInfo.Controls.Add(label5);
            pnlPlayerInfo.Controls.Add(label4);
            pnlPlayerInfo.Controls.Add(numPlayer6);
            pnlPlayerInfo.Controls.Add(numPlayer5);
            pnlPlayerInfo.Controls.Add(numPlayer4);
            pnlPlayerInfo.Controls.Add(numPlayer3);
            pnlPlayerInfo.Controls.Add(numPlayer2);
            pnlPlayerInfo.Controls.Add(numPlayer1);
            pnlPlayerInfo.Controls.Add(txtPlayer6);
            pnlPlayerInfo.Controls.Add(txtPlayer5);
            pnlPlayerInfo.Controls.Add(txtPlayer4);
            pnlPlayerInfo.Controls.Add(txtPlayer3);
            pnlPlayerInfo.Controls.Add(txtPlayer2);
            pnlPlayerInfo.Controls.Add(label3);
            pnlPlayerInfo.Controls.Add(txtPlayer1);
            pnlPlayerInfo.Location = new Point(-6, 108);
            pnlPlayerInfo.Name = "pnlPlayerInfo";
            pnlPlayerInfo.Size = new Size(358, 308);
            pnlPlayerInfo.TabIndex = 4;
            pnlPlayerInfo.Visible = false;
            // 
            // lnkLCardSet
            // 
            lnkLCardSet.AutoEllipsis = true;
            lnkLCardSet.AutoSize = true;
            lnkLCardSet.Location = new Point(131, 270);
            lnkLCardSet.Name = "lnkLCardSet";
            lnkLCardSet.Size = new Size(199, 15);
            lnkLCardSet.TabIndex = 16;
            lnkLCardSet.TabStop = true;
            lnkLCardSet.Text = "North American Editions 1963 - 2015";
            lnkLCardSet.LinkClicked += lnkLCardSet_LinkClicked;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(41, 270);
            label9.Name = "label9";
            label9.Size = new Size(81, 15);
            label9.TabIndex = 15;
            label9.Text = "Clue Card Set:";
            // 
            // txtPlayer6
            // 
            txtPlayer6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlayer6.Location = new Point(41, 225);
            txtPlayer6.Name = "txtPlayer6";
            txtPlayer6.PlaceholderText = "Player 6's Name";
            txtPlayer6.Size = new Size(120, 23);
            txtPlayer6.TabIndex = 13;
            // 
            // txtPlayer5
            // 
            txtPlayer5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlayer5.Location = new Point(41, 196);
            txtPlayer5.Name = "txtPlayer5";
            txtPlayer5.PlaceholderText = "Player 5's Name";
            txtPlayer5.Size = new Size(120, 23);
            txtPlayer5.TabIndex = 11;
            // 
            // txtPlayer4
            // 
            txtPlayer4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlayer4.Location = new Point(41, 167);
            txtPlayer4.Name = "txtPlayer4";
            txtPlayer4.PlaceholderText = "Player 4's Name";
            txtPlayer4.Size = new Size(120, 23);
            txtPlayer4.TabIndex = 9;
            // 
            // txtPlayer3
            // 
            txtPlayer3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlayer3.Location = new Point(41, 138);
            txtPlayer3.Name = "txtPlayer3";
            txtPlayer3.PlaceholderText = "Player 3's Name";
            txtPlayer3.Size = new Size(120, 23);
            txtPlayer3.TabIndex = 7;
            // 
            // txtPlayer2
            // 
            txtPlayer2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlayer2.Location = new Point(41, 109);
            txtPlayer2.Name = "txtPlayer2";
            txtPlayer2.PlaceholderText = "Player 2 (to your left)";
            txtPlayer2.Size = new Size(120, 23);
            txtPlayer2.TabIndex = 5;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(7, 22);
            label3.Name = "label3";
            label3.Size = new Size(344, 26);
            label3.TabIndex = 0;
            label3.Text = "Enter Player Information (clockwise, starting with you)";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtPlayer1
            // 
            txtPlayer1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlayer1.Location = new Point(41, 80);
            txtPlayer1.Name = "txtPlayer1";
            txtPlayer1.PlaceholderText = "Your Name";
            txtPlayer1.Size = new Size(120, 23);
            txtPlayer1.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(32, 68);
            label2.Name = "label2";
            label2.Size = new Size(159, 15);
            label2.TabIndex = 1;
            label2.Text = "How many players are there?";
            // 
            // numPlayers
            // 
            numPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numPlayers.Location = new Point(206, 66);
            numPlayers.Name = "numPlayers";
            numPlayers.Size = new Size(53, 23);
            numPlayers.TabIndex = 2;
            numPlayers.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numPlayers.ValueChanged += PlayerNumChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(109, 17);
            label1.Name = "label1";
            label1.Size = new Size(131, 21);
            label1.TabIndex = 0;
            label1.Text = "New Clue Game";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "cagf";
            saveFileDialog1.FileName = "game1.cagf";
            saveFileDialog1.Filter = "Clue Analyzer Game Files (*.cagf, *.cg)|*.cagf;*.cg|SQLite db files(*.db, *.sqlite, *.sqlite3, *.db3)|*.db;*.sqlite;*.sqlite3;*.db3";
            saveFileDialog1.Title = "Save game as...";
            // 
            // btnGoPlayerNumber
            // 
            btnGoPlayerNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnGoPlayerNumber.Location = new Point(277, 61);
            btnGoPlayerNumber.Name = "btnGoPlayerNumber";
            btnGoPlayerNumber.Size = new Size(47, 32);
            btnGoPlayerNumber.TabIndex = 3;
            btnGoPlayerNumber.Text = "Go";
            btnGoPlayerNumber.UseVisualStyleBackColor = true;
            btnGoPlayerNumber.Click += btnGoPlayerNumber_Click;
            // 
            // pnlFinalize
            // 
            pnlFinalize.Controls.Add(btnBack);
            pnlFinalize.Controls.Add(lblFileLocation);
            pnlFinalize.Controls.Add(btnChooseLocation);
            pnlFinalize.Controls.Add(label8);
            pnlFinalize.Controls.Add(label7);
            pnlFinalize.Controls.Add(clbPlayerItems);
            pnlFinalize.Controls.Add(btnDone);
            pnlFinalize.Controls.Add(label6);
            pnlFinalize.Location = new Point(67, 464);
            pnlFinalize.Name = "pnlFinalize";
            pnlFinalize.Size = new Size(349, 470);
            pnlFinalize.TabIndex = 6;
            pnlFinalize.Visible = false;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 422);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(110, 36);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lblFileLocation
            // 
            lblFileLocation.Location = new Point(3, 365);
            lblFileLocation.Name = "lblFileLocation";
            lblFileLocation.Size = new Size(342, 26);
            lblFileLocation.TabIndex = 5;
            lblFileLocation.Text = "File location: blablabla";
            lblFileLocation.TextAlign = ContentAlignment.MiddleCenter;
            lblFileLocation.Visible = false;
            // 
            // btnChooseLocation
            // 
            btnChooseLocation.Location = new Point(115, 339);
            btnChooseLocation.Name = "btnChooseLocation";
            btnChooseLocation.Size = new Size(118, 23);
            btnChooseLocation.TabIndex = 4;
            btnChooseLocation.Text = "Choose Location";
            btnChooseLocation.UseVisualStyleBackColor = true;
            btnChooseLocation.Click += btnChooseLocation_Click;
            // 
            // label8
            // 
            label8.Location = new Point(49, 310);
            label8.Name = "label8";
            label8.Size = new Size(251, 26);
            label8.TabIndex = 3;
            label8.Text = "Choose a location to save your game";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(73, 66);
            label7.Name = "label7";
            label7.Size = new Size(203, 23);
            label7.TabIndex = 1;
            label7.Text = "Choose your cards";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clbPlayerItems
            // 
            clbPlayerItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            clbPlayerItems.CheckOnClick = true;
            clbPlayerItems.FormattingEnabled = true;
            clbPlayerItems.Items.AddRange(new object[] { "Colonel Mustard", "Miss Scarlett", "Mr. Green", "Mrs. Peacock", "Mrs. White", "Professor Plum", "Candlestick", "Dagger", "Lead Pipe", "Revolver", "Rope", "Wrench", "Ballroom", "Billiard Room", "Conservatory", "Dining Room", "Hall", "Kitchen", "Library", "Lounge", "Study" });
            clbPlayerItems.Location = new Point(84, 98);
            clbPlayerItems.Name = "clbPlayerItems";
            clbPlayerItems.Size = new Size(180, 166);
            clbPlayerItems.TabIndex = 2;
            // 
            // btnDone
            // 
            btnDone.Location = new Point(227, 422);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(110, 36);
            btnDone.TabIndex = 6;
            btnDone.Text = "Done";
            btnDone.UseVisualStyleBackColor = true;
            btnDone.Click += btnDone_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(109, 17);
            label6.Name = "label6";
            label6.Size = new Size(131, 21);
            label6.TabIndex = 0;
            label6.Text = "New Clue Game";
            // 
            // AddNewGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 470);
            Controls.Add(pnlFinalize);
            Controls.Add(btnGoPlayerNumber);
            Controls.Add(btnNext);
            Controls.Add(pnlPlayerInfo);
            Controls.Add(label2);
            Controls.Add(numPlayers);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddNewGameForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Game";
            ((System.ComponentModel.ISupportInitialize)numPlayer6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPlayer5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPlayer4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPlayer3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPlayer2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPlayer1).EndInit();
            pnlPlayerInfo.ResumeLayout(false);
            pnlPlayerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPlayers).EndInit();
            pnlFinalize.ResumeLayout(false);
            pnlFinalize.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNext;
        private Label label5;
        private Label label4;
        private NumericUpDown numPlayer6;
        private NumericUpDown numPlayer5;
        private NumericUpDown numPlayer4;
        private NumericUpDown numPlayer3;
        private NumericUpDown numPlayer2;
        private NumericUpDown numPlayer1;
        private Panel pnlPlayerInfo;
        private TextBox txtPlayer6;
        private TextBox txtPlayer5;
        private TextBox txtPlayer4;
        private TextBox txtPlayer3;
        private TextBox txtPlayer2;
        private Label label3;
        private TextBox txtPlayer1;
        private Label label2;
        private NumericUpDown numPlayers;
        private Label label1;
        private SaveFileDialog saveFileDialog1;
        private Button btnGoPlayerNumber;
        private Panel pnlFinalize;
        private CheckedListBox clbPlayerItems;
        private Button btnDone;
        private Label label6;
        private Label label7;
        private Label lblFileLocation;
        private Button btnChooseLocation;
        private Label label8;
        private Button btnBack;
        private Label label9;
        private LinkLabel lnkLCardSet;
    }
}