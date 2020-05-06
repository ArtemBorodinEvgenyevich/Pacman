using System.Collections.Generic;

namespace Thief_Game
{
    //Lev
    class LevelPattern
    {
        //Списки координат точек появления объектов
        public List<(int x, int y)> Walls;
        public List<(int x, int y)> MonsterSpawns;
        public (int x, int y) Player;

        /// <summary>
        /// Класс, который описывает все объекты на уровне
        /// </summary>
        public LevelPattern()
        {
            Walls = new List<(int x, int y)>();
            MonsterSpawns = new List<(int x, int y)>();
        }

        /// <summary>
        /// Добавить координаты стены
        /// </summary>
        /// <param name="x">Координата по оси Х</param>
        /// <param name="y">Координата по оси У</param>
        public void AddWall(int x, int y)
        {
            Walls.Add((x, y));
        }

        /// <summary>
        /// Добавить координаты точки появления монстров
        /// </summary>
        /// <param name="x">Координата по оси Х</param>
        /// <param name="y">Координата по оси У</param>
        public void AddMonsterSpawn(int x, int y)
        {
            MonsterSpawns.Add((x, y));
        }
    }
}
