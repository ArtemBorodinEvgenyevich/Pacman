using System;
using System.Collections.Generic;
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

        public override void Move(bool isUp, bool isDown, bool isLeft, bool isRight, int destinationX, int destinationY, int dx0, int dy0, Graph scheme)
        {
            if ((destinationX == X) && (destinationY == Y)) return;

            if (dx0 > 0)
            {
                destinationX += 4;
            }
            if (dx0 < 0)
            {
                destinationX -= 4;
            }
            if (dy0 > 0)
            {
                destinationY += 4;
            }
            if (dy0 < 0)
            {
                destinationY -= 4;
            }

            for(int d = 0; d <= 4; d++)
            {
                if (scheme.Contains(destinationX - d, destinationY))
                {
                    destinationX -= d;
                    break;
                }
                if (scheme.Contains(destinationX + d, destinationY))
                {
                    destinationX += d;
                    break;
                }
                if (scheme.Contains(destinationX, destinationY - d))
                {
                    destinationY -= d;
                    break;
                }
                if (scheme.Contains(destinationX, destinationY + d))
                {
                    destinationY += d;
                    break;
                }
            }

            var start = scheme[X, Y];
            var finish = scheme[destinationX, destinationY];

            var path = scheme.FindPath(start, finish);

            Node step;
            if (path.Count > 1)
                step = path[1];
            else
                step = path[0];

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
