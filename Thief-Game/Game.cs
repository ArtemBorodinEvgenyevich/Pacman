namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс инициализации игры
    /// </summary>
    class Game
    {
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
