using System.Collections.Generic;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс инициализаци элементов уровня по заданному паттерну
    /// </summary>
    public class LevelPattern
    {
        //Списки координат точек появления объектов
        public List<Wall> Walls;
        public List<Monster> MonsterSpawns;
        public List<Energizer> Energizers;
        public List<SmallPoint> SmallPoints;

        /// <summary>
        /// Класс, который описывает все объекты на уровне
        /// </summary>
        public LevelPattern()
        {
            Walls = new List<Wall>();
            MonsterSpawns = new List<Monster>();
            Energizers = new List<Energizer>();
            SmallPoints = new List<SmallPoint>();
        }

        /// <summary>
        /// Добавить координаты стены
        /// </summary>
        /// <param name="x">Координата по оси Х</param>
        /// <param name="y">Координата по оси У</param>
        public void AddWall(int x, int y)
        {
            Walls.Add(new Wall(x, y));
        }

        /// <summary>
        /// Добавить координаты точки появления монстров
        /// </summary>
        /// <param name="x">Координата по оси Х</param>
        /// <param name="y">Координата по оси У</param>
        public void AddMonsterSpawn(int x, int y)
        {
            MonsterSpawns.Add(new Monster(x, y, 10));
        }

        /// <summary>
        /// Добавить координаты точки появления Энерджайзеров
        /// </summary>
        /// <param name="x">Координата по оси Х</param>
        /// <param name="y">Координата по оси У</param>
        public void AddEnergizer(int x, int y)
        {
            Energizers.Add(new Energizer(x, y));
        }

        /// <summary>
        /// Добавить координаты точки появления точек
        /// </summary>
        /// <param name="x">Координата по оси Х</param>
        /// <param name="y">Координата по оси У</param>
        public void AddSmallPoint(int x, int y)
        {
            SmallPoints.Add(new SmallPoint(x, y));
        }
    }
}
