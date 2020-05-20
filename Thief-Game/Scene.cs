using System;
using System.Drawing;
using System.Windows.Forms;
using Thief_Game.Constants;

namespace Thief_Game
{
    /// <summary>
    /// Level WinForm class
    /// </summary>
    public class Scene : Form
    {
        private Action<Graphics> DrawMap;
        private Action MoveUp;
        private Action MoveDown;
        private Action MoveLeft;
        private Action MoveRight;
        private Action<Graphics> Redraw;
        private Action CheckPointsCollision;
        private Timer MonsterTimer;
        private Action SerializeStats;
        private Func<bool> CheckWin;
        private Func<bool> CheckLoose;

        /// <summary>
        /// Actual game scene
        /// </summary>
        /// <param name="DrawMap"></param>
        /// <param name="MoveUp"></param>
        /// <param name="MoveDown"></param>
        /// <param name="MoveRight"></param>
        /// <param name="MoveLeft"></param>
        /// <param name="Redraw"></param>
        /// <param name="MoveMonster"></param>
        /// <param name="CheckPointsCollision"></param>
        /// <param name="SerializeStats"></param>
        /// <param name="CheckWin"></param>
        /// <param name="CheckLoose"></param>
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

            KeyDown += KeyPressListner;
            FormClosing += FormClosingListener;

            MonsterTimer = new Timer();
            MonsterTimer.Interval = 350;
            MonsterTimer.Tick += (s, e) =>
            {
                 MoveMonster();
                 Invalidate();
                 if (CheckLoose())
                    this.Close();
            };

            MonsterTimer.Start();
            Invalidate();    
        }

        /// <summary>
        /// Key press event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="keyEventArgs"></param>
        private void KeyPressListner(object sender, KeyEventArgs keyEventArgs)
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

        /// <summary>
        /// Form closing event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="closingEventArgs"></param>
        private void FormClosingListener(object sender, FormClosingEventArgs closingEventArgs)
        {
            SerializeStats();          
        }

        /// <summary>
        /// Window basic properties setup
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
        /// Form components painting
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawMap(e.Graphics);
            Redraw(e.Graphics);
        }
    }
}
