using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Thief_Game
{
    class Monster: IMovable
    {
        //Позиция монстра на карте
        private int X;
        private int Y;
        public int CurrentPositionX
        {
            get => X;
        }
        public int CurrentPositionY
        {
            get => Y;
        }
        //Start position;
        public readonly int StartX;
        public readonly int StartY;
        //Where is the monster going
        public int destinationX;
        public int destinationY;
        private int speed;
        public int Speed
        {
            get => speed;
        }

        //Direction - возможно, понадобится для построения траекторий

        //Monster's behavior
        Behaviors currentBehavior;
        
        //Monster view
        public Image View;

        public Monster(int startX, int startY, int speed)
        {
            //Если будем делать другие типы монстров, то они появятся, как
            //наследники этого класса
            //Init
            StartX = startX;
            StartY = startY;

            X = startX;
            Y = startY;

            this.speed = speed;

            View = null;

            destinationX = 0;
            destinationY = 0;

            currentBehavior = Behaviors.DISPERSING;
        }
        
        public void MoveUp()
        {
            //Maybe virtual
            //Изменение координат
            Y -= 10;
        }

        public void MoveLeft()
        {
            //Maybe virtual
            //Изменение координат
            X -= 10;
        }

        public void MoveRight()
        {
            //Maybe virtual
            //Изменение координат
            X += 10;
        }

        public void MoveDown()
        {
            //Maybe virtual
            //Изменение координат
            Y += 10;
        }

        public void ChangeBehavior()
        {
            //Изменение поведения монстра
        }

        public void FindPath()
        {
            //Вычисляем куда будет монстр двигаться 
            //Мб, тут будем использовать MoveUp() и др.
        }

        public void SetView(string path)
        {
            //Изменение внешнего вида монстра
            View = Image.FromFile(path);
        }

        public void Redraw(Graphics graphics)
        {
            //Отрисовка монстра во время движения
            graphics.DrawImage(View, CurrentPositionX, CurrentPositionY);
        }

        public void Respawn()
        {
            //Если монстр погиб, то его надо возродить
            X = StartX;
            Y = StartY;
        }
    }

    enum Behaviors
    {
        PURSUITING,
        DISPERSING,
        FRIGHTNING
    }
}
