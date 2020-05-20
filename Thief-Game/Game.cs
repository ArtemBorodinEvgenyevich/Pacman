using System;
using System.Windows.Forms;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Game init class
    /// </summary>
    class Game
    {
        // TODO: Use enum
        private string State;

        /// <summary>
        /// Starting point for game running
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
        /// Start level initilizer
        /// </summary>
        private void RunGame() 
        {
            var map = new Map();
        }

        /// <summary>
        /// Show score board with results
        /// </summary>
        private void ShowScoreBoard()
        {
            Application.Run(new ScoreBoard());
        }
    }
}
