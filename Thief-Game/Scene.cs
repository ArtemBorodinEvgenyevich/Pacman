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
        Action<Graphics> DrawMap;

        public Scene(Action<Graphics> DrawMap)
        {
            this.DrawMap = DrawMap;
            
            SetupWindow();

            //KeyPress += KeyPressListner;
            KeyDown += KeyPressListner2;
        }

        /// <summary>
        /// Обработка нажатий на клавиатуре
        /// Если пакман будет работать, то удалить метод KeyPressListner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="keyEventArgs"></param>
        private void KeyPressListner2(object sender, KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.KeyValue)
            {
                //68: right
                //65: left
                //case 83: down
                //87: up
            }
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
                    //Pacman.MoveUp();
                    break;
                case 's':
                    //Pacman.MoveDown();
                    break;
                case 'a':
                    //Pacman.MoveLeft();
                    break;
                case 'd':
                    //Pacman.MoveRight();
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
            DoubleBuffered = true;
            KeyPreview = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawMap(e.Graphics);
        }
    }
}
