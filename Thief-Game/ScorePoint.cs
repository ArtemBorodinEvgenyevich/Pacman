//Lev

using System;
using System.Collections.Generic;
using System.Text;

namespace Thief_Game
{
    class ScorePoint
    {
        public readonly int X;
        public readonly int Y;
        public bool IsActive;
        public const int Score = 10;

        public ScorePoint(int x, int y)
        {
            //Точки, которые дают очки
            X = x;
            Y = y;
            IsActive = true;
        }

        public void Eat()
        {
            IsActive = false;
        }
    }
}
