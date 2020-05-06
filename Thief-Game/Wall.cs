using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;

namespace Thief_Game
{
    class Wall
    {
        public readonly int X;
        public readonly int Y;

        public readonly Image View;

        public Wall(int x, int y)
        {
            View = Image.FromFile(Path.Combine(PathInfo.SourceDir, @"Wall.png"));

            X = x;
            Y = y;
        }
    }
}
