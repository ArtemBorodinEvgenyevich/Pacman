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
        //Монстр с координатами { X = 1, Y = 2 } на форме находится в позиции
        //PositionMap[1, 2] = (70, 150)

        private List<Wall> Walls;
        private List<Monster> Monsters;
        private Pacman Pacman;
        private List<SmallPoint> Points;
        private List<Energizer> Energizers;

        private Graph LevelScheme;
        // temporary
        private WorldStat WorldStat;

        //Я нигде не использую IMovable
        public Map()
        {
            var pattern = new LevelLoader().ParseFile();

            Walls = new List<Wall>();
            Monsters = new List<Monster>();
            Points = new List<SmallPoint>();
            Energizers = new List<Energizer>();
            LevelScheme = pattern.LevelScheme;
            WorldStat = new WorldStat();

            InitWalls(pattern);
            InitMonsters(pattern);
            InitPlayer(pattern);
            InitSmallPoints(pattern);
            InitEnergizers(pattern);

            Application.Run(new Scene(Draw, MovePacmanUp, MovePacmanDown, MovePacmanRight, MovePacmanLeft, Redraw, Move, CheckPointsCollision, SerializeStats));
        }

        private void SerializeStats()
        {
            var serializer = new WorldStatPickle();
            serializer.DataSerialize(WorldStat.ScoreTotal);
        }

        private void InitWalls(LevelPattern pattern)
        {
            //При инициализации уровня создаем стены
            foreach (var wall in pattern.Walls)
            {
                Walls.Add(wall);
            }
        }

        public void InitMonsters(LevelPattern pattern)
        {
            //При инициализации уровня создаем монстров
            foreach (var monster in pattern.MonsterSpawns)
            {
                Monsters.Add(monster);
            }
        }

        public void InitPlayer(LevelPattern pattern)
        {
            //При инициализации уровня создаем игрока
            Pacman = new Pacman(Pacman.StartX, Pacman.StartY, 10);
        }

        public void InitSmallPoints(LevelPattern pattern)
        {
            foreach(var point in pattern.SmallPoints)
            {
                Points.Add(point);
            }
        }

        public void InitEnergizers(LevelPattern pattern)
        {
            foreach(var energizer in pattern.Energizers)
            {
                Energizers.Add(energizer);
            }
        }

        private void MoveBlinky()
        {
            Monsters[0].Move(Pacman.CurrentPositionX, Pacman.CurrentPositionY, LevelScheme);
        }

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

        private void MoveClyde()
        {
            var clydePos = new Node(Monsters[3].CurrentPositionX, Monsters[3].CurrentPositionY);
            var pacmanPos = new Node(Pacman.CurrentPositionX, Pacman.CurrentPositionY);

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
        
        public void Move()
        {
            MoveBlinky();
            MovePinky();
            MoveInky();
            MoveClyde();
        }

        public void MovePacmanDown()
        {
            if (CheckWallCollision(Pacman, Walls, MoveIntensions.DOWN))
                Pacman.MoveDown();
        }
        public void MovePacmanUp()
        {
            //if (CheckWallCollision(Pacman, Walls, Dimension.mvUp))
            if (CheckWallCollision(Pacman, Walls, MoveIntensions.UP))   
                Pacman.MoveUp();
        }
        public void MovePacmanRight()
        {
            if (CheckWallCollision(Pacman, Walls, MoveIntensions.RIGHT))
                Pacman.MoveRight();
        }
        public void MovePacmanLeft()
        {
            if (CheckWallCollision(Pacman, Walls, MoveIntensions.LEFT))
                Pacman.MoveLeft();
        }
        public void Redraw(Graphics graphics) => Pacman.Redraw(graphics);
        
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

        private bool CheckMonsterCollision(MovableGameObject GameObject, List<Monster> Monsters, MoveIntensions DimFlag, int except)
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

        private void CheckPointsCollision(MoveIntensions DimFlag)
        {
            // Чего это такое? Какого-то рода костыль?
            // ---------------------------------------
            int pacmanX = Pacman.CurrentPositionX;
            int pacmanY = Pacman.CurrentPositionY;

            if (DimFlag == MoveIntensions.UP)
                pacmanY -= 1;
            else if (DimFlag == MoveIntensions.DOWN)
                pacmanY += 1;
            else if (DimFlag == MoveIntensions.RIGHT)
                pacmanX += 1;
            else
                pacmanX -= 1;
            // ---------------------------------------

            for (int i = 0; i < Points.Count; i++)
            {
                // Деньги,конечно, ужастны, но не на столько, чтобы называть их монстрами :)
                int monsterX = Points[i].CurrentPositionX;
                int monsterY = Points[i].CurrentPositionY;

                if ((pacmanY == monsterY) && (pacmanX == monsterX))
                {
                    Points.RemoveAt(i);
                    WorldStat.ScoreTotal += 1;
                    break;
                }
            }

            for(int i = 0; i <  Energizers.Count; i++)
            {
                int monsterX = Energizers[i].CurrentPositionX;
                int monsterY = Energizers[i].CurrentPositionY;

                if ((pacmanY == monsterY) && (pacmanX == monsterX))
                {
                    Energizers.RemoveAt(i);
                    WorldStat.ScoreTotal += 10;
                    break;
                }
            }
        }

        //Произошло измнение - перерисовали карту
        public void Draw(Graphics graphics)
        {
            for (int i = 0; i < Walls.Count; i++)
            {
                var wall = Walls[i];
                var posX = (float)(wall.CurrentPositionX * Dimensions.SpriteWidthPixels);
                var posY = (float)(wall.CurrentPositionY * Dimensions.SpriteHeightPixels);

                graphics.DrawImage(wall.View, posX, posY, Dimensions.SpriteWidthPixels, Dimensions.SpriteHeightPixels);
            }

            for (int i = 0; i < Energizers.Count; i++)
            {
                var energizer = Energizers[i];
                var posX = (float)(energizer.CurrentPositionX * Dimensions.SpriteWidthPixels);
                var posY = (float)(energizer.CurrentPositionY * Dimensions.SpriteHeightPixels);

                graphics.DrawImage(energizer.View, posX, posY, Dimensions.SpriteWidthPixels, Dimensions.SpriteHeightPixels);
            }

            for (int i = 0; i < Points.Count; i++)
            {
                var point = Points[i];
                var posX = (float)(point.CurrentPositionX * Dimensions.SpriteWidthPixels);
                var posY = (float)(point.CurrentPositionY * Dimensions.SpriteHeightPixels);

                graphics.DrawImage(point.View, posX, posY, Dimensions.SpriteWidthPixels, Dimensions.SpriteHeightPixels);
            }

            foreach (var monster in Monsters)
                monster.Redraw(graphics);

            Pacman.Redraw(graphics);

#if DEBUG
            DrawBlinkyIntension(graphics);
            DrawPinkyIntension(graphics);
            DrawInkyIntension(graphics);
            DrawClydeIntension(graphics);
#endif
        }

        private void DrawBlinkyIntension(Graphics graphics)
        {
            graphics.DrawLine(
                new Pen(Brushes.Red) { Width = 5 },
                Monsters[0].CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                Monsters[0].CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2,
                Pacman.CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                Pacman.CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2);
        }

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
                Monsters[2].CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2,
                (Pacman.CurrentPositionX + dx) * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                (Pacman.CurrentPositionY + dy) * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2);
        }

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
                Monsters[1].CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2,
                hX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                hY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2);

            graphics.DrawLine(
                new Pen(Brushes.MediumBlue) { Width = 5 },
                Monsters[0].CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                Monsters[0].CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2,
                hX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                hY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2);
        }

        private void DrawClydeIntension(Graphics graphics) 
        {
            var clydePos = new Node(Monsters[3].CurrentPositionX, Monsters[3].CurrentPositionY);
            var pacmanPos = new Node(Pacman.CurrentPositionX, Pacman.CurrentPositionY);

            var dist = LevelScheme.Distance(clydePos, pacmanPos);

            if (dist < 8)
            {
                //left bottom corner
                graphics.DrawLine(
                    new Pen(Brushes.Orange) { Width = 5 },
                    Monsters[3].CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                    Monsters[3].CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2,
                    LevelScheme.GetLeftBottomCorner.X * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                    LevelScheme.GetLeftBottomCorner.Y * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2);
            }
            else
            {
                //pacman
                graphics.DrawLine(
                    new Pen(Brushes.Orange) { Width = 5 },
                    Monsters[3].CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                    Monsters[3].CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2,
                    Pacman.CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels / 2,
                    Pacman.CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.SpriteHeightPixels / 2);
            }
        }
    }
}
