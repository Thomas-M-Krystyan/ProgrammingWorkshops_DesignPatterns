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
        /// <param name="value">The value of the Node to be found.</param>
        /// <param name="isLeftHanded">
        ///   If <c>true</c> left-handed version of <see cref="BFS_Strategy"/> algorithm will be used;
        ///   otherwise, if <c>false</c>, right-handed version will be used.
        /// </param>
        public TraverseResult Find(string value, bool isLeftHanded)
        {
            
            TraverseResult result = new TraverseResult(false, string.Empty, 0); ;

            if (value != string.Empty && value != null)
            {
                value = value.Trim();
                if (value == null || value == string.Empty) return result;

                Node startNode = Graph.StartNode;

                HashSet<Node> path = new HashSet<Node>();
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(startNode);

                while (queue.Count > 0)
                {
                    Node node = queue.Dequeue();
                    path.Add(node);
                    if (path.Count == 10)
                    {
                        string pathString = "";
                        foreach (var no in path)
                        {
                            pathString += no.Value;
                        }
                        return new TraverseResult(false, pathString, 10);
                    }
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
                        if (isLeftHanded)
                        {
                            if (node.NextLeft != null) queue.Enqueue(node.NextLeft);
                            if (node.NextRight != null) queue.Enqueue(node.NextRight);
                        }
                        else
                        {
                            if (node.NextRight != null) queue.Enqueue(node.NextRight);
                            if (node.NextLeft != null) queue.Enqueue(node.NextLeft);
                        }

                    }
                }

            }
            else
            {
                return result;
            }
            return result;
        }
    }
}
