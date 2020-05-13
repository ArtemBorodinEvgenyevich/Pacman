using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

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

            Application.Run(new Scene(Draw, MovePacmanUp, MovePacmanDown, MovePacmanRight, MovePacmanLeft, Redraw));
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

        // FIXME: Координаты стен и пакмана, не совпадают, когда они визуально находятся в одном месте.
        public void MovePacmanDown()
        {
            bool moveFlag = true;
            // FIXME: убрать мусор с выводом координат
            var pacValues = Tuple.Create(Pacman.CurrentPositionX, Pacman.CurrentPositionY);
            foreach (Wall wall in Walls)
            {
                var wallValues = Tuple.Create(
                    wall.CurrentPositionX * Dimensions.SpriteWidthPixels, 
                    wall.CurrentPositionY * Dimensions.SpriteHeightPixels);
                var same = pacValues == wallValues;

                if ((Pacman.CurrentPositionY + Dimensions.StepY == wall.CurrentPositionY * Dimensions.SpriteHeightPixels)
                    && (Pacman.CurrentPositionX + Dimensions.StepX == wall.CurrentPositionX * Dimensions.SpriteWidthPixels + Dimensions.SpriteWidthPixels))
                {
                    moveFlag = false;
                    break;
                }
            }
            if (moveFlag)
                Pacman.MoveDown();
        }
        public void MovePacmanUp() => Pacman.MoveUp();
        public void MovePacmanRight() => Pacman.MoveRight();
        public void MovePacmanLeft() => Pacman.MoveLeft();
        public void Redraw(Graphics graphics) => Pacman.Redraw(graphics);
        
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

            for (int i = 0; i < Monsters.Count; i++)
            {
                var monster = Monsters[i];
                var posX = (float)(monster.CurrentPositionX * Dimensions.SpriteWidthPixels);
                var posY = (float)(monster.CurrentPositionY * Dimensions.SpriteHeightPixels);

                graphics.DrawImage(monster.View, posX, posY, Dimensions.SpriteWidthPixels, Dimensions.SpriteHeightPixels);
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

    enum GameObjects
    {
        FLOOR,
        PLAYER,
        MONSTER,
        WALL
    }
}
