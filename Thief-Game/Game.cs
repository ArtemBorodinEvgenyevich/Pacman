//Lev

using System;
using System.Collections.Generic;
using System.Text;

namespace Thief_Game
{
    class Game
    {
        //Монстры уровня
        private List<Monster> Monsters;
        private Map Map;
        private Class1 Pacman;

        public Game()
        {
            Map = new Map();

            //Инициализация карты, игрока, монстров...
        }

        private void LoadPattern()
        {
            //загрузка файла
            // инициализация массива на основе этого файла

            //Используй LevelLoader().ParseFile()
        }

        //Произошло событие, через этот класс влияем на все модели
    }
}
