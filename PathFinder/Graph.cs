using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder
{
    //Lev
    public class Graph
    {
        public List<Waypoint> GraphNodes;
        public Dictionary<int, Waypoint> IncidentNodes;
        private Dictionary<(int, int), Waypoint> Nodes;
        private Waypoint LeftBottomCorner;
        public Waypoint GetLeftBottomCorner
        {
            get => LeftBottomCorner;
        }

        /// <summary>
        /// Using this type of data for finding paths 
        /// </summary>
        public Graph()
        {
            GraphNodes = new List<Waypoint>();
            IncidentNodes = new Dictionary<int, Waypoint>();
            Nodes = new Dictionary<(int, int), Waypoint>();
        }

        /// <summary>
        /// Add waypoint to graph
        /// </summary>
        /// <param name="newWaypoint">Waypoint</param>
        public void Add(Waypoint newWaypoint)
        {
            IncidentNodes.Add(newWaypoint.Id, newWaypoint);
            Nodes.Add((newWaypoint.X, newWaypoint.Y), newWaypoint);

            if (GraphNodes.Count == 0)
            {
                GraphNodes.Add(newWaypoint);
                LeftBottomCorner = newWaypoint;
            }
            else
            {
                if (((newWaypoint.X < LeftBottomCorner.X) && (newWaypoint.X > 0)) || (newWaypoint.Y > LeftBottomCorner.Y))
                    LeftBottomCorner = newWaypoint;

                GraphNodes.Add(newWaypoint);

                var neighbours = GraphNodes
                    .Select(x => x)
                    .Where(x => ((x.X == newWaypoint.X - 1) || (x.X == newWaypoint.X + 1) || (x.Y == newWaypoint.Y - 1) || (x.Y == newWaypoint.Y + 1)))
                    .ToList();

                foreach (var node in neighbours)
                {
                    if ((node.X == newWaypoint.X - 1) && (node.Y == newWaypoint.Y))
                    {
                        node.Right = newWaypoint;
                        newWaypoint.Left = node;
                    }

                    if ((node.X == newWaypoint.X + 1) && (node.Y == newWaypoint.Y))
                    {
                        node.Left = newWaypoint;
                        newWaypoint.Right = node;
                    }

                    if ((node.Y == newWaypoint.Y - 1) && (node.X == newWaypoint.X))
                    {
                        node.Down = newWaypoint;
                        newWaypoint.Up = node;
                    }

                    if ((node.Y == newWaypoint.Y + 1) && (node.X == newWaypoint.X))
                    {
                        node.Up = newWaypoint;
                        newWaypoint.Down = node;
                    }
                }
            }
        }
        
        /// <summary>
        /// Use this algorythm for find path to waypoint
        /// </summary>
        /// <param name="start">Start waypoint</param>
        /// <param name="end">End waypoint</param>
        /// <returns></returns>
        public List<Waypoint> FindPath(Waypoint start, Waypoint end)
        {
            var track = new Dictionary<Waypoint, Waypoint>();
            track[start] = null;
            var queue = new Queue<Waypoint>();
            queue.Enqueue(start);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                foreach (var nextNode in node.IncidentNodes)
                {
                    if (nextNode == null) continue;
                    if (track.ContainsKey(nextNode)) continue;
                    track[nextNode] = node;
                    queue.Enqueue(nextNode);
                }

                if (track.ContainsKey(end)) break;
            }
            var pathItem = end;
            var result = new List<Waypoint>();
            while (pathItem != null)
            {
                result.Add(pathItem);
                pathItem = track[pathItem];
            }
            result.Reverse();
            return result;
        }

        /// <summary>
        /// Calculate distance between waypoints
        /// </summary>
        /// <param name="first">First waypoint</param>
        /// <param name="second">Swcond waypoint</param>
        /// <returns>Distance</returns>
        public double Distance(Waypoint first, Waypoint second)
        {
            var dx = first.X - second.X;
            var dy = first.Y - second.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// If you got waypoint with incorrect position
        /// You can use this method for get nearest correct
        /// waypoint
        /// </summary>
        /// <param name="x">New waypoint position X</param>
        /// <param name="y">New waypoint position Y</param>
        /// <returns>Correct waypoint</returns>
        public Waypoint FindNearestNode(int x, int y)
        {
            var nodeId = 0;
            var minLength = double.MaxValue;

            foreach(var node in GraphNodes)
            {
                var distance = Distance(node, new Waypoint(x, y));

                if(distance < minLength)
                {
                    minLength = distance;
                    nodeId = node.Id;
                }
            }

            return IncidentNodes[nodeId];
        }

        /// <summary>
        /// Return true if graph contain waypoint
        /// </summary>
        /// <param name="x">Waypoint position X</param>
        /// <param name="y">Waypoint position Y</param>
        /// <returns>True if graph contains this waypoint</returns>
        public bool Contains(int x, int y)
        {
            return Nodes.ContainsKey((x, y));
        }

        /// <summary>
        /// You can get current waypoint by position
        /// </summary>
        /// <param name="x">Waypoint position X</param>
        /// <param name="y">Waypoint position Y</param>
        /// <returns></returns>
        public Waypoint this [int x, int y]
        {
            get => Nodes[(x, y)];
        }
    }
}
