using System;

namespace ConnectFour
{
    public static class ConsoleView
    {
        public static void DisplayBoard(Board board)
        {
            Console.Clear();
            Console.WriteLine("=== CONNECT FOUR ===");
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 7; c++)
                {
                    Console.Write($"| {board.GetPiece(r, c)} ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("  1   2   3   4   5   6   7  \n");
        }

        public static int GetColumnInput(string playerName)
        {
            while (true)
            {
                Console.Write($"{playerName}, choose a column (1-7): ");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 7)
                {
                    return choice - 1; // Converts 1-7 layout to 0-6 index
                }
                Console.WriteLine("Invalid input! Please enter a number between 1 and 7.");
            }
        }
    }
}
