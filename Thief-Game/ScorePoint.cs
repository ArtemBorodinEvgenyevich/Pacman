using System.Drawing;
using System.IO;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс инициализации игровых очков
    /// </summary>
    public class ScorePoint
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
        public readonly int Score;
        public readonly Image View;

        public ScorePoint(int x, int y, int score, string fileName)
        {
            //Точки, которые дают очки
            X = x;
            Y = y;
            Score = score;
            View = Image.FromFile(Path.Combine(PathInfo.SourceDir, fileName));
        }
    }

    public class Energizer: ScorePoint
    {
        public Energizer(int x, int y): base(x, y, 10, @"Energizer.png")
        {
        }
    }

    public class SmallPoint: ScorePoint
    {
        public SmallPoint(int x, int y): base(x, y, 50, @"Coin.png")
        {
        }
    }
}
