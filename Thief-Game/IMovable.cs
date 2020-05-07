namespace Thief_Game
{
    //Lev
    //Наследует все, что может двигаться, игрок, монстры
    /// <summary>
    /// Интерфейс управления персонажем.    
    /// </summary>
    public interface IMovable
    {
        public void MoveUp();
        public void MoveLeft();
        public void MoveRight();
        public void MoveDown();
    }
}
