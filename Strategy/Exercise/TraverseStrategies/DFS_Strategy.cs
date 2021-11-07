using Strategy.Exercise.Data;
using Strategy.Exercise.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Exercise.TraverseStrategies
{
    /// <summary>
    /// Depth First Search (DFS) algorithm.
    /// </summary>
    public sealed class DFS_Strategy
    {
        /// <summary>
        /// Try to find the given element.
        /// </summary>
        /// <param name="value">The value of the Node to be found.</param>
        /// <param name="isLeftHanded">
        ///   If <c>true</c> left-handed version of DFS algorithm will be used;
        ///   otherwise, if <c>false</c>, right-handed version will be used.
        /// </param>
        public TraverseResult Find(string value, bool isLeftHanded)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return default;
            }

            // Initialize stack
            var stack = new Stack<Node>(Graph.Count);  // NOTE: Stack can have fixed size, which reduce resize operations on internal array

            stack.Push(Graph.StartNode);  // NOTE: First element of the stack is always the first Node of the Graph

            // Results
            var path = new StringBuilder();
            ushort count = 0;

            // Start traversing
            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                path.Append(currentNode.Value);
                count++;

                if (currentNode.Value == value)  // The searched Node was found
                {
                    return new TraverseResult(true, path.ToString(), count);
                }

                // Adding left and right Nodes to the stack
                FollowTheRuleOfHand(isLeftHanded, stack, currentNode);
            }

            return default;  // Nothing was found
        }

        private void FollowTheRuleOfHand(bool isLeftHanded, Stack<Node> stack, Node currentNode)
        {
            if (isLeftHanded)
            {
                AddTo(stack, currentNode.NextLeft);
                AddTo(stack, currentNode.NextRight);
            }
            else
            {
                AddTo(stack, currentNode.NextRight);
                AddTo(stack, currentNode.NextLeft);
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
