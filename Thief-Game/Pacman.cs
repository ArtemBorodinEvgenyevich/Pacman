using System.Drawing;
using System.IO;
using System;

namespace Thief_Game
{
    // Artem
    class Pacman : IMovable
    {
        private int X;
        private int Y;
        private int Speed;
        private int Lifes;

        public static int StartX;
        public static int StartY;

        public int DirectionX;
        public int DirectionY;

        public int CurrentPositionX => X;
        public int CurrentPositionY => Y;
        public int CurrentSpeed => Speed;
        public int CurrentLifes => Lifes;

        public Image View;

        public Pacman(int startX, int startY, int speed)
        {
            StartX = startX;
            StartY = startY;

            X = startX;
            Y = startY;
            Lifes = 3;

            this.Speed = speed;

            View = Image.FromFile(Path.Combine(PathInfo.SourceDir, "Pacman.png"));

            DirectionX = 0;
            DirectionY = 0;
        }

        public void MoveDown()
        {
            Y += Dimensions.StepY;
        }

        public void MoveLeft()
        {
            X -= Dimensions.StepX;
        }

        public void MoveRight()
        {
            X += Dimensions.StepX;
        }

        public void MoveUp()
        {
            Y -= Dimensions.StepY;
        }

        public void Redraw(Graphics graphics)
        {
            graphics.DrawImage(View, CurrentPositionX, CurrentPositionY, 30, 30);
        }

        public void Respawn()
        {
            // TODO: if Lifes == 0, then...
            Lifes -= 1;
            X = StartX;
            Y = StartY;

        }
    }
}
