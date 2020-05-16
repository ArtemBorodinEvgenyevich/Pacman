using System;
using System.Collections.Generic;
using System.Text;
using PathFinder;

namespace Thief_Game
{
    public class Blinky: Monster
    {
        public Blinky(int startX, int startY, int speed): base(startX, startY, speed, @"Blinky.png")
        {

        }

        public override void Move(bool isUp, bool isDown, bool isLeft, bool isRight, int destinationX, int destinationY, Graph scheme)
        {
            if ((destinationX == X) && (destinationY == Y)) return;

            var start = scheme[X, Y];
            var finish = scheme[destinationX, destinationY];

            var path = scheme.FindPath(start, finish);

            var step = path[1];

            var dx = step.X - X;
            var dy = step.Y - Y;

            if ((dx > 0))
                MoveRight();
            if ((dx < 0))
                MoveLeft();
            if ((dy > 0))
                MoveDown();
            if ((dy < 0))
                MoveUp();
        }
    }
}
