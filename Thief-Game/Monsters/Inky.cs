using System;
using System.Collections.Generic;
using System.Text;
using PathFinder;

namespace Thief_Game.Monsters
{
    public class Inky: Monster
    {
        public Inky(int startX, int startY, int speed):base(startX, startY, speed, @"Inky.png")
        {

        }

        public override void Move(int startX, int startY, int destinationX, int destinationY, Graph scheme)
        {
            if ((destinationX == X) && (destinationY == Y)) return;

            var start = scheme[X, Y];
            var destination = scheme[destinationX, destinationY];

            var path = scheme.FindPath(start, destination);

            Node step;
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
