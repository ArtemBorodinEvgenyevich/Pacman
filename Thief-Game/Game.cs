using System.Windows.Forms;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс инициализации игры
    /// </summary>
    class Game
    {
        public Game()
        {
            //var mainMenu = new MainMenu();
            //Application.Run(mainMenu);

            var worldStat = new WorldStat();
            var map = new Map();
        }
    }
}
