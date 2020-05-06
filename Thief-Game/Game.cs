using System;
using System.Collections.Generic;
using System.Text;

namespace Thief_Game
{
    class Game
    {
        //Монстры уровня
        private List<Monster> Monsters;
        //Pacman Player

        public Game()
        {
            Monsters = new List<Monster>();

            Monsters.Add(new Monster(0, 0, 10));
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
