namespace Clue_Analyzer
{
    partial class SetCardSetForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetCardSetForm));
            rbEdition1 = new RadioButton();
            rbEdition2 = new RadioButton();
            rbEdition3 = new RadioButton();
            rbEdition4 = new RadioButton();
            label1 = new Label();
            btnSet = new Button();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // rbEdition1
            // 
            rbEdition1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rbEdition1.AutoSize = true;
            rbEdition1.Location = new Point(73, 64);
            rbEdition1.Name = "rbEdition1";
            rbEdition1.Size = new Size(220, 19);
            rbEdition1.TabIndex = 0;
            rbEdition1.Text = "North American Editions 1949 - 1962 ";
            toolTip1.SetToolTip(rbEdition1, resources.GetString("rbEdition1.ToolTip"));
            rbEdition1.UseVisualStyleBackColor = true;
            rbEdition1.CheckedChanged += CardSetChanged;
            // 
            // rbEdition2
            // 
            rbEdition2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rbEdition2.AutoSize = true;
            rbEdition2.Location = new Point(73, 89);
            rbEdition2.Name = "rbEdition2";
            rbEdition2.Size = new Size(217, 19);
            rbEdition2.TabIndex = 1;
            rbEdition2.Text = "North American Editions 1963 - 2015";
            toolTip1.SetToolTip(rbEdition2, resources.GetString("rbEdition2.ToolTip"));
            rbEdition2.UseVisualStyleBackColor = true;
            rbEdition2.CheckedChanged += CardSetChanged;
            // 
            // rbEdition3
            // 
            rbEdition3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rbEdition3.AutoSize = true;
            rbEdition3.Location = new Point(73, 114);
            rbEdition3.Name = "rbEdition3";
            rbEdition3.Size = new Size(217, 19);
            rbEdition3.TabIndex = 1;
            rbEdition3.Text = "North American Editions 2016 - 2022";
            toolTip1.SetToolTip(rbEdition3, resources.GetString("rbEdition3.ToolTip"));
            rbEdition3.UseVisualStyleBackColor = true;
            rbEdition3.CheckedChanged += CardSetChanged;
            // 
            // rbEdition4
            // 
            rbEdition4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rbEdition4.AutoSize = true;
            rbEdition4.Location = new Point(73, 139);
            rbEdition4.Name = "rbEdition4";
            rbEdition4.Size = new Size(155, 19);
            rbEdition4.TabIndex = 1;
            rbEdition4.Text = "UK Editions - 1949 - 2002";
            toolTip1.SetToolTip(rbEdition4, resources.GetString("rbEdition4.ToolTip"));
            rbEdition4.UseVisualStyleBackColor = true;
            rbEdition4.CheckedChanged += CardSetChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(85, 9);
            label1.Name = "label1";
            label1.Size = new Size(196, 21);
            label1.TabIndex = 2;
            label1.Text = "Select Your Clue card set";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSet
            // 
            btnSet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSet.Location = new Point(256, 205);
            btnSet.Name = "btnSet";
            btnSet.Size = new Size(87, 37);
            btnSet.TabIndex = 3;
            btnSet.Text = "Set";
            btnSet.UseVisualStyleBackColor = true;
            btnSet.Click += btnSet_Click;
            // 
            // SetCardSetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 252);
            Controls.Add(btnSet);
            Controls.Add(label1);
            Controls.Add(rbEdition4);
            Controls.Add(rbEdition3);
            Controls.Add(rbEdition2);
            Controls.Add(rbEdition1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SetCardSetForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Set Clue Card Set";
            Load += SetCardSetForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rbEdition1;
        private RadioButton rbEdition2;
        private RadioButton rbEdition3;
        private RadioButton rbEdition4;
        private Label label1;
        private Button btnSet;
        private ToolTip toolTip1;
    }
}