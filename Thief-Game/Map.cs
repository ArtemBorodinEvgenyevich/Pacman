using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Security.Cryptography.Xml;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс инициализации игрового уровня
    /// </summary>
    class Map
    {
        // Enum as flags for CheckWallCollision method.
        private enum Dimension
        {
            mvUp,
            mvDown,
            mvRight,
            mvLeft
        }
        
        //Монстр с координатами { X = 1, Y = 2 } на форме находится в позиции
        //PositionMap[1, 2] = (70, 150)

        private List<Wall> Walls;
        private List<Monster> Monsters;
        private Pacman Pacman;
        private List<SmallPoint> Points;
        private List<Energizer> Energizers;

        //Я нигде не использую IMovable
        public Map()
        {
            var pattern = new LevelLoader().ParseFile();

            Walls = new List<Wall>();
            Monsters = new List<Monster>();
            Points = new List<SmallPoint>();
            Energizers = new List<Energizer>();

            InitWalls(pattern);
            InitMonsters(pattern);
            InitPlayer(pattern);
            InitSmallPoints(pattern);
            InitEnergizers(pattern);

            Application.Run(new Scene(MovePacmanUp, MovePacmanDown, MovePacmanRight, MovePacmanLeft, Draw, MoveMonster));
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
                var m = new Monster(monster.StartX, monster.StartY, 10);
                Monsters.Add(m);
                //Monsters.Add(monster);
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

        public void MoveMonster()
        {
            var rnd = new Random();

            for (int i = 0; i < 4; i++)
            {
                switch (rnd.Next(0, 4))
                {
                    case 0:
                        MoveMonstersRight(i);
                        break;
                    case 1:
                        MoveMonstersLeft(i);
                        break;
                    case 2:
                        MoveMonstersDown(i);
                        break;
                    case 3:
                        MoveMonstersUp(i);
                        break;
                }
            }
        }

        public void MoveMonstersRight(int index)
        {
            if ((CheckWallCollision(Monsters[index], Walls, Dimension.mvRight) && (CheckMonsterCollision(Monsters[index], Monsters, Dimension.mvRight, index))))
                Monsters[index].MoveRight();
        }

        public void MoveMonstersLeft(int index)
        {
            if ((CheckWallCollision(Monsters[index], Walls, Dimension.mvLeft) && (CheckMonsterCollision(Monsters[index], Monsters, Dimension.mvRight, index))))
                Monsters[index].MoveLeft();
        }

        public void MoveMonstersUp(int index)
        {
            if ((CheckWallCollision(Monsters[index], Walls, Dimension.mvUp) && (CheckMonsterCollision(Monsters[index], Monsters, Dimension.mvRight, index))))
                Monsters[index].MoveUp();
        }

        public void MoveMonstersDown(int index)
        {
            if ((CheckWallCollision(Monsters[index], Walls, Dimension.mvDown) && (CheckMonsterCollision(Monsters[index], Monsters, Dimension.mvRight, index))))
                Monsters[index].MoveDown();
        }

        public void MovePacmanDown()
        {
            if (CheckWallCollision(Pacman, Walls, Dimension.mvDown))
                Pacman.MoveDown();
        }
        public void MovePacmanUp()
        {
            //if (CheckWallCollision(Pacman, Walls, Dimension.mvUp))
            if (CheckWallCollision(Pacman, Walls, Dimension.mvUp))   
                Pacman.MoveUp();
        }
        public void MovePacmanRight()
        {
            if (CheckWallCollision(Pacman, Walls, Dimension.mvRight))
                Pacman.MoveRight();
        }
        public void MovePacmanLeft()
        {
            if (CheckWallCollision(Pacman, Walls, Dimension.mvLeft))
                Pacman.MoveLeft();
        }
        
        private bool CheckWallCollision(MovableGameObject GameObject , List<Wall> Walls, Dimension DimFlag)
        {
            int pacmanX = GameObject.CurrentPositionX;
            int pacmanY = GameObject.CurrentPositionY;
            bool moveFlag = true;

            if (DimFlag == Dimension.mvUp)
                pacmanY -= 1;
            else if (DimFlag == Dimension.mvDown)
                pacmanY += 1;
            else if (DimFlag == Dimension.mvRight)
                pacmanX += 1;
            else
                pacmanX -= 1;

            foreach (var wall in Walls)
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

        private bool CheckMonsterCollision(MovableGameObject GameObject, List<Monster> Monsters, Dimension DimFlag, int except)
        {
            int objX = GameObject.CurrentPositionX;
            int objY = GameObject.CurrentPositionY;
            bool moveFlag = true;

            if (DimFlag == Dimension.mvUp)
                objY -= 1;
            else if (DimFlag == Dimension.mvDown)
                objY += 1;
            else if (DimFlag == Dimension.mvRight)
                objX += 1;
            else
                objX -= 1;

            for(int i = 0; i < Monsters.Count; i++)
            {
                if (i == except) continue;

                int monsterX = Monsters[i].CurrentPositionX;
                int monsterY = Monsters[i].CurrentPositionY;

                if ((objY == monsterY)
                    && (objX == monsterX))
                {
                    moveFlag = false;
                    break;
                }
            }

            return moveFlag;
        }

        //Произошло измнение - перерисовали карту
        public void Draw(Graphics graphics)
        {
            Pacman.Redraw(graphics);

            for (int i = 0; i < Walls.Count; i++)
            {
                var wall = Walls[i];
                var posX = (float)(wall.CurrentPositionX * Dimensions.SpriteWidthPixels);
                var posY = (float)(wall.CurrentPositionY * Dimensions.SpriteHeightPixels);

                graphics.DrawImage(wall.View, posX, posY, Dimensions.SpriteWidthPixels, Dimensions.SpriteHeightPixels);
            }

            for(int i = 0; i < Monsters.Count; i++)
            {
                Monsters[i].Redraw(graphics);
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
        }
    }
}
