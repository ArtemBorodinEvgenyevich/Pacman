using System.Drawing;
using System.IO;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Score point class init
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

        /// <summary>
        /// Score point object init
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="score"></param>
        /// <param name="fileName"></param>
        public ScorePoint(int x, int y, int score, string fileName)
        {
            X = x;
            Y = y;
            Score = score;
            View = Image.FromFile(Path.Combine(PathInfo.CoinsSpritesDir, fileName));
        }
    }

    /// <summary>
    /// Big coin init class
    /// </summary>
    public class Energizer: ScorePoint
    {
        public Energizer(int x, int y): base(x, y, 10, @"Energizer.png")
        {
        }
    }

    /// <summary>
    /// Small coin init class
    /// </summary>
    public class SmallPoint: ScorePoint
    {
        public SmallPoint(int x, int y): base(x, y, 50, @"Coin.png")
        {
        }
    }
}
