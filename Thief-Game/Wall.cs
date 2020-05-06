//Lev

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Thief_Game
{
    class Wall
    {
        public readonly int X;
        public readonly int Y;

        public readonly Image View;

        public Wall(int x, int y)
        {
            View = Image.FromFile(@"C:\C#\Thief-Game\Thief-Game\Source\Wall.png");

            X = x;
            Y = y;
        }
    }
}
