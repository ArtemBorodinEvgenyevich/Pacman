using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinder
{
    //Lev
    public class Waypoint
    {
        public readonly int Id;
        public readonly int X;
        public readonly int Y;
        public Waypoint Right;
        public Waypoint Left;
        public Waypoint Up;
        public Waypoint Down;
        public List<Waypoint> IncidentNodes
        {
            get => new List<Waypoint> { Right, Left, Up, Down };
        }

        /// <summary>
        /// Create new waypoint
        /// </summary>
        /// <param name="x">Position X</param>
        /// <param name="y">Position Y</param>
        public Waypoint(int x, int y)
        {
            X = x;
            Y = y;

            Id = IdGenerator.Generate();
        }
    }
}
