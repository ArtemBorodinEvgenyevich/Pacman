namespace Thief_Game
{
    partial class ScoreBoard
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
            this.Score = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.ScoreTable = new System.Windows.Forms.ListBox();
            this.TotalScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Karmatic Arcade", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Score.Location = new System.Drawing.Point(98, 9);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(162, 44);
            this.Score.TabIndex = 0;
            this.Score.Text = "SCORE";
            // 
            // exitButton
            // 
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Karmatic Arcade", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exitButton.Location = new System.Drawing.Point(98, 438);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(194, 55);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // ScoreTable
            // 
            this.ScoreTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.ScoreTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScoreTable.CausesValidation = false;
            this.ScoreTable.ItemHeight = 20;
            this.ScoreTable.Location = new System.Drawing.Point(47, 154);
            this.ScoreTable.Name = "ScoreTable";
            this.ScoreTable.Size = new System.Drawing.Size(296, 240);
            this.ScoreTable.TabIndex = 2;
            // 
            // TotalScore
            // 
            this.TotalScore.AutoSize = true;
            this.TotalScore.Location = new System.Drawing.Point(47, 110);
            this.TotalScore.Name = "TotalScore";
            this.TotalScore.Size = new System.Drawing.Size(51, 20);
            this.TotalScore.TabIndex = 3;
            this.TotalScore.Text = "label1";
            // 
            // ScoreBoard
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.ClientSize = new System.Drawing.Size(395, 505);
            this.Controls.Add(this.TotalScore);
            this.Controls.Add(this.ScoreTable);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.Score);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScoreBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ListBox ScoreTable;
        private System.Windows.Forms.Label TotalScore;
    }
}