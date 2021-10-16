using System;

namespace Strategy
{
    public static class Program
    {
        public static void Main()
        {
            var value = AskForInput();
            
            switch (value)
            {
                case "0":
                    Environment.Exit(0);
                    break;

                case "1":
                    // 1. Use BFS algorithm
                    // 2. Print result
                    break;

                case "2":
                    // 1. Use DFS algorithm
                    // 2. Print result
                    break;

                default:
                    Console.WriteLine("This command is not supported.\n");
                    break;
            }

            Main();
        }

        private static string AskForInput()
        {
            Console.WriteLine(
                "Choose an algorithm:" +
                "\n[0] to EXIT" +
                "\n[1] BFS" +
                "\n[2] DFS" +
                "\nand press ENTER");

            return Console.ReadLine();
        }
    }
}
