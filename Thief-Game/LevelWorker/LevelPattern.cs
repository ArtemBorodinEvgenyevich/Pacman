using System.Collections.Generic;
using Thief_Game.Monsters;
using PathFinder;

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
        public Graph LevelScheme;

        /// <summary>
        /// Класс, который описывает все объекты на уровне
        /// </summary>
        public LevelPattern()
        {
            Walls = new List<Wall>();
            MonsterSpawns = new List<Monster>();
            Energizers = new List<Energizer>();
            SmallPoints = new List<SmallPoint>();
            LevelScheme = new Graph();
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
        public void AddMonsterSpawn(int x, int y, MonsterTypes type)
        {
            switch (type)
            {
                case MonsterTypes.BLINKY:
                    MonsterSpawns.Add(new Blinky(x, y, 10));
                    break;
                case MonsterTypes.INKY:
                    MonsterSpawns.Add(new Inky(x, y, 10));
                    break;
                case MonsterTypes.PINKY:
                    MonsterSpawns.Add(new Pinky(x, y, 10));
                    break;
                case MonsterTypes.CLYDE:
                    MonsterSpawns.Add(new Clyde(x, y, 10));
                    break;
            }
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

        /// <summary>
        /// Добавить координаты коридора (где монстры и пакман
        /// могут перемещаться)
        /// </summary>
        /// <param name="x">Позиция по оси Х</param>
        /// <param name="y">Позиция по оси Y</param>
        public void AddFloor(int x, int y)
        {
            LevelScheme.Add(new Waypoint(x, y));
        }
    }
}
