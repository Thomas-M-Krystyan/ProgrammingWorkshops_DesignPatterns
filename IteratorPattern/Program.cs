using Iterator.Exercise.Data;
using Iterator.Exercise.TraverseStrategies;
using System;

namespace IteratorPattern
{
    public static class Program
    {
        public static void Main()
        {
            // Using BFS iterator
            BFS_Strategy bfs = new();

            foreach (Node node in bfs)  // NOTE: Implement the BFS iterator
            {
                if (node.Value == "H")
                {
                    Console.WriteLine("BFS iterator found letter \"H\"");
                }
            }

            // Using DFS iterator
            DFS_Strategy dfs = new();

            foreach (Node node in dfs)  // NOTE: Implement the DFS iterator
            {
                if (node.Value == "H")
                {
                    Console.WriteLine("DFS iterator found letter \"H\"");
                }
            }
        }
    }
}
