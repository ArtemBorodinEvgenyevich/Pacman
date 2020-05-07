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
            //var map = new Map();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainMenu());
            //Application.Run(new Scene());
            var game = new Game();
        }
    }
}
