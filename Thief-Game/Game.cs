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

        /// <summary>
        /// Инициализация массива с элементами карты на основе загруженного файла
        /// </summary>
        private void LoadPattern()
        {
            //загрузка файла
            // Инициализация массива с элементами карты на основе загруженного
        }

        //Произошло событие, через этот класс влияем на все модели
    }
}
