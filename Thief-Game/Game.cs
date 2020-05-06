//Lev

using System;
using System.Collections.Generic;
using System.Text;

namespace Thief_Game
{
    class Game
    {
        //Pacman Player
        private Pacman Player;

        public Game()
        {
            Player = new Pacman(10, 10, 10);
        }

        private void LoadPattern()
        {
            //загрузка файла
            // инициализация массива на основе этого файла
        }

        //Произошло событие, через этот класс влияем на все модели
    }
}
