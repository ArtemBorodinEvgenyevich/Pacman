using System.Drawing;
using System.IO;

namespace Thief_Game
{
    // Artem
    class PacmanViewLoader
    {
        public static Image LoadImage(string filename)
        {
            string path = Path.Combine(PathInfo.SourceDir, filename);
            return Image.FromFile(path);
        }
    }
}
