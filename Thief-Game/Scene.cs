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

            KeyPress += KeyPressListner;
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
