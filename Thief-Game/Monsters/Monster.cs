using System.Drawing;
using System.IO;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс инициализации противника
    /// </summary>
    public class Monster : MovableGameObject, IMovable
    {
        //Позиция монстра на карте
        
        //Start position;
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

        //Direction - возможно, понадобится для построения траекторий

        //Monster's behavior
        Behaviors currentBehavior;

        /// <summary>
        /// Базовый класс монстра
        /// </summary>
        /// <param name="startX">Стартовая позиция</param>
        /// <param name="startY"></param>
        /// <param name="speed"></param>
        public Monster(int startX, int startY, int speed, string spriteName): base(spriteName)
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
        /// Алгоритм движения монстра
        /// </summary>
        public virtual void Move()
        {

        }

        /// <summary>
        /// Изменение координат
        /// Maybe Virtual
        /// </summary>
        public void MoveUp()
        {
            Y -= 1;
        }

        /// <summary>
        /// Изменение координат
        /// Maybe Virtual
        /// </summary>
        public void MoveLeft()
        {
            X -= 1;
        }

        /// <summary>
        /// Изменение координат
        /// Maybe Virtual
        /// </summary>
        public void MoveRight()
        {
            X += 1;
        }

        /// <summary>
        /// Изменение координат
        /// Maybe Virtual
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
        /// Вычисляем, куда будет двигатся монстр
        /// Может быть тут и использовать MoveUp() и др.
        /// </summary>
        public void FindPath()
        {
        }

        /// <summary>
        /// Изменение внешнего вида монстра
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void SetView(string path)
        {
            View = MonsterViewLoader.LoadImage("Blinky.png");
        }

        /// <summary>
        /// Отрисовка монстра во время движения
        /// </summary>
        /// <param name="graphics"></param>
        public void Redraw(Graphics graphics)
        {
            graphics.DrawImage(
                View, 
                CurrentPositionX * Dimensions.SpriteWidthPixels, 
                CurrentPositionY * Dimensions.SpriteHeightPixels, 
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

    /// <summary>
    /// Типы поведения
    /// </summary>
    enum Behaviors
    {
        PURSUITING,
        DISPERSING,
        FRIGHTNING
    }
}
