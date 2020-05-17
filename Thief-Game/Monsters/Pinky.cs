using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Security.Cryptography;
using System.Text;
using PathFinder;

namespace Thief_Game.Monsters
{
    public class Pinky: Monster
    {
        public Pinky(int startX, int startY, int speed) : base(startX, startY, speed, @"Pinky.png")
        {

        }

        public override void Move(int destinationX, int destinationY, Graph scheme)
        {
            if ((destinationX == X) && (destinationY == Y)) return;

            var start = scheme[X, Y];
            var destination = scheme.FindNearestNode(destinationX, destinationY);

            var path = scheme.FindPath(start, destination);

            Node step;
            if (path.Count > 1)
                step = path[1];
            else
                step = path[0];

            var dx = step.X - X;
            var dy = step.Y - Y;

            if ((dx < 0) && (scheme.Contains(X - 1, Y)))
                MoveLeft();
            else if ((dx > 0) && (scheme.Contains(X + 1, Y)))
                MoveRight();
            else if ((dy < 0) && (scheme.Contains(X, Y - 1)))
                MoveUp();
            else if ((dy > 0) && (scheme.Contains(X, Y + 1)))
                MoveDown();
        }
    }
}
