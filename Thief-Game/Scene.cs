using System;
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
        float x = 0f;
        float y = 0f;

        public Scene()
        {
            KeyPress += (sender, e) =>
            {
                //MessageBox.Show("Press");

                switch (e.KeyChar)
                {
                    case 'w':
                        y -= 10;
                        break;
                    case 's':
                        y += 10;
                        break;
                    case 'a':
                        x -= 10;
                        break;
                    case 'd':
                        x += 10;
                        break;
                }

                Invalidate();
            };

            Paint += (sender, e) =>
            {
                //Image blinky = Image.FromFile(@"C:\C#\Thief-Game\Thief-Game\Source\Blinky.png");

                //var graphic = e.Graphics;

                //graphic.DrawImage(blinky, 10f, 10f);
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Image blinky = Image.FromFile(@"C:\C#\Thief-Game\Thief-Game\Source\Blinky.png");

            var graphic = e.Graphics;

            graphic.DrawImage(blinky, x, y);
        }
    }
}
