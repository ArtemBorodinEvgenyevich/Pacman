//Lev

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Thief_Game.Constants;

namespace Thief_Game
{
    /// <summary>
    /// Класс формы окна
    /// </summary>
    public class Scene : Form
    {
        private Action<Graphics> DrawMap;
        private Action MoveUp;
        private Action MoveDown;
        private Action MoveLeft;
        private Action MoveRight;
        private Button NewGameBTN;
        private Button ExitBTN;
        private GameMode Mode;
        private Action<Graphics> Redraw;
        private Action CheckPointsCollision;
        private Timer MonsterTimer;
        private Action SerializeStats;
        private Func<bool> CheckWin;
        private Func<bool> CheckLoose;

        public Scene(
            Action<Graphics> DrawMap, 
            Action MoveUp, 
            Action MoveDown, 
            Action MoveRight, 
            Action MoveLeft, 
            Action<Graphics> Redraw, 
            Action MoveMonster,
            Action CheckPointsCollision,
            Action SerializeStats,
            Func<bool> CheckWin,
            Func<bool> CheckLoose)
        {
            //Mode = GameMode.MENU;
            
            Mode = GameMode.GAME;
            
            this.DrawMap = DrawMap;

            this.MoveDown = MoveDown;
            this.MoveUp = MoveUp;
            this.MoveLeft = MoveLeft;
            this.MoveRight = MoveRight;
            this.Redraw = Redraw;

            this.CheckPointsCollision = CheckPointsCollision;

            this.SerializeStats = SerializeStats;

            this.CheckWin = CheckWin;
            this.CheckLoose = CheckLoose;
            
            SetupWindow();

            //if (Mode == GameMode.MENU)
                //InitButtons();

            //KeyPress += KeyPressListner;
            KeyDown += KeyPressListner;
            FormClosing += FormClosingListener;

            MonsterTimer = new Timer();
            MonsterTimer.Interval = 300;
            MonsterTimer.Tick += (s, e) =>
            {
                 MoveMonster();
                 Invalidate();
                 if (CheckLoose())
                    this.Close();
            };
        
        // Пока что переместил с InitButtons
        // ----------------------------------
            MonsterTimer.Start();
            Invalidate();
        // ----------------------------------
        }

        /// <summary>
        /// Обработка нажатий на клавиатуре
        /// Если пакман будет работать, то удалить метод KeyPressListner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="keyEventArgs"></param>
        private void KeyPressListner(object sender, KeyEventArgs keyEventArgs)
        {
            if (Mode == GameMode.GAME)
            {
                switch (keyEventArgs.KeyValue)
                {
                    case KeyCodes.KeyDown:
                        MoveDown();
                        break;
                    case KeyCodes.KeyUp:
                        MoveUp();
                        break;
                    case KeyCodes.KeyRight:
                        MoveRight();
                        break;
                    case KeyCodes.KeyLeft:
                        MoveLeft();
                        break;
                }

                if (this.CheckWin())
                    this.Close();

                CheckPointsCollision();

                Invalidate();
            }
        }

        // Temporary solution. 
        // TODO: rewrite later...
        private void FormClosingListener(object sender, FormClosingEventArgs closingEventArgs)
        {
            SerializeStats();          
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
        /// Drawing!!!
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawMap(e.Graphics);
            Redraw(e.Graphics);
        }

        /*
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Scene
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "Scene";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }*/
    }
}
