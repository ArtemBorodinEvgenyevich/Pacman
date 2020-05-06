//Lev

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thief_Game
{
    public class Scene : Form
    {
        Monster Blinky;

        public Scene()
        {
            SetupWindow();

            Blinky = new Monster(0, 0, 10);
            Blinky.SetView(null);

            var ll = new LevelLoader();
            var scene = ll.ParseFile();

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
            switch (keyPressEventArgs.KeyChar)
            {
                case 'w':
                    Blinky.MoveUp();
                    break;
                case 's':
                    Blinky.MoveDown();
                    break;
                case 'a':
                    Blinky.MoveLeft();
                    break;
                case 'd':
                    Blinky.MoveRight();
                    break;
            }

            Invalidate();
        }

        /// <summary>
        /// Установка размеров окна
        /// </summary>
        private void SetupWindow()
        {
            ClientSize = new Size(Dimensions.WindowWidth, Dimensions.WindowHeight);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //var graphic = e.Graphics;
            //graphic.DrawImage(Blinky.View, Blinky.CurrentPositionX, Blinky.CurrentPositionY);

            //e.Graphics.DrawImage(Blinky.View, 0f, 0f, 15f, 15f);

            Blinky.Redraw(e.Graphics);
        }
    }
}
