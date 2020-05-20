using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using PathFinder;
using System.Runtime.Intrinsics.X86;
using Thief_Game.Constants;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс инициализации игрового уровня
    /// </summary>
    class Map
    {
        //private Action MainMenuClose;
        
        private List<Wall> Walls;
        private List<Monster> Monsters;
        private Pacman Pacman;
        private List<SmallPoint> Points;
        private List<Energizer> Energizers;

        private Graph LevelScheme;
        // temporary
        private WorldStat WorldStat;

        /// <summary>
        /// Create map with monsters and others
        /// </summary>
        public Map()
        {
            //this.MainMenuClose = MenuClose;
            
            var pattern = new LevelLoader().ParseFile();

            InitAllLists(pattern);
            InitWalls(pattern);
            InitMonsters(pattern);
            InitPlayer(pattern);
            InitSmallPoints(pattern);
            InitEnergizers(pattern);

            Application.Run(new Scene(Draw, MovePacmanUp, MovePacmanDown, MovePacmanRight, MovePacmanLeft, 
                Redraw, Move, CheckPointsCollision, SerializeStats, CheckWin, CheckLoose));
            //var scene = new Scene(Draw, MovePacmanUp, MovePacmanDown, MovePacmanRight, MovePacmanLeft, Redraw, Move, CheckPointsCollision, SerializeStats, CheckWin);
            //this.MainMenuClose();
            //scene.ShowDialog();
        }

        /// <summary>
        /// Init all lists
        /// </summary>
        /// <param name="pattern">Pattern of current level</param>
        private void InitAllLists(LevelPattern pattern)
        {
            Walls = new List<Wall>();
            Monsters = new List<Monster>();
            Points = new List<SmallPoint>();
            Energizers = new List<Energizer>();
            LevelScheme = pattern.LevelScheme;
            WorldStat = new WorldStat();
        }

        /// <summary>
        /// ???
        /// </summary>
        private void SerializeStats()
        {
            var serializer = new WorldStatPickle();
            serializer.DataSerialize(WorldStat.ScoreTotal);
        }

        /// <summary>
        /// Init all walls
        /// </summary>
        /// <param name="pattern">Level patter</param>
        private void InitWalls(LevelPattern pattern)
        {
            foreach (var wall in pattern.Walls)
            {
                Walls.Add(wall);
            }
        }

        /// <summary>
        /// Init all monsters
        /// </summary>
        /// <param name="pattern">Level pattern</param>
        public void InitMonsters(LevelPattern pattern)
        {
            foreach (var monster in pattern.MonsterSpawns)
                Monsters.Add(monster);
        }

        /// <summary>
        /// Init pacman
        /// </summary>
        /// <param name="pattern">LevelPacman</param>
        public void InitPlayer(LevelPattern pattern)
        {
            Pacman = new Pacman(Pacman.StartX, Pacman.StartY, 10);
        }

        /// <summary>
        /// Init small yellow points
        /// </summary>
        /// <param name="pattern">Level pattern</param>
        public void InitSmallPoints(LevelPattern pattern)
        {
            foreach(var point in pattern.SmallPoints)
                Points.Add(point);
        }

        /// <summary>
        /// Init big yellow points
        /// </summary>
        /// <param name="pattern">Level pattern</param>
        public void InitEnergizers(LevelPattern pattern)
        {
            foreach(var energizer in pattern.Energizers)
                Energizers.Add(energizer);
        }

        /// <summary>
        /// Move Blinky
        /// </summary>
        private void MoveBlinky()
        {
            Monsters[0].Move(Pacman.CurrentPositionX, Pacman.CurrentPositionY, LevelScheme);
        }

        /// <summary>
        /// Move Pinky
        /// </summary>
        private void MovePinky()
        {
            var dx = Pacman.CurrentPositionX - Pacman.previousX;
            var dy = Pacman.CurrentPositionY - Pacman.previousY;

            if (dx > 0)
                Monsters[2].Move(Pacman.CurrentPositionX + 4, Pacman.CurrentPositionY, LevelScheme);
            else if (dx < 0)
                Monsters[2].Move(Pacman.CurrentPositionX - 4, Pacman.CurrentPositionY, LevelScheme);
            else if (dy < 0)
                Monsters[2].Move(Pacman.CurrentPositionX, Pacman.CurrentPositionY - 4, LevelScheme);
            else
                Monsters[2].Move(Pacman.CurrentPositionX, Pacman.CurrentPositionY + 4, LevelScheme);
        }

        /// <summary>
        /// Move Inky
        /// </summary>
        private void MoveInky()
        {
            var dx = Pacman.CurrentPositionX - Pacman.previousX;
            var dy = Pacman.CurrentPositionY - Pacman.previousY;

            if (dx > 0)
                dx = 2;
            else if (dx < 0)
                dx = -2;
            else if (dy < 0)
                dy = -2;
            else
                dy = 2;

            var hX = (Pacman.CurrentPositionX + dx - Monsters[0].CurrentPositionX) * 2 + Monsters[0].CurrentPositionX;
            var hY = (Pacman.CurrentPositionY + dy - Monsters[0].CurrentPositionY) * 2 + Monsters[0].CurrentPositionY;

            Monsters[1].Move(hX, hY, LevelScheme);
        }

        /// <summary>
        /// Move CLyde
        /// </summary>
        private void MoveClyde()
        {
            var clydePos = new Waypoint(Monsters[3].CurrentPositionX, Monsters[3].CurrentPositionY);
            var pacmanPos = new Waypoint(Pacman.CurrentPositionX, Pacman.CurrentPositionY);

            var dist = LevelScheme.Distance(clydePos, pacmanPos);

            if(dist < 8)
            {
                //left bottom corner
                Monsters[3].Move(LevelScheme.GetLeftBottomCorner.X, LevelScheme.GetLeftBottomCorner.Y, LevelScheme);
            }
            else
            {
                //pacman
                Monsters[3].Move(Pacman.CurrentPositionX, Pacman.CurrentPositionY, LevelScheme);
            }
        }
        
        /// <summary>
        /// Move all monsters
        /// </summary>
        public void Move()
        {
            MoveBlinky();
            MovePinky();
            MoveInky();
            MoveClyde();
        }

        /// <summary>
        /// Move pacman
        /// </summary>
        public void MovePacmanDown()
        {
            if (CheckWallCollision(Pacman, Walls, MoveIntensions.DOWN))
                Pacman.MoveDown();
        }

        /// <summary>
        /// Move pacman
        /// </summary>
        public void MovePacmanUp()
        {
            //if (CheckWallCollision(Pacman, Walls, Dimension.mvUp))
            if (CheckWallCollision(Pacman, Walls, MoveIntensions.UP))   
                Pacman.MoveUp();
        }

        /// <summary>
        /// Move pacman
        /// </summary>
        public void MovePacmanRight()
        {
            if (CheckWallCollision(Pacman, Walls, MoveIntensions.RIGHT))
                Pacman.MoveRight();
        }

        /// <summary>
        /// Move pacman
        /// </summary>
        public void MovePacmanLeft()
        {
            if (CheckWallCollision(Pacman, Walls, MoveIntensions.LEFT))
                Pacman.MoveLeft();
        }

        /// <summary>
        /// Redraw pacman
        /// </summary>
        public void Redraw(Graphics graphics) => Pacman.Redraw(graphics);
        
        /// <summary>
        /// Check collision for walls
        /// </summary>
        /// <param name="GameObject">Pacman or monster</param>
        /// <param name="Walls">List of walls</param>
        /// <param name="DimFlag">Where you want to move</param>
        /// <returns>Can you move or not</returns>
        private bool CheckWallCollision(MovableGameObject GameObject , List<Wall> Walls, MoveIntensions DimFlag)
        {
            int pacmanX = GameObject.CurrentPositionX;
            int pacmanY = GameObject.CurrentPositionY;
            bool moveFlag = true;

            if (DimFlag == MoveIntensions.UP)
                pacmanY -= 1;
            else if (DimFlag == MoveIntensions.DOWN)
                pacmanY += 1;
            else if (DimFlag == MoveIntensions.RIGHT)
                pacmanX += 1;
            else
                pacmanX -= 1;

            foreach (Wall wall in Walls)
            {
                int wallX = wall.CurrentPositionX;
                int wallY = wall.CurrentPositionY;

                if ((pacmanY == wallY)
                    && (pacmanX == wallX))
                {
                    moveFlag = false;
                    break;
                }
            }

            return moveFlag;
        }

        /// <summary>
        /// Check collisions with monsters
        /// </summary>
        /// <param name="GameObject">Pacman or monster</param>
        /// <param name="Monsters">Monsters list</param>
        /// <param name="DimFlag">WHere you what to go</param>
        /// <param name="except">Number of monster in List of monsters (if pacman use -1)</param>
        /// <returns></returns>
        private bool CheckPacmanMonsterCollision(List<Monster> Monsters, MoveIntensions DimFlag, int except)
        {
            int pacmanX = Pacman.CurrentPositionX;
            int pacmanY = Pacman.CurrentPositionY;
            bool moveFlag = true;

            for(int i = 0; i < Monsters.Count; i++)
            {
                if (i == except) continue;

                int monsterX = Monsters[i].CurrentPositionX;
                int monsterY = Monsters[i].CurrentPositionY;

                if ((pacmanY == monsterY) && (pacmanX == monsterX))
                {
                    moveFlag = false;
                    break;
                }
            }

            return moveFlag;
        }

        /// <summary>
        /// Check collisions with money
        /// </summary>
        /// <param name="DimFlag"></param>
        private void CheckPointsCollision()
        {
            int pacmanX = Pacman.CurrentPositionX;
            int pacmanY = Pacman.CurrentPositionY;

            for (int i = 0; i < Points.Count; i++)
            {
                int pointX = Points[i].CurrentPositionX;
                int pointY = Points[i].CurrentPositionY;

                if ((pacmanY == pointY) && (pacmanX == pointX))
                {
                    Points.RemoveAt(i);
                    WorldStat.ScoreTotal += 10;
                    break;
                }
            }

            for(int i = 0; i <  Energizers.Count; i++)
            {
                int energizerX = Energizers[i].CurrentPositionX;
                int energizerY = Energizers[i].CurrentPositionY;

                if ((pacmanY == energizerY) && (pacmanX == energizerX))
                {
                    Energizers.RemoveAt(i);
                    WorldStat.ScoreTotal += 50;
                    break;
                }
            }   
        }

        private bool CheckWin()
        {
            if (Energizers.Count == 0 && Points.Count == 0)
                return true;

            return false;
        }

        private bool CheckLoose()
        {
            if (!CheckPacmanMonsterCollision(Monsters, MoveIntensions.RIGHT, 10) ||
                !CheckPacmanMonsterCollision(Monsters, MoveIntensions.LEFT, 10) ||
                !CheckPacmanMonsterCollision(Monsters, MoveIntensions.UP, 10) ||
                !CheckPacmanMonsterCollision(Monsters, MoveIntensions.DOWN, 10))
            {
                return true;
            }

            return false;
        }


        //Произошло измнение - перерисовали карту
        /// <summary>
        /// Redraw map and all objects in game
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            for (int i = 0; i < Walls.Count; i++)
            {
                var wall = Walls[i];
                var posX = (float)(wall.CurrentPositionX * Dimensions.SpriteWidthPixels);
                var posY = (float)(wall.CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.LifeBarHeight);

                graphics.DrawImage(wall.View, posX, posY, Dimensions.SpriteWidthPixels, Dimensions.SpriteHeightPixels);
            }

            for (int i = 0; i < Energizers.Count; i++)
            {
                var energizer = Energizers[i];
                var posX = (float)(energizer.CurrentPositionX * Dimensions.SpriteWidthPixels);
                var posY = (float)(energizer.CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.LifeBarHeight);

                graphics.DrawImage(energizer.View, posX, posY, Dimensions.SpriteWidthPixels, Dimensions.SpriteHeightPixels);
            }

            for (int i = 0; i < Points.Count; i++)
            {
                var point = Points[i];
                var posX = (float)(point.CurrentPositionX * Dimensions.SpriteWidthPixels);
                var posY = (float)(point.CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.LifeBarHeight);

                graphics.DrawImage(point.View, posX, posY, Dimensions.SpriteWidthPixels, Dimensions.SpriteHeightPixels);
            }

            foreach (var monster in Monsters)
                monster.Redraw(graphics);

            Pacman.Redraw(graphics);

            /*
#if DEBUG
            DrawBlinkyIntension(graphics);
            DrawPinkyIntension(graphics);
            DrawInkyIntension(graphics);
            DrawClydeIntension(graphics);
#endif
            */

        }

        /// <summary>
        /// DEBUG
        /// Shows where Bliny goes
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawBlinkyIntension(Graphics graphics)
        {
            graphics.DrawLine(
                new Pen(Brushes.Red) { Width = 5 },
                Monsters[0].CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                Monsters[0].CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2 + Dimensions.LifeBarHeight,
                Pacman.CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                Pacman.CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2 + Dimensions.LifeBarHeight);
        }

        /// <summary>
        /// DEBUG
        /// Shows where Pinky goes
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawPinkyIntension(Graphics graphics)
        {
            var dx = Pacman.CurrentPositionX - Pacman.previousX;
            var dy = Pacman.CurrentPositionY - Pacman.previousY;

            if (dx > 0)
                dx = 4;
            else if (dx < 0)
                dx = -4;
            else if (dy < 0)
                dy = -4;
            else
                dy = 4;

            graphics.DrawLine(
                new Pen(Brushes.Pink) { Width = 5 },
                Monsters[2].CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                Monsters[2].CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2 + Dimensions.LifeBarHeight,
                (Pacman.CurrentPositionX + dx) * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                (Pacman.CurrentPositionY + dy) * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2 + Dimensions.LifeBarHeight);
        }

        /// <summary>
        /// DEBUG
        /// Shows where Inky goes
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawInkyIntension(Graphics graphics)
        {
            var dx = Pacman.CurrentPositionX - Pacman.previousX;
            var dy = Pacman.CurrentPositionY - Pacman.previousY;

            if (dx > 0)
                dx = 2;
            else if (dx < 0)
                dx = -2;
            else if (dy < 0)
                dy = -2;
            else
                dy = 2;

            var hX = (Pacman.CurrentPositionX + dx - Monsters[0].CurrentPositionX) * 2 + Monsters[0].CurrentPositionX;
            var hY = (Pacman.CurrentPositionY + dy - Monsters[0].CurrentPositionY) * 2 + Monsters[0].CurrentPositionY;

            graphics.DrawLine(
                new Pen(Brushes.MediumBlue) { Width = 5 },
                Monsters[1].CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                Monsters[1].CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2 + Dimensions.LifeBarHeight,
                hX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                hY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2 + Dimensions.LifeBarHeight);

            graphics.DrawLine(
                new Pen(Brushes.MediumBlue) { Width = 5 },
                Monsters[0].CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                Monsters[0].CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2 + Dimensions.LifeBarHeight,
                hX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                hY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2 + Dimensions.LifeBarHeight);
        }

        /// <summary>
        /// DEBUG
        /// Shows where Clyde goes
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawClydeIntension(Graphics graphics) 
        {
            var clydePos = new Waypoint(Monsters[3].CurrentPositionX, Monsters[3].CurrentPositionY);
            var pacmanPos = new Waypoint(Pacman.CurrentPositionX, Pacman.CurrentPositionY);

            var dist = LevelScheme.Distance(clydePos, pacmanPos);

            if (dist < 8)
            {
                //left bottom corner
                graphics.DrawLine(
                    new Pen(Brushes.Orange) { Width = 5 },
                    Monsters[3].CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                    Monsters[3].CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2 + Dimensions.LifeBarHeight,
                    LevelScheme.GetLeftBottomCorner.X * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                    LevelScheme.GetLeftBottomCorner.Y * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2 + Dimensions.LifeBarHeight);
            }
            else
            {
                //pacman
                graphics.DrawLine(
                    new Pen(Brushes.Orange) { Width = 5 },
                    Monsters[3].CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                    Monsters[3].CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2 + Dimensions.LifeBarHeight,
                    Pacman.CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                    Pacman.CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2 + Dimensions.LifeBarHeight);
            }
        }
    }
}
