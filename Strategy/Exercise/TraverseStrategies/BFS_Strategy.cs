using Strategy.Exercise.Data;
using Strategy.Exercise.Result;
using System;
using System.Collections.Generic;
using System.Text;

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
            if (String.IsNullOrWhiteSpace(value))
            {
                return default;
            }

            // Initialize queue
            var queue = new Queue<Node>(Graph.Count);  // NOTE: Queue can have fixed size, which reduce resize operations on internal array

            queue.Enqueue(Graph.StartNode);  // NOTE: First element of the queue is always the first Node of the Graph

            // Results
            var path = new StringBuilder();
            ushort count = 0;

            // Start traversing
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                path.Append(currentNode.Value);
                count++;

                if (currentNode.Value == value)  // The searched Node was found
                {
                    return new TraverseResult(true, path.ToString(), count);
                }

                // Adding left and right Nodes to the queue
                AddTo(queue, currentNode.NextLeft);
                AddTo(queue, currentNode.NextRight);
            }
            
            return default;  // Nothing was found
        }

        private static void AddTo(Queue<Node> queue, Node node)
        {
            if (node != null)
            {
                queue.Enqueue(node);
            }
        }
    }
}
