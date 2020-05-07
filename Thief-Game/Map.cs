using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Класс инициализации игрового уровня
    /// </summary>
    class Map
    {
        //Монстр с координатами { X = 1, Y = 2 } на форме находится в позиции
        //PositionMap[1, 2] = (70, 150)

        private List<Wall> Walls;
        private List<Monster> Monsters;
        private Pacman Pacman;

        //Я нигде не использую IMovable
        public Map()
        {
            var pattern = new LevelLoader().ParseFile();

            Walls = new List<Wall>();
            Monsters = new List<Monster>();

            InitWalls(pattern);
            InitMonsters(pattern);
            InitPlayer(pattern);

            Application.Run(new Scene(Draw, Pacman));
        }

        private void InitWalls(LevelPattern pattern)
        {
            //При инициализации уровня создаем стены
            foreach (var wall in pattern.Walls)
            {
                Walls.Add(new Wall(wall.X, wall.Y));
            }
        }

        public void InitMonsters(LevelPattern pattern)
        {
            //При инициализации уровня создаем монстров
            foreach (var monster in pattern.MonsterSpawns)
            {
                Monsters.Add(new Monster(monster.X, monster.Y, 10));
            }
        }

        public void InitPlayer(LevelPattern pattern)
        {
            //При инициализации уровня создаем игрока
            Pacman = new Pacman(Pacman.StartX, Pacman.StartY, 10);
        }

        public void MovePacmanDown() => Pacman.MoveDown();
        public void MovePacmanUp() => Pacman.MoveUp();
        public void MovePacmanRight() => Pacman.MoveRight();
        public void MovePacmanLeft() => Pacman.MoveLeft();

        //Произошло измнение - перерисовали карту
        public void Draw(Graphics graphics)
        {
            //Unite
            for (int i = 0; i < Walls.Count; i++)
            {
                var wall = Walls[i];
                var posX = (float)(wall.CurrentPositionX * Dimensions.SpriteWidthPixels);
                var posY = (float)(wall.CurrentPositionY * Dimensions.SpriteHeightPixels);

                graphics.DrawImage(wall.View, posX, posY, Dimensions.SpriteWidthPixels, Dimensions.SpriteHeightPixels);
            }

            for (int i = 0; i < Monsters.Count; i++)
            {
                var monster = Monsters[i];
                var posX = (float)(monster.CurrentPositionX * Dimensions.SpriteWidthPixels);
                var posY = (float)(monster.CurrentPositionY * Dimensions.SpriteHeightPixels);

                graphics.DrawImage(monster.View, posX, posY, Dimensions.SpriteWidthPixels, Dimensions.SpriteHeightPixels);
            }

            graphics.DrawImage(
                Pacman.View,
                Pacman.CurrentPositionX,
                Pacman.CurrentPositionY,
                Dimensions.SpriteWidthPixels,
                Dimensions.SpriteHeightPixels);
        }
    }

    enum GameObjects
    {
        FLOOR,
        PLAYER,
        MONSTER,
        WALL
    }
}
