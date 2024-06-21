namespace Clue_Analyzer
{
    partial class ClueGuessInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClueGuessInputForm));
            pnlPick = new Panel();
            pnlPickShownCard = new Panel();
            label8 = new Label();
            cmbCardCategory = new ComboBox();
            btnClose = new Button();
            rbOption9 = new RadioButton();
            rbOption8 = new RadioButton();
            rbOption7 = new RadioButton();
            rbOption6 = new RadioButton();
            rbOption5 = new RadioButton();
            rbOption4 = new RadioButton();
            rbOption3 = new RadioButton();
            rbOption2 = new RadioButton();
            rbOption1 = new RadioButton();
            lblPrompt = new Label();
            btnAddGuess = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lbl6 = new Label();
            lnkLSuspect = new LinkLabel();
            lnkLWeapon = new LinkLabel();
            lnkLRoom = new LinkLabel();
            lnkLGuesser = new LinkLabel();
            lnkLResponder = new LinkLabel();
            lnkLShownCard = new LinkLabel();
            pnlShownCard = new Panel();
            lblInstructions = new Label();
            lblHeader = new Label();
            pnlPick.SuspendLayout();
            pnlPickShownCard.SuspendLayout();
            pnlShownCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPick
            // 
            pnlPick.BackColor = SystemColors.ControlLightLight;
            pnlPick.BorderStyle = BorderStyle.FixedSingle;
            pnlPick.Controls.Add(pnlPickShownCard);
            pnlPick.Controls.Add(btnClose);
            pnlPick.Controls.Add(rbOption9);
            pnlPick.Controls.Add(rbOption8);
            pnlPick.Controls.Add(rbOption7);
            pnlPick.Controls.Add(rbOption6);
            pnlPick.Controls.Add(rbOption5);
            pnlPick.Controls.Add(rbOption4);
            pnlPick.Controls.Add(rbOption3);
            pnlPick.Controls.Add(rbOption2);
            pnlPick.Controls.Add(rbOption1);
            pnlPick.Controls.Add(lblPrompt);
            pnlPick.Location = new Point(51, 364);
            pnlPick.Name = "pnlPick";
            pnlPick.Size = new Size(256, 340);
            pnlPick.TabIndex = 15;
            pnlPick.Visible = false;
            // 
            // pnlPickShownCard
            // 
            pnlPickShownCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPickShownCard.Controls.Add(label8);
            pnlPickShownCard.Controls.Add(cmbCardCategory);
            pnlPickShownCard.Location = new Point(55, 83);
            pnlPickShownCard.Name = "pnlPickShownCard";
            pnlPickShownCard.Size = new Size(144, 249);
            pnlPickShownCard.TabIndex = 16;
            pnlPickShownCard.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 22);
            label8.Name = "label8";
            label8.Size = new Size(124, 15);
            label8.TabIndex = 1;
            label8.Text = "Pick the card category";
            // 
            // cmbCardCategory
            // 
            cmbCardCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCardCategory.FormattingEnabled = true;
            cmbCardCategory.Items.AddRange(new object[] { "Suspect", "Weapon", "Room" });
            cmbCardCategory.Location = new Point(28, 46);
            cmbCardCategory.Name = "cmbCardCategory";
            cmbCardCategory.Size = new Size(121, 23);
            cmbCardCategory.TabIndex = 0;
            cmbCardCategory.SelectedIndexChanged += CardCategoryChange;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(216, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 35);
            btnClose.TabIndex = 15;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // rbOption9
            // 
            rbOption9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rbOption9.AutoSize = true;
            rbOption9.Location = new Point(87, 291);
            rbOption9.Name = "rbOption9";
            rbOption9.Size = new Size(105, 19);
            rbOption9.TabIndex = 11;
            rbOption9.Text = "Professor Plum";
            rbOption9.UseVisualStyleBackColor = true;
            rbOption9.Click += OptionSelected;
            // 
            // rbOption8
            // 
            rbOption8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rbOption8.AutoSize = true;
            rbOption8.Location = new Point(87, 266);
            rbOption8.Name = "rbOption8";
            rbOption8.Size = new Size(82, 19);
            rbOption8.TabIndex = 12;
            rbOption8.Text = "Mrs. White";
            rbOption8.UseVisualStyleBackColor = true;
            rbOption8.Click += OptionSelected;
            // 
            // rbOption7
            // 
            rbOption7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rbOption7.AutoSize = true;
            rbOption7.Location = new Point(87, 241);
            rbOption7.Name = "rbOption7";
            rbOption7.Size = new Size(95, 19);
            rbOption7.TabIndex = 13;
            rbOption7.Text = "Mrs. Peacock";
            rbOption7.UseVisualStyleBackColor = true;
            rbOption7.Click += OptionSelected;
            // 
            // rbOption6
            // 
            rbOption6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rbOption6.AutoSize = true;
            rbOption6.Location = new Point(87, 216);
            rbOption6.Name = "rbOption6";
            rbOption6.Size = new Size(105, 19);
            rbOption6.TabIndex = 5;
            rbOption6.Text = "Professor Plum";
            rbOption6.UseVisualStyleBackColor = true;
            rbOption6.Click += OptionSelected;
            // 
            // rbOption5
            // 
            rbOption5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rbOption5.AutoSize = true;
            rbOption5.Location = new Point(87, 191);
            rbOption5.Name = "rbOption5";
            rbOption5.Size = new Size(82, 19);
            rbOption5.TabIndex = 6;
            rbOption5.Text = "Mrs. White";
            rbOption5.UseVisualStyleBackColor = true;
            rbOption5.Click += OptionSelected;
            // 
            // rbOption4
            // 
            rbOption4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rbOption4.AutoSize = true;
            rbOption4.Location = new Point(87, 166);
            rbOption4.Name = "rbOption4";
            rbOption4.Size = new Size(95, 19);
            rbOption4.TabIndex = 7;
            rbOption4.Text = "Mrs. Peacock";
            rbOption4.UseVisualStyleBackColor = true;
            rbOption4.Click += OptionSelected;
            // 
            // rbOption3
            // 
            rbOption3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rbOption3.AutoSize = true;
            rbOption3.Location = new Point(87, 141);
            rbOption3.Name = "rbOption3";
            rbOption3.Size = new Size(77, 19);
            rbOption3.TabIndex = 8;
            rbOption3.Text = "Mr. Green";
            rbOption3.UseVisualStyleBackColor = true;
            rbOption3.Click += OptionSelected;
            // 
            // rbOption2
            // 
            rbOption2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rbOption2.AutoSize = true;
            rbOption2.Location = new Point(87, 116);
            rbOption2.Name = "rbOption2";
            rbOption2.Size = new Size(91, 19);
            rbOption2.TabIndex = 9;
            rbOption2.Text = "Miss Scarlett";
            rbOption2.UseVisualStyleBackColor = true;
            rbOption2.Click += OptionSelected;
            // 
            // rbOption1
            // 
            rbOption1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rbOption1.AutoSize = true;
            rbOption1.Location = new Point(87, 91);
            rbOption1.Name = "rbOption1";
            rbOption1.Size = new Size(113, 19);
            rbOption1.TabIndex = 10;
            rbOption1.Text = "Colonel Mustard";
            rbOption1.UseVisualStyleBackColor = true;
            rbOption1.Click += OptionSelected;
            // 
            // lblPrompt
            // 
            lblPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPrompt.Location = new Point(27, 49);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(200, 35);
            lblPrompt.TabIndex = 4;
            lblPrompt.Text = "Choose the suspect";
            lblPrompt.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnAddGuess
            // 
            btnAddGuess.Location = new Point(181, 321);
            btnAddGuess.Name = "btnAddGuess";
            btnAddGuess.Size = new Size(77, 37);
            btnAddGuess.TabIndex = 14;
            btnAddGuess.Text = "Add Guess";
            btnAddGuess.UseVisualStyleBackColor = true;
            btnAddGuess.Click += btnAddGuess_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(30, 321);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 37);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(51, 104);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 2;
            label1.Text = "Suspect:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.Location = new Point(51, 127);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "Weapon:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.Location = new Point(51, 150);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 6;
            label3.Text = "Room:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(51, 173);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 8;
            label4.Text = "Guessing player:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(51, 196);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 10;
            label5.Text = "Responding player:";
            // 
            // lbl6
            // 
            lbl6.AutoSize = true;
            lbl6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl6.Location = new Point(23, 0);
            lbl6.Name = "lbl6";
            lbl6.Size = new Size(73, 15);
            lbl6.TabIndex = 0;
            lbl6.Text = "Shown card:";
            // 
            // lnkLSuspect
            // 
            lnkLSuspect.AutoSize = true;
            lnkLSuspect.Location = new Point(175, 104);
            lnkLSuspect.Name = "lnkLSuspect";
            lnkLSuspect.Size = new Size(47, 15);
            lnkLSuspect.TabIndex = 3;
            lnkLSuspect.TabStop = true;
            lnkLSuspect.Text = "Choose";
            lnkLSuspect.LinkClicked += lnkLSuspect_LinkClicked;
            // 
            // lnkLWeapon
            // 
            lnkLWeapon.AutoSize = true;
            lnkLWeapon.Location = new Point(175, 127);
            lnkLWeapon.Name = "lnkLWeapon";
            lnkLWeapon.Size = new Size(47, 15);
            lnkLWeapon.TabIndex = 5;
            lnkLWeapon.TabStop = true;
            lnkLWeapon.Text = "Choose";
            lnkLWeapon.LinkClicked += lnkLWeapon_LinkClicked;
            // 
            // lnkLRoom
            // 
            lnkLRoom.AutoSize = true;
            lnkLRoom.Location = new Point(175, 150);
            lnkLRoom.Name = "lnkLRoom";
            lnkLRoom.Size = new Size(47, 15);
            lnkLRoom.TabIndex = 7;
            lnkLRoom.TabStop = true;
            lnkLRoom.Text = "Choose";
            lnkLRoom.LinkClicked += lnkLRoom_LinkClicked;
            // 
            // lnkLGuesser
            // 
            lnkLGuesser.AutoSize = true;
            lnkLGuesser.Location = new Point(175, 173);
            lnkLGuesser.Name = "lnkLGuesser";
            lnkLGuesser.Size = new Size(47, 15);
            lnkLGuesser.TabIndex = 9;
            lnkLGuesser.TabStop = true;
            lnkLGuesser.Text = "Choose";
            lnkLGuesser.LinkClicked += lnkLGuesser_LinkClicked;
            // 
            // lnkLResponder
            // 
            lnkLResponder.AutoSize = true;
            lnkLResponder.Location = new Point(175, 196);
            lnkLResponder.Name = "lnkLResponder";
            lnkLResponder.Size = new Size(47, 15);
            lnkLResponder.TabIndex = 11;
            lnkLResponder.TabStop = true;
            lnkLResponder.Text = "Choose";
            lnkLResponder.LinkClicked += lnkLResponder_LinkClicked;
            // 
            // lnkLShownCard
            // 
            lnkLShownCard.AutoSize = true;
            lnkLShownCard.Location = new Point(147, 0);
            lnkLShownCard.Name = "lnkLShownCard";
            lnkLShownCard.Size = new Size(47, 15);
            lnkLShownCard.TabIndex = 1;
            lnkLShownCard.TabStop = true;
            lnkLShownCard.Text = "Choose";
            lnkLShownCard.LinkClicked += lnkLShownCard_LinkClicked;
            // 
            // pnlShownCard
            // 
            pnlShownCard.Controls.Add(lnkLShownCard);
            pnlShownCard.Controls.Add(lbl6);
            pnlShownCard.Location = new Point(28, 219);
            pnlShownCard.Name = "pnlShownCard";
            pnlShownCard.Size = new Size(264, 55);
            pnlShownCard.TabIndex = 12;
            pnlShownCard.Visible = false;
            // 
            // lblInstructions
            // 
            lblInstructions.Location = new Point(24, 42);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(241, 30);
            lblInstructions.TabIndex = 1;
            lblInstructions.Text = "Click each of the links to enter in a guess";
            lblInstructions.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(32, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(91, 19);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Add a Guess";
            lblHeader.TextAlign = ContentAlignment.TopCenter;
            // 
            // ClueGuessInputForm
            // 
            AcceptButton = btnAddGuess;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btnCancel;
            ClientSize = new Size(288, 382);
            Controls.Add(pnlPick);
            Controls.Add(lblHeader);
            Controls.Add(lblInstructions);
            Controls.Add(lnkLResponder);
            Controls.Add(lnkLGuesser);
            Controls.Add(lnkLRoom);
            Controls.Add(lnkLWeapon);
            Controls.Add(lnkLSuspect);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnAddGuess);
            Controls.Add(pnlShownCard);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClueGuessInputForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add a new guess";
            Load += ClueGuessInputForm_Load;
            pnlPick.ResumeLayout(false);
            pnlPick.PerformLayout();
            pnlPickShownCard.ResumeLayout(false);
            pnlPickShownCard.PerformLayout();
            pnlShownCard.ResumeLayout(false);
            pnlShownCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel pnlPick;
        private RadioButton rbOption6;
        private RadioButton rbOption5;
        private RadioButton rbOption4;
        private RadioButton rbOption3;
        private RadioButton rbOption2;
        private RadioButton rbOption1;
        private Label lblPrompt;
        private RadioButton rbOption9;
        private RadioButton rbOption8;
        private RadioButton rbOption7;
        private Button btnAddGuess;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lbl6;
        private LinkLabel lnkLSuspect;
        private LinkLabel lnkLWeapon;
        private LinkLabel lnkLRoom;
        private LinkLabel lnkLGuesser;
        private LinkLabel lnkLResponder;
        private LinkLabel lnkLShownCard;
        private Panel pnlShownCard;
        private Label lblInstructions;
        private Label lblHeader;
        private Button btnClose;
        private Panel pnlPickShownCard;
        private Label label8;
        private ComboBox cmbCardCategory;
    }
}