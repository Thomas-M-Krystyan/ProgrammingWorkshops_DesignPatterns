using Strategy.Exercise.Data;
using Strategy.Exercise.Result;
using System;
using System.Collections.Generic;

namespace Strategy.Exercise.TraverseStrategies
{
    /// <summary>
    /// Depth First Search (DFS) algorithm.
    /// </summary>
    public sealed class DFS_Strategy : IStrategy
    {
        /// <summary>
        /// Try to find the given element.
        /// </summary>
        /// <param name="value">The value of the Node to be found.</param>
        /// <param name="isLeftHanded">
        ///   If <c>true</c> left-handed version of <see cref="DFS_Strategy"/> algorithm will be used;
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
                Stack<Node> stack = new Stack<Node>();
                stack.Push(startNode);

                while (stack.Count > 0)
                {
                    Node node = stack.Pop();
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
                            if (node.NextLeft != null) stack.Push(node.NextLeft);                         
                            if (node.NextRight != null) stack.Push(node.NextRight);
                            
                        }
                        else
                        {
                            if (node.NextRight != null) stack.Push(node.NextRight);
                            if (node.NextLeft != null) stack.Push(node.NextLeft);
                            
                            
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

        public string GetName()
        {
            return "DFS";
        }
    }
}
