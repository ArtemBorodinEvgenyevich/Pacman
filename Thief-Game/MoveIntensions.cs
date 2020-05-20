using System;
using System.Collections.Generic;
using System.Text;

namespace Thief_Game
{
    /// <summary>
    /// Flags for <see cref="Map.CheckWallCollision(MovableGameObject, List{Wall}, MoveIntensions)"/>
    /// </summary>
    public enum MoveIntensions
    {
        UP,
        DOWN,
        RIGHT,
        LEFT    
    }
}
