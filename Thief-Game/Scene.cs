//Lev

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Thief_Game
{
    /// <summary>
    /// Класс формы окна
    /// </summary>
    public class Scene : Form
    {
        //Monster Blinky;

        //Pacman Pacman;

        Map Map;

        Action<Graphics> DrawMap;
        IMovable Pacman;

        //Протащить делегаты - реакции на нажатие кнопок
        public Scene(Action<Graphics> DrawMap, IMovable Pacman)
        {
            this.DrawMap = DrawMap;
            this.Pacman = Pacman;
            
            SetupWindow();

            DoubleBuffered = true;

            //Map = new Map();

            //Blinky = new Monster(0, 0, 10);
            //Blinky.SetView(null);

            //Pacman = new Pacman(10, 10, 10);
            //Pacman.SetView(null);

            //var ll = new LevelLoader();
            //var scene = ll.ParseFile();

            KeyPreview = true;

            KeyPress += KeyPressListner;

            //Происходит событие, предварительная обработка, отправка в Game
        }

        /// <summary>
        /// Обработка нажатий на клавиаутуру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="keyPressEventArgs"></param>
        private void KeyPressListner(object sender, KeyPressEventArgs keyPressEventArgs)
        {
            //Уйти от английской раскладки
            //IsKeyDown
            switch (keyPressEventArgs.KeyChar)
            {
                case 'w':
                    //Blinky.MoveUp();
                    //Pacman.MoveUp();
                    //Map.MovePacmanUp();
                    Pacman.MoveUp();
                    break;
                case 's':
                    //Blinky.MoveDown();
                    //Pacman.MoveDown();
                    //Map.MovePacmanDown();
                    Pacman.MoveDown();
                    break;
                case 'a':
                    //Blinky.MoveLeft();
                    //Pacman.MoveLeft();
                    //Map.MovePacmanLeft();
                    Pacman.MoveLeft();
                    break;
                case 'd':
                    //Blinky.MoveRight();
                    //Pacman.MoveRight();
                    //Map.MovePacmanRight();
                    Pacman.MoveRight();
                    break;
            }

            Invalidate();
        }

        /// <summary>
        /// Установка размеров окна
        /// </summary>
        private void SetupWindow()
        {
            ClientSize = new Size(Dimensions.WindowWidthPixels, Dimensions.WindowHeightPixels);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //var graphic = e.Graphics;
            //graphic.DrawImage(Blinky.View, Blinky.CurrentPositionX, Blinky.CurrentPositionY);

            //e.Graphics.DrawImage(Blinky.View, 0f, 0f, 15f, 15f);

            //Map.Draw(e.Graphics);
            //Map.ReDraw(e.Graphics);
            DrawMap(e.Graphics);
            //Blinky.Redraw(e.Graphics);

            //Pacman.Redraw(e.Graphics);
        }
    }
}
