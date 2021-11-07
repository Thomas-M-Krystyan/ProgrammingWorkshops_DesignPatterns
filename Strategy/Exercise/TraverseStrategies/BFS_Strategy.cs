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
        private readonly bool _isLeftHanded;

        /// <summary>
        /// Initializes a new instance of the <see cref="BFS_Strategy"/> class.
        /// </summary>
        /// <param name="isLeftHanded">
        ///   If <c>true</c> left-handed version of DFS algorithm will be used;
        ///   otherwise, if <c>false</c>, right-handed version will be used.
        /// </param>
        public BFS_Strategy(bool isLeftHanded)
        {
            this._isLeftHanded = isLeftHanded;
        }

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
                FollowTheRuleOfHand(queue, currentNode);
            }
            
            return default;  // Nothing was found
        }

        private void FollowTheRuleOfHand(Queue<Node> queue, Node currentNode)
        {
            if (this._isLeftHanded)
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
