namespace Thief_Game
{
    //Lev
    /// <summary>
    /// Interface for character movement    
    /// </summary>
    public interface IMovable
    {
        public void MoveUp();
        public void MoveLeft();
        public void MoveRight();
        public void MoveDown();
    }
}
