namespace Thief_Game
{
    //Lev
    class ScorePoint
    {
        public readonly int X;
        public readonly int Y;
        public bool IsActive;
        public const int Score = 10;

        public ScorePoint(int x, int y)
        {
            //Точки, которые дают очки
            X = x;
            Y = y;
            IsActive = true;
        }

        /// <summary>
        /// Действия, при съедении точки
        /// </summary>
        public void Eat()
        {
            IsActive = false;
        }
    }
}
