using System;
using System.Collections.Generic;
using System.Text;

namespace Thief_Game
{
    class Map
    {
        //Есть массив с точками, где могут находится объекты
        //True = Wall
        //False = Empty
        private bool[,] PositionsMap;

        public const int MapWidth = 17;
        public const int MapHeight = 20;

        public const int SpriteWidth = 70;
        public const int SpriteHeight = 75;
        //Монстр с координатами { X = 1, Y = 2 } на форме находится в позиции
        //PositionMap[1, 2] = (70, 150)

        public Map()
        {
            PositionsMap = new bool[MapWidth, MapHeight];
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
