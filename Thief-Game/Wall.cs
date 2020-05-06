using System.Drawing;
using System.IO;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс загрузки спрайтов и инициализации игровых препятствий
    /// </summary>
    class Wall
    {
        public readonly int CurrentPositionX;
        public readonly int CurrentPositionY;

        //make static
        public readonly Image View;

        public Wall(int x, int y)
        {
            View = Image.FromFile(Path.Combine(PathInfo.SourceDir, @"Wall.png"));

            CurrentPositionX = x;
            CurrentPositionY = y;
        }
    }
}
