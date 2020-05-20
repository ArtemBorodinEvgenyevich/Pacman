namespace Thief_Game
{
    partial class MainMenu
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
            this.GameLabel = new System.Windows.Forms.Label();
            this.AnimTitle = new System.Windows.Forms.PictureBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AnimTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // GameLabel
            // 
            this.GameLabel.AutoSize = true;
            this.GameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GameLabel.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GameLabel.Location = new System.Drawing.Point(70, 41);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(247, 120);
            this.GameLabel.TabIndex = 0;
            this.GameLabel.Text = "PACMAN\r\nTHE GAME";
            this.GameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AnimTitle
            // 
            this.AnimTitle.Location = new System.Drawing.Point(79, 164);
            this.AnimTitle.Name = "AnimTitle";
            this.AnimTitle.Size = new System.Drawing.Size(227, 116);
            this.AnimTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AnimTitle.TabIndex = 3;
            this.AnimTitle.TabStop = false;
            // 
            // StartButton
            // 
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Location = new System.Drawing.Point(100, 342);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(194, 55);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Location = new System.Drawing.Point(100, 418);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(194, 55);
            this.ExitBtn.TabIndex = 5;
            this.ExitBtn.Text = "EXIT";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.ClientSize = new System.Drawing.Size(395, 505);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.AnimTitle);
            this.Controls.Add(this.GameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AnimTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GameLabel;
        public System.Windows.Forms.PictureBox AnimTitle;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ExitBtn;
    }
}