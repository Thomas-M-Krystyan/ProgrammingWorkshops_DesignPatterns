using Iterator.Exercise.Data;
using Iterator.Exercise.TraverseStrategies.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Iterator.Exercise.TraverseStrategies
{
    /// <summary>
    /// Breadth First Search (BFS) algorithm.
    /// </summary>
    public sealed class BFS_Strategy : IStrategy
    {
        /// <inheritdoc/>
        public string GetName()
        {
            return "BFS Strategy";
        }

        /// <inheritdoc/>
        public void GetNode(bool isLeftHanded)
        {
            // Initialize queue
            Queue<Node> queue = new(Graph.Count);  // NOTE: Queue can have fixed size, which reduce resize operations on internal array

            queue.Enqueue(Graph.StartNode);  // NOTE: First element of the queue is always the first Node of the Graph

            // Results
            StringBuilder path = new();
            ushort count = 0;

            // Start traversing
            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();
                path.Append(currentNode.Value);
                count++;

                // Adding left and right Nodes to the queue
                FollowTheRuleOfHand(isLeftHanded, queue, currentNode);
            }
        }

        private static void FollowTheRuleOfHand(bool isLeftHanded, Queue<Node> queue, Node currentNode)
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
