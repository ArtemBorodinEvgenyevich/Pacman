using System;
using System.Windows.Forms;

namespace Thief_Game
{
    /// <summary>
    /// Application init class
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Application entry point
        /// Application is single threaded
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var game = new Game();
        }
    }
}
