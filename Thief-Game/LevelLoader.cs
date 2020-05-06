//Lev

using System;
using System.IO;

namespace Thief_Game
{
    class LevelLoader
    {
        private const char WallSign = '#';
        private const char MonsterSpawnSign = 'S';
        private const char PacmanSpawnSign = 'P';
        private string PathToPattern;

        /// <summary>
        /// Разбор файла-паттерна
        /// </summary>
        public LevelLoader()
        {
            PathToPattern = GoToLevelPattern_ptrn();
        }

        /// <summary>
        /// Прочитать файл-паттерн и создать на основе этого файла
        /// описание объектов уровня
        /// </summary>
        /// <returns>Объект-уровень</returns>
        public LevelPattern ParseFile()
        {
            //Читаем файл и создаем объект PatternStruct
            var reader = new StreamReader(PathToPattern);

            var pattern = new LevelPattern();

            var line = "";

            //Координаты 
            var x = 0;
            var y = 0;

            while (!reader.EndOfStream)
            {
                x = 0;

                line = reader.ReadLine();

                for(int i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case WallSign:
                            pattern.AddWall(x, y);
                            break;
                        case MonsterSpawnSign:
                            pattern.AddMonsterSpawn(x, y);
                            break;
                        case PacmanSpawnSign:
                            pattern.Player.x = x;
                            pattern.Player.y = y;
                            break;
                    }

                    x++;
                }

                y++;
            }

            return pattern;
        }

        /// <summary>
        /// Находим сам файл-паттерн
        /// </summary>
        /// <param name="path">Папка, где лежит файл</param>
        /// <returns>Путь к файлу</returns>
        private string GoToLevelPattern_ptrn()
        {
            return Path.Combine(PathInfo.SourceDir, "LevelPattern.ptrn");
        }
    }
}
