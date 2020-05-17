using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using PathFinder;

namespace Thief_Game
{
    public class Blinky: Monster
    {
        public Blinky(int startX, int startY, int speed): base(startX, startY, speed, @"Blinky.png")
        {

        }

        public override void Move(int destinationX, int destinationY, Graph scheme)
        {
            if ((destinationX == X) && (destinationY == Y)) return;

            var start = scheme[X, Y];
            var destination = scheme[destinationX, destinationY];

            var path = scheme.FindPath(start, destination);

            Waypoint step;
            if (path.Count > 1)
                step = path[1];
            else
                step = path[0];

            var dx = step.X - X;
            var dy = step.Y - Y;

            if (dx < 0)
                MoveLeft();
            else if (dx > 0)
                MoveRight();
            else if (dy < 0)
                MoveUp();
            else
                MoveDown();
        }
    }
}
