using System;
using System.Windows.Forms;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс инициализации игры
    /// </summary>
    class Game
    {
        // TODO: Use enum
        private string State;

        /// <summary>
        /// Main game class
        /// </summary>
        public Game()
        {
            var mainMenu = new MainMenu();
            Application.Run(mainMenu);
            State = mainMenu.GetAppState;

            if (State == "RUN")
            {
                RunGame();
                ShowScoreBoard();
            }

            Application.Exit();
        }

        /// <summary>
        /// Start game
        /// </summary>
        private void RunGame() 
        {
            var map = new Map();
        }

        /// <summary>
        /// At the end
        /// </summary>
        private void ShowScoreBoard()
        {
            Application.Run(new ScoreBoard());
        }
    }
}
