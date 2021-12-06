using Strategy.Exercise.TraverseStrategies;
using System;
using System.Text;

namespace Strategy
{
    public static class Program
    {
        private static string seperator = "\n----------------------------------------------------";
        public static void Main()
        {
           
            
            var value = AskForInput();
            var searchValue = AskForLetter();
            var context = new Context(new BFS_Strategy());
            Console.WriteLine("\nPlease select an algrithom to search the result."); 
            StringBuilder result = new StringBuilder();
            result.Append(seperator);

            switch (value)
            {
                case "0":
                    Environment.Exit(0);
                    break;

                case "1":
                    // 1. Use BFS algorithm left hand
                    context.SetStrategy(new BFS_Strategy());
                    result.Append("\nSelected algorithm is BFS Left Hand.");
                    result.Append("\nResult:");
                    result.Append(Search(context, true,searchValue));
                    // 2. Print result
                    break;

                case "2":
                    context.SetStrategy(new BFS_Strategy());
                    result.Append("\nSelected algorithm is BFS Right Hand.");
                    result.Append("\nResult:");
                    result.Append(Search(context, false, searchValue));
                    // 1. Use BFS algorithm Right
                    // 2. Print result
                    break;
                case "3":
                    context.SetStrategy(new DFS_Strategy());
                    result.Append("\nSelected algorithm is DFS Left Hand.");
                    result.Append("\nResult:");
                    result.Append(Search(context, true, searchValue));
                    // 1. Use DFS algorithm left
                    // 2. Print result
                    break;
                case "4":
                    context.SetStrategy(new DFS_Strategy());
                    result.Append("\nSelected algorithm is DFS Right Hand.");
                    result.Append("\nResult:");
                    result.Append(Search(context, false, searchValue));
                    // 1. Use DFS algorithm right
                    // 2. Print result
                    break;

                default:
                    Console.WriteLine("This command is not supported.\n");
                    break;
            }
            Console.WriteLine(result);
            Console.WriteLine(seperator);
            Main();
        }

        private static string AskForInput()
        {
            Console.WriteLine(
                "Choose an algorithm:" +
                "\n[0] to EXIT" +
                "\n[1] BFS(Left Hand)" +
                "\n[2] BFS(Right Hand)" +
                "\n[3] DFS(Left Hand)" +
                "\n[4] DFS(Right Hand)" +
                "\nand press ENTER");

            return Console.ReadLine();
        }

        private static string AskForLetter()
        {
            Console.WriteLine(
                "Now chose the letter you want search for:" +
                $"\nand press [ENTER]");

            return Console.ReadLine().ToUpper();
        }

        private static string Search(Context context, bool isLeftHand, string value)
        {
            var result = context.Find(isLeftHand, value);
            Console.WriteLine($"\nIsFound: {result.IsFound}");
            return result.Path;
        }
    }
}
