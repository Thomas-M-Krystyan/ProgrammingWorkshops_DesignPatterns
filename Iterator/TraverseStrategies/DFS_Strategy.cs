using Iterator.Exercise.Data;
using Iterator.Exercise.TraverseStrategies.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Iterator.Exercise.TraverseStrategies
{
    /// <summary>
    /// Depth First Search (DFS) algorithm.
    /// </summary>
    public sealed class DFS_Strategy : IStrategy
    {
        /// <inheritdoc/>
        public string GetName()
        {
            return "DFS Strategy";
        }

        /// <inheritdoc/>
        public void GetNode(bool isLeftHanded)
        {
            // Initialize stack
            Stack<Node> stack = new(Graph.Count);  // NOTE: Stack can have fixed size, which reduce resize operations on internal array

            stack.Push(Graph.StartNode);  // NOTE: First element of the stack is always the first Node of the Graph

            // Results
            StringBuilder path = new();
            ushort count = 0;

            // Start traversing
            while (stack.Count > 0)
            {
                Node currentNode = stack.Pop();
                path.Append(currentNode.Value);
                count++;

                // Adding left and right Nodes to the stack
                FollowTheRuleOfHand(isLeftHanded, stack, currentNode);
            }
        }

        private static void FollowTheRuleOfHand(bool isLeftHanded, Stack<Node> stack, Node currentNode)
        {
            if (isLeftHanded)
            {
                AddTo(stack, currentNode.NextRight);
                AddTo(stack, currentNode.NextLeft);
            }
            else
            {
                AddTo(stack, currentNode.NextLeft);
                AddTo(stack, currentNode.NextRight);
            }
        }

        private static void AddTo(Stack<Node> stack, Node node)
        {
            if (node != null)
            {
                stack.Push(node);
            }
        }
    }
}
