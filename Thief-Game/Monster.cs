using System;
using System.Collections.Generic;
using System.Text;

namespace Thief_Game
{
    class Monster
    {
        int x;
        int y;

        int startX;
        int startY;

        //Direction - возможно, понадобится для построения траекторий

        Behaviors currentBehavior;


        public Monster()
        {

        }
        
        public void MoveUp()
        {

        }

        public void MoveLeft()
        {

        }

        public void MoveRight()
        {

        }

        public void MoveDown()
        {

        }
    }

    enum Behaviors
    {
        PURSUITING,
        DISPERSING,
        FRIGHTNING
    }
}
