using PathFinder;
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using Thief_Game.Monsters;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс инициализации противника
    /// </summary>
    public class Monster : MovableGameObject
    {
        //Where is the monster going
        public int destinationX;
        public int destinationY;
        private int speed;
        public int Speed
        {
            get => speed;
        }
        public readonly int StartX;
        public readonly int StartY;

        //Monster's behavior
        Behaviors currentBehavior;

        /// <summary>
        /// Базовый класс монстра
        /// </summary>
        /// <param name="startX">Стартовая позиция</param>
        /// <param name="startY">Стартовая позиция</param>
        /// <param name="speed">Скорость</param>
        public Monster(int startX, int startY, int speed, string spriteName): base(Path.Combine(PathInfo.MonstersSpritesDir, spriteName))
        {
            //Если будем делать другие типы монстров, то они появятся, как
            //наследники этого класса
            this.speed = speed;
            StartX = startX;
            StartY = startY;

            X = startX;
            Y = startY;

            destinationX = 0;
            destinationY = 0;

            currentBehavior = Behaviors.DISPERSING;
        }

        /// <summary>
        /// Базовый алгоритм движения монстра (основан на Random)
        /// Используется, если метод не переопределен наследником
        /// </summary>
        public virtual void Move(int destinationX, int destinationY, Graph scheme)
        {
            var rnd = new Random();

            switch(rnd.Next(0, 4))
            {
                case 0:
                    MoveUp();
                    break;
                case 1:
                    MoveDown();
                    break;
                case 2:
                    MoveLeft();
                    break;
                case 3:
                    MoveRight();
                    break;
            }
        }

        /// <summary>
        /// Изменение координат
        /// </summary>
        public void MoveUp()
        {
            Y -= 1;
        }

        /// <summary>
        /// Изменение координат
        /// </summary>
        public void MoveLeft()
        {
            X -= 1;
        }

        /// <summary>
        /// Изменение координат
        /// </summary>
        public void MoveRight()
        {
            X += 1;
        }

        /// <summary>
        /// Изменение координат
        /// </summary>
        public void MoveDown()
        {
            Y += 1;
        }

        /// <summary>
        /// Изменение поведения монстра
        /// </summary>
        public void ChangeBehavior()
        {
        }

        /// <summary>
        /// Изменение внешнего вида монстра
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void SetView()
        {
            View = MonsterViewLoader.LoadImage("Blinky.png");
        }

        /// <summary>
        /// Отрисовка монстра во время движения
        /// </summary>
        /// <param name="graphics">Use for drawing</param>
        public void Redraw(Graphics graphics)
        {
            graphics.DrawImage(
                View, 
                CurrentPositionX * Dimensions.SpriteWidthPixels, 
                CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.LifeBarHeight, 
                Dimensions.SpriteWidthPixels, 
                Dimensions.SpriteHeightPixels);
        }

        /// <summary>
        /// Если монстр погиб, то его надо возродить
        /// </summary>
        public void Respawn()
        {
            X = StartX;
            Y = StartY;
        }
    }

    
}
