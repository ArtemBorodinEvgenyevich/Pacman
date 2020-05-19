using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Thief_Game
{
    /// <summary>
    /// Base class for movable objects such as Monsters, Pacman
    /// </summary>
    public class MovableGameObject
    {
        protected int X;
        protected int Y; 
        
        public int CurrentPositionX
        {
            get => X;
        }
        public int CurrentPositionY
        {
            get => Y;
        }

        public Image View;

        public MovableGameObject(string path)
        {
            View = Image.FromFile(path);
        }
    }
}
