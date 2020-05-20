using System;
using System.Windows.Forms;

namespace Thief_Game
{
    /// <summary>
    /// Класс инициализации программы
    /// </summary>
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var game = new Game();
            //Application.Run(game);
        }
    }
}
