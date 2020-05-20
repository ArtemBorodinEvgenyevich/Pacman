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

    /// <summary>
    /// Main menu WinForm class
    /// </summary>
    public partial class MainMenu : Form
    {
        // TODO: Use enum
        public string GetAppState { get; set; }

        /// <summary>
        /// Main menu init
        /// </summary>
        public MainMenu()
        {   
            InitializeComponent();

            var pfc = InitCustomLabelFont();
            this.GameLabel.Font = new Font(pfc.Families[0], 20f);
            this.StartButton.Font = new Font(pfc.Families[0], 16f);
            this.ExitBtn.Font = new Font(pfc.Families[0], 16f);

            this.AnimTitle.ImageLocation = Path.Combine(PathInfo.GUISpritesDir, "gameAnimTitle.gif");
        }

        /// <summary>
        /// WinForm widget loading event (Do not delete!)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// External font loader
        /// </summary>
        /// <returns></returns>
        public PrivateFontCollection InitCustomLabelFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(Path.Combine(PathInfo.Fonts, "ka1.ttf"));

            return pfc;
        }

        /// <summary>
        /// Start button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            this.GetAppState = "RUN";
            Close();
        }

        /// <summary>
        /// Exit button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.GetAppState = "EXIT";
            Application.Exit();
        }

    }
}
