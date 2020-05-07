using System.Drawing;
using System.IO;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс инициализации игровых очков
    /// </summary>
    class ScorePoint
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
        public const int Score = 10;
        public readonly Image View;

        public ScorePoint(int x, int y)
        {
            //Точки, которые дают очки
            X = x;
            Y = y;

            View = Image.FromFile(Path.Combine(PathInfo.SourceDir, @"Coin.png"));
        }
    }
}
