using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Thief_Game
{
    //Наследует все, что может двигаться, игрок, монстры
    interface IMovable
    {
        public void MoveUp();
        public void MoveLeft();
        public void MoveRight();
        public void MoveDown();
    }
}
