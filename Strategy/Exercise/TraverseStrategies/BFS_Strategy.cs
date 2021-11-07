using Strategy.Exercise.Data;
using Strategy.Exercise.Result;
using System;
using System.Collections.Generic;

namespace Strategy.Exercise.TraverseStrategies
{
    /// <summary>
    /// Breadth First Search (BFS) algorithm.
    /// </summary>
    public sealed class BFS_Strategy
    {
        /// <summary>
        /// Try to find the given element.
        /// </summary>
        public TraverseResult Find(string value)
        {
            Node startNode = Graph.StartNode;

            TraverseResult result = new TraverseResult(false, string.Empty,0); ;
            HashSet<Node> path = new HashSet<Node>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(startNode);

            while(queue.Count > 0)
            {
                Node node = queue.Dequeue();
                path.Add(node);
                if (node.Value == value)
                {
                    string pathString = "";
                    foreach (var no in path)
                    {
                        pathString += no.Value;
                    }
                    result = new TraverseResult(true, pathString, Convert.ToUInt16(path.Count));
                    break;
                }
                else
                {
                    if (node.NextLeft != null) queue.Enqueue(node.NextLeft);
                    if (node.NextRight != null) queue.Enqueue(node.NextRight);
                }
            }

            return result;
        }
    }
}
