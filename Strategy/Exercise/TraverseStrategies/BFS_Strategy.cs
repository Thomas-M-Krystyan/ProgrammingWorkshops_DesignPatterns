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
        /// <param name="value">The value of the Node to be found.</param>
        /// <param name="isLeftHanded">
        ///   If <c>true</c> left-handed version of <see cref="BFS_Strategy"/> algorithm will be used;
        ///   otherwise, if <c>false</c>, right-handed version will be used.
        /// </param>
        public TraverseResult Find(string value, bool isLeftHanded)
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
                FollowTheRuleOfHand(isLeftHanded, queue, currentNode);
            }
            
            return default;  // Nothing was found
        }

        private void FollowTheRuleOfHand(bool isLeftHanded, Queue<Node> queue, Node currentNode)
        {
            if (isLeftHanded)
            {
                AddTo(queue, currentNode.NextLeft);
                AddTo(queue, currentNode.NextRight);
            }
            else
            {
                AddTo(queue, currentNode.NextRight);
                AddTo(queue, currentNode.NextLeft);
            }
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
