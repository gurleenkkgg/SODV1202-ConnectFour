using System;

namespace ConnectFour
{
    // Entry point - displays the main menu and manages game sessions
    class Program
    {
        // AI Reference: The overall main menu loop structure was used as a reference from AI assistance
        static void Main(string[] args)
        {
            GameController game = new GameController();
            bool keepPlaying = true;

            while (keepPlaying)
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("   WELCOME TO CONNECT FOUR    ");
                Console.WriteLine("===============================");
                Console.WriteLine("1. Play a Match");
                Console.WriteLine("2. Exit");
                Console.Write("\nSelect an option: ");

                string? selection = Console.ReadLine();
                if (selection == "1")
                {
                    game.StartGame();
                    Console.WriteLine("\nPress any key to return to the Main Menu...");
                    Console.ReadKey();
                }
                else if (selection == "2")
                {
                    keepPlaying = false;
                    Console.WriteLine("Goodbye!");
                }
            }
        }
    }
}
