using System.Drawing;
using System.IO;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс загрузки спрайтов и инициализации игровых препятствий
    /// </summary>
    public class Wall: ImmovableGameObject
    {
        private int X;
        private int Y;
        public int CurrentPositionX
        {
            get => X;
        }
        public int CurrentPositionY
        {
            get => Y;
        }

        //make static
        public readonly Image View;

        public Wall(int x, int y)
        {
            View = Image.FromFile(Path.Combine(PathInfo.SourceDir, @"Wall.png"));

            X = x;
            Y = y;
        }
    }
}
