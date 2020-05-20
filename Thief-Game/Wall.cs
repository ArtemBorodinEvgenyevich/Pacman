using System.Drawing;
using System.IO;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Wall object init class
    /// </summary>
    public class Wall
    {
        public readonly int CurrentPositionX;
        public readonly int CurrentPositionY;

        // TODO: make static
        public readonly Image View;

        /// <summary>
        /// Wall init
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Wall(int x, int y)
        {
            View = Image.FromFile(Path.Combine(PathInfo.LevelSpritesDir, "Wall.png"));

            CurrentPositionX = x;
            CurrentPositionY = y;
        }
    }
}
