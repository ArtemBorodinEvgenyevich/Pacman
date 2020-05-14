using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thief_Game
{
    public class MainMenu : Form
    {
        private Button NewGame;
        private Button Exit;

        public MainMenu()
        {
            SetupWindow();
            InitButtons();
        }
        
        /// <summary>
        /// Установка размеров окна
        /// </summary>
        private void SetupWindow()
        {
            ClientSize = new Size(Dimensions.WindowWidthPixels, Dimensions.WindowHeightPixels);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        /// <summary>
        /// Инициализация кнопок
        /// </summary>
        private void InitButtons()
        { 
            NewGame = new Button();
            NewGame.Text = "New Game";
            NewGame.Width = 100;
            NewGame.Height = 40;
            NewGame.Location = new Point(Width /2 - NewGame.Width/2, Height / 2 - NewGame.Height/2);
            NewGame.Click += (s, e) => Close();
            Controls.Add(NewGame);

            Exit = new Button();
            Exit.Text = "Exit";
            Exit.Width = 100;
            Exit.Height = 40;
            Exit.Location = new Point(Width / 2 - Exit.Width / 2, Height / 2 + Exit.Height/2);
            Exit.Click += (s, e) => Application.Exit();
            Controls.Add(Exit);
        }
    }
}
