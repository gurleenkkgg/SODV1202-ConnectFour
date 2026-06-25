// the code examples used by proffessor in class were used as a reference

using System;

namespace ConnectFour
{
    // View class - handles all console input and output (Separation of Concerns)
    public static class ConsoleView
    {
        // Displays the current board state to the console
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

        // Prompts the player for a valid column input and returns the 0-based index
        // AI Reference: The use of int.TryParse() for safe input validation was referenced using AI assistance
        public static int GetColumnInput(string playerName)
        {
            while (true)
            {
                Console.Write($"{playerName}, choose a column (1-7): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 7)
                {
                    return choice - 1; // Convert 1-7 to 0-6 index
                }
                Console.WriteLine("Invalid input! Please enter a number between 1 and 7.");
            }
        }
    }
}
