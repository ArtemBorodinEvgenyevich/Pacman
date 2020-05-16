using System.Drawing;
using System.IO;
using System;

namespace Thief_Game
{
    // Artem
    class Pacman : MovableGameObject, IMovable
    {
        private int Speed;
        private int Lifes;

        public static int StartX;
        public static int StartY;

        public int DirectionX;
        public int DirectionY;

        public int CurrentSpeed => Speed;
        public int CurrentLifes => Lifes;

        public Pacman(int startX, int startY, int speed): base("Pacman.png")
        {
            Lifes = 3;
            X = startX;
            Y = startY;

            this.Speed = speed;

            DirectionX = 0;
            DirectionY = 0;
        }

        public void MoveDown()
        {
            Y += 1;
        }

        public void MoveLeft()
        {
            X -= 1;
            if (X < 0)
                X = Dimensions.WindowWidthPixels / Dimensions.SpriteWidthPixels - 1;
        }

        public void MoveRight()
        {
            X += 1;
            if (X > Dimensions.WindowWidthPixels / Dimensions.SpriteWidthPixels - 1)
                X = 0;
        }

        public void MoveUp()
        {
            Y -= 1;
        }

        public void Redraw(Graphics graphics)
        {
            graphics.DrawImage(View, CurrentPositionX * Dimensions.SpriteWidthPixels, CurrentPositionY * Dimensions.SpriteHeightPixels, 30, 30);
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
