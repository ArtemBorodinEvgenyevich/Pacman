using System.Drawing;
using System.IO;

namespace Thief_Game
{
    // Artem
    /// <summary>
    /// Класс загрузки спрайта игрового персонажа   
    /// </summary>
    class PacmanViewLoader
    {
        public static Image LoadImage(string filename)
        {
            string path = Path.Combine(PathInfo.SourceDir, filename);
            return Image.FromFile(path);
        }
    }
}
