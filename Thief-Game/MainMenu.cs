using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Thief_Game
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            var pfc = InitCustomLabelFont();
            this.GameLabel.Font = new Font(pfc.Families[0], 20f);
            this.StartButton.Font = new Font(pfc.Families[0], 16f);
            this.ExitBtn.Font = new Font(pfc.Families[0], 16f);

            this.AnimTitle.ImageLocation = Path.Combine(PathInfo.GUISpritesDir, "gameAnimTitle.gif");
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
           
        }

        public PrivateFontCollection InitCustomLabelFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(Path.Combine(PathInfo.Fonts, "ka1.ttf"));

            return pfc;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
