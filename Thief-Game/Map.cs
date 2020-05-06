//Lev

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Thief_Game
{
    class Map
    {
        //Есть массив с точками, где могут находится объекты
        //True = Wall
        //False = Empty
        private (int x, int y)[,] PositionsMap;

        public const int MapWidth = 20;
        public const int MapHeight = 22;

        public const int SpriteDefaultWidth = 70;
        public const int SpriteDefaultHeight = 75;
        //Монстр с координатами { X = 1, Y = 2 } на форме находится в позиции
        //PositionMap[1, 2] = (70, 150)
        private int SpriteWidth = 15;
        private int SpriteHeight = 15;

        private List<Wall> Walls;

        public Map()
        {
            PositionsMap = new (int x, int y)[MapWidth, MapHeight];

            var pattern = new LevelLoader().ParseFile();

            Walls = new List<Wall>();
            InitWalls(pattern);
        }

        private void InitWalls(LevelPattern pattern)
        {
            foreach (var wall in pattern.Walls)
            {
                Walls.Add(new Wall(wall.x * SpriteWidth, wall.y * SpriteHeight));
            }
        }

        public void InitMonsters()
        {
            //При инициализации уровня создаем монстров
        }

        public void InitPlayer()
        {
            //При инициализации уровня создаем игрока
        }
    }
}
