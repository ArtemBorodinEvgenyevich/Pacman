using System.Drawing.Drawing2D;
using System.IO;
using Thief_Game.Constants;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс загрузчика уровня игры
    /// </summary>
    class LevelLoader
    {
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

                for (int i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case LevelParser.WallSign:
                            pattern.AddWall(x, y);
                            break;
                        case LevelParser.BlinkySpawnSign:
                            pattern.AddMonsterSpawn(x, y, MonsterTypes.BLINKY);
                            pattern.AddFloor(x, y);
                            break;
                        case LevelParser.PinkySpawnSign:
                            pattern.AddMonsterSpawn(x, y, MonsterTypes.PINKY);
                            pattern.AddFloor(x, y);
                            break;
                        case LevelParser.InkySpawnSign:
                            pattern.AddMonsterSpawn(x, y, MonsterTypes.INKY);
                            pattern.AddFloor(x, y);
                            break;
                        case LevelParser.ClydeSpawnSign:
                            pattern.AddMonsterSpawn(x, y, MonsterTypes.CLYDE);
                            pattern.AddFloor(x, y);
                            break;
                        case LevelParser.PacmanSpawnSign:
                            Pacman.StartX = x;
                            Pacman.StartY = y;
                            pattern.AddFloor(x, y);
                            break;
                        case LevelParser.ScorePointSpawnSign:
                            pattern.AddSmallPoint(x, y);
                            pattern.AddFloor(x, y);
                            break;
                        case LevelParser.EnergizerSpawnSign:
                            pattern.AddEnergizer(x, y);
                            pattern.AddFloor(x, y);
                            break;
                        case LevelParser.EmptySpaceSign:
                            pattern.AddFloor(x, y);
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
