using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using PathFinder;

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

        public void Move()
        {
            var isUp = false;
            var isDown = false;
            var isRight = false;
            var isLeft = false;

            if ((CheckMonsterCollision(Monsters[0], Monsters, MoveIntensions.UP, 0))
                && (CheckWallCollision(Monsters[0], Walls, MoveIntensions.UP)))
                isUp = true;

            if ((CheckMonsterCollision(Monsters[0], Monsters, MoveIntensions.DOWN, 0))
                && (CheckWallCollision(Monsters[0], Walls, MoveIntensions.DOWN)))
                isDown = true;

            if ((CheckMonsterCollision(Monsters[0], Monsters, MoveIntensions.RIGHT, 0))
                && (CheckWallCollision(Monsters[0], Walls, MoveIntensions.RIGHT)))
                isRight = true;

            if ((CheckMonsterCollision(Monsters[0], Monsters, MoveIntensions.LEFT, 0))
                && (CheckWallCollision(Monsters[0], Walls, MoveIntensions.LEFT)))
                isLeft = true;

            Monsters[0].Move(isUp, isDown, isLeft, isRight, Pacman.CurrentPositionX, Pacman.CurrentPositionY, LevelScheme);

            var rnd = new Random();

            for(int i = 1; i < Monsters.Count; i++)
            {
                var numb = rnd.Next(0, 4);

                switch (numb)
                {
                    case 0:
                        if ((CheckMonsterCollision(Monsters[i], Monsters, MoveIntensions.DOWN, i))
                            && (CheckWallCollision(Monsters[i], Walls, MoveIntensions.DOWN)))
                            Monsters[i].MoveDown();
                        break;
                    case 1:
                        if ((CheckMonsterCollision(Monsters[i], Monsters, MoveIntensions.UP, i))
                            && (CheckWallCollision(Monsters[i], Walls, MoveIntensions.UP)))
                            Monsters[i].MoveUp();
                        break;
                    case 2:
                        if ((CheckMonsterCollision(Monsters[i], Monsters, MoveIntensions.LEFT, i))
                            && (CheckWallCollision(Monsters[i], Walls, MoveIntensions.LEFT)))
                            Monsters[i].MoveLeft();
                        break;
                    case 3:
                        if ((CheckMonsterCollision(Monsters[i], Monsters, MoveIntensions.RIGHT, i))
                            && (CheckWallCollision(Monsters[i], Walls, MoveIntensions.RIGHT)))
                            Monsters[i].MoveRight();
                        break;
                }
            }
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
        }
    }
}
