using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder
{
    public class Graph
    {
        public List<Node> GraphNodes;
        public Dictionary<int, Node> IncidentNodes;

        public Graph()
        {
            GraphNodes = new List<Node>();
            IncidentNodes = new Dictionary<int, Node>();
        }

        public void Add(Node newNode)
        {
            IncidentNodes.Add(newNode.Id, newNode);

            if (GraphNodes.Count == 0)
            {
                GraphNodes.Add(newNode);
            }
            else
            {
                GraphNodes.Add(newNode);

                var neighbours = GraphNodes
                    .Select(x => x)
                    .Where(x => ((x.X == newNode.X - 1) || (x.X == newNode.X + 1) || (x.Y == newNode.Y - 1) || (x.Y == newNode.Y + 1)))
                    .ToList();

                foreach (var node in neighbours)
                {
                    if ((node.X == newNode.X - 1) && (node.Y == newNode.Y))
                    {
                        node.Right = newNode;
                        newNode.Left = node;
                    }

                    if ((node.X == newNode.X + 1) && (node.Y == newNode.Y))
                    {
                        node.Left = newNode;
                        newNode.Right = node;
                    }

                    if ((node.Y == newNode.Y - 1) && (node.X == newNode.X))
                    {
                        node.Down = newNode;
                        newNode.Up = node;
                    }

                    if ((node.Y == newNode.Y + 1) && (node.X == newNode.X))
                    {
                        node.Up = newNode;
                        newNode.Down = node;
                    }
                }
            }
        }

        public void Print()
        {
            var y = 0;

            foreach (var node in GraphNodes)
            {
                Console.SetCursorPosition(node.X * 2, node.Y * 2);
                Console.Write(node.Id);

                if (node.Y * 2 > y) y = node.Y * 2;

                if (node.Right != null)
                {
                    Console.SetCursorPosition(node.X * 2 + 1, node.Y * 2);
                    Console.Write('-');
                }
                if (node.Left != null)
                {
                    Console.SetCursorPosition(node.X * 2 - 1, node.Y * 2);
                    Console.Write('-');
                }
                if (node.Up != null)
                {
                    Console.SetCursorPosition(node.X * 2, node.Y * 2 - 1);
                    Console.Write('|');
                }
                if (node.Down != null)
                {
                    Console.SetCursorPosition(node.X * 2, node.Y * 2 + 1);
                    Console.Write('|');
                }
            }

            Console.SetCursorPosition(0, y);
            Console.WriteLine();
        }

        public IEnumerable<Node> DepthSearch(Node startNode, Node finish)
        {
            var visited = new HashSet<int>();
            var stack = new Stack<int>();
            stack.Push(startNode.Id);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                if (visited.Contains(node)) continue;
                visited.Add(node);
                yield return IncidentNodes[node];

                if (IncidentNodes[node].Down != null)
                    stack.Push(IncidentNodes[node].Down.Id);
                if (IncidentNodes[node].Up != null)
                    stack.Push(IncidentNodes[node].Up.Id);
                if (IncidentNodes[node].Left != null)
                    stack.Push(IncidentNodes[node].Left.Id);
                if (IncidentNodes[node].Right != null)
                    stack.Push(IncidentNodes[node].Right.Id);

                if (node == finish.Id)
                    break;
            }
        }

        public List<Node> FindPath(Node start, Node end)
        {
            var track = new Dictionary<Node, Node>();
            track[start] = null;
            var queue = new Queue<Node>();
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
            var result = new List<Node>();
            while (pathItem != null)
            {
                result.Add(pathItem);
                pathItem = track[pathItem];
            }
            result.Reverse();
            return result;
        }
    }

    public class Node
    {
        //ID - fast access
        public readonly int Id;
        public readonly int X;
        public readonly int Y;
        public Node Right;
        public Node Left;
        public Node Up;
        public Node Down;
        public List<Node> IncidentNodes
        {
            get => new List<Node> { Right, Left, Up, Down };
        }

        public Node(int x, int y)
        {
            X = x;
            Y = y;

            Id = IdGenerator.Generate();
        }
    }

    public static class IdGenerator
    {
        public static int LastId = 0;

        public static int Generate()
        {
            LastId++;

            return LastId;
        }
    }
}
