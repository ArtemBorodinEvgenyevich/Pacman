using System.Drawing;
using System.IO;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс инициализации противника
    /// </summary>
    class Monster : IMovable
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

        public Image View;

        /// <summary>
        /// Базовый класс монстра
        /// </summary>
        /// <param name="startX">Стартовая позиция</param>
        /// <param name="startY"></param>
        /// <param name="speed"></param>
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

            View = Image.FromFile(Path.Combine(PathInfo.SourceDir, @"Blinky.png"));

            destinationX = 0;
            destinationY = 0;

            currentBehavior = Behaviors.DISPERSING;
        }

        /// <summary>
        /// Изменение координат
        /// Maybe Virtual
        /// </summary>
        public void MoveUp()
        {
            Y -= Dimensions.StepY;
        }

        /// <summary>
        /// Изменение координат
        /// Maybe Virtual
        /// </summary>
        public void MoveLeft()
        {
            X -= Dimensions.StepX;
        }

        /// <summary>
        /// Изменение координат
        /// Maybe Virtual
        /// </summary>
        public void MoveRight()
        {
            X += Dimensions.StepX;
        }

        /// <summary>
        /// Изменение координат
        /// Maybe Virtual
        /// </summary>
        public void MoveDown()
        {
            Y += Dimensions.StepY;
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
            graphics.DrawImage(View, CurrentPositionX, CurrentPositionY, Dimensions.SpriteWidthPixels, Dimensions.SpriteHeightPixels);
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
