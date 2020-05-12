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
        Action PacmanMove;
        private Button NewGameBTN;
        private Button ExitBTN;
        private GameMode Mode;
        private Action<Graphics> Redraw;

        public Scene(Action<Graphics> DrawMap, Action Move, Action<Graphics> Redraw)
        {
            Mode = GameMode.MENU;
            this.DrawMap = DrawMap;
            this.PacmanMove = Move;
            this.Redraw = Redraw;
            
            SetupWindow();
            
            if(Mode == GameMode.MENU)
                InitButtons();

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
            if (Mode == GameMode.GAME)
            {
                switch (keyEventArgs.KeyValue)
                {
                    case 68:
                        MessageBox.Show("S");
                        PacmanMove();
                        Invalidate();
                        break;
                    //68: right
                    //65: left
                    //case 83: down
                    //87: up
                }
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

        /// <summary>
        /// Init buttons
        /// </summary>
        private void InitButtons()
        {
            var newGameButtonStartX = Dimensions.WindowWidthPixels / 2 - Dimensions.ButtonWidth / 2; 
            var newGameButtonsStartY = Dimensions.WindowHeightPixels / 2 - Dimensions.ButtonHeight;
            var exitButtonStartX = newGameButtonStartX;
            var exitButtonStartY = newGameButtonsStartY + Dimensions.ButtonHeight;

            NewGameBTN = new Button();
            NewGameBTN.Width = Dimensions.ButtonWidth;
            NewGameBTN.Height = Dimensions.ButtonHeight;
            NewGameBTN.Text = "Start new game";
            NewGameBTN.Location = new Point(newGameButtonStartX, newGameButtonsStartY);
            NewGameBTN.Click += (sender, args) =>
            {
                Controls.Remove(ExitBTN);
                Controls.Remove(NewGameBTN);
                Mode = GameMode.GAME;
                Invalidate();
            };
            NewGameBTN.BackColor = Color.WhiteSmoke;
            Controls.Add(NewGameBTN);

            ExitBTN = new Button();
            ExitBTN.Width = Dimensions.ButtonWidth;
            ExitBTN.Height = Dimensions.ButtonHeight;
            ExitBTN.Text = "Exit";
            ExitBTN.Location = new Point(exitButtonStartX, exitButtonStartY);
            ExitBTN.Click += (sender, args) =>
            {
                Close();
            };
            ExitBTN.BackColor = Color.WhiteSmoke;
            Controls.Add(ExitBTN);
        }
        
        /// <summary>
        /// Main menu background
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawButtonsBackground(Graphics graphics)
        {
            var startX = NewGameBTN.Location.X - Dimensions.Padding;
            var startY = NewGameBTN.Location.Y - Dimensions.Padding;
            var width = Dimensions.Padding * 2 + Dimensions.ButtonWidth;
            var height = Dimensions.Padding * 2 + Dimensions.ButtonHeight * 2;

            graphics.FillRectangle(Brushes.Chartreuse, startX, startY, width, height);
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawMap(e.Graphics);
            Redraw(e.Graphics);

            if (Mode == GameMode.MENU)
                DrawButtonsBackground(e.Graphics);
        }
    }
}
