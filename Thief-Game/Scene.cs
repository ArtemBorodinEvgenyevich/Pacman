﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thief_Game
{
    public partial class Scene : Form
    {
        Monster Blinky;

        public Scene()
        {
            Blinky = new Monster(0, 0, 10);
            Blinky.SetView(@"C:\C#\Thief-Game\Thief-Game\Source\Blinky.png");

            KeyPress += (sender, e) =>
            {
                switch (e.KeyChar)
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
            };

            //Происходит событие, предварительная обработка, отправка в Game
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //var graphic = e.Graphics;
            //graphic.DrawImage(Blinky.View, Blinky.CurrentPositionX, Blinky.CurrentPositionY);

            Blinky.Redraw(e.Graphics);
        }
    }
}
