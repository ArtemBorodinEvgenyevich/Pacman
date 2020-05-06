using System.Drawing;

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

            View = null;

            DirectionX = 0;
            DirectionY = 0;
        }


        public void MoveDown()
        {
            Y -= 10;
        }

        public void MoveLeft()
        {
            X += 10;
        }

        public void MoveRight()
        {
            X += 10;
        }

        public void MoveUp()
        {
            Y += 10;
        }

        public void SetView(string path)
        {
            View = PacmanViewLoader.LoadImage("Pacman.png");
        }

        public void Redraw(Graphics graphics)
        {
            graphics.DrawImage(View, CurrentPositionX, CurrentPositionY);
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
