//Lev

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;

namespace Thief_Game
{
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
