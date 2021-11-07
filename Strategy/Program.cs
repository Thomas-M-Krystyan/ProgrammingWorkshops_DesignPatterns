using Strategy.Exercise.TraverseStrategies;
using Strategy.Strategy;
using System;

namespace Strategy
{
    public static class Program
    {
        private const string Separator = "\n------------------------------";

        private static readonly Context Context = new();

        public static void Main()
        {
            var value = AskForInput();
            
            switch (value)
            {
                case "0":
                    Environment.Exit(0);
                    break;

                case "1":
                    Context.SetStrategy(new BFS_Strategy());
                    Process(isLeftHanded: true);
                    break;

                case "2":
                    Context.SetStrategy(new BFS_Strategy());
                    Process(isLeftHanded: false);
                    break;

                case "3":
                    Context.SetStrategy(new DFS_Strategy());
                    Process(isLeftHanded: true);
                    break;

                case "4":
                    Context.SetStrategy(new DFS_Strategy());
                    Process(isLeftHanded: false);
                    break;

                default:
                    Console.WriteLine($"This command is not supported.{Separator}");
                    break;
            }

            Main();
        }

        private static string AskForInput()
        {
            Console.WriteLine(
                "Choose an algorithm:" +
                "\n[0] to EXIT" +
                "\n[1] BFS (left-handed)" +
                "\n[2] BFS (right-handed)" +
                "\n[3] DFS (left-handed)" +
                "\n[4] DFS (right-handed)" +
                $"\nand press [ENTER]{Separator}");

            return Console.ReadLine();
        }

        /// <summary>
        /// Use the graph traversing algorithm (left- or right-handed) and print the result as a friendly string.
        /// </summary>
        private static void Process(bool isLeftHanded)
        {
            DisplayResult(Context.Find(AskForLetter(), isLeftHanded));
        }

        private static string AskForLetter()
        {
            Console.WriteLine($"\"{Context.GetName()}\" is selected.\n");

            Console.WriteLine(
                "Now, pick the letter from A-Z (case insensitive)" +
                $"\nand press [ENTER]{Separator}");

            return Console.ReadLine().ToUpper();
        }

        private static void DisplayResult(string result)
        {
            Console.WriteLine($"{result}{Separator}");
        }
    }
}
