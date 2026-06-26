using System;

namespace ConnectFour
{
    // Controller class - manages game flow and turn alternation
    public class GameController
    {
        private Board board;
        private Player player1;
        private Player player2;
        private Player currentPlayer;

        public GameController()
        {
            board = new Board();
            player1 = new HumanPlayer("Player 1", 'X');
            player2 = new HumanPlayer("Player 2", 'O');
            currentPlayer = player1;
        }

        // Main game loop - handles turns, win checks, and draw conditions
        public void StartGame()
        {
            bool running = true;
            board.ResetBoard();
            currentPlayer = player1;

            while (running)
            {
                ConsoleView.DisplayBoard(board);
                int chosenCol = currentPlayer.ChooseColumn(board);

                if (board.PlacePiece(chosenCol, currentPlayer.Symbol))
                {
                    // AI Reference: The ternary operator for switching players was suggested
                    //               as a concise alternative using AI assistance
                    if (board.CheckHorizontalWin(currentPlayer.Symbol) ||
                        board.CheckVerticalWin(currentPlayer.Symbol) ||
                        board.CheckDiagonalWin(currentPlayer.Symbol))
                    {
                        ConsoleView.DisplayBoard(board);
                        Console.WriteLine($"CONGRATULATIONS! {currentPlayer.Name} ({currentPlayer.Symbol}) wins!");
                        running = false;
                    }
                    else if (board.IsBoardFull())
                    {
                        ConsoleView.DisplayBoard(board);
                        Console.WriteLine("It's a draw! The board is full.");
                        running = false;
                    }
                    else
                    {
                        // Switch turns using ternary operator
                        currentPlayer = (currentPlayer == player1) ? player2 : player1;
                    }
                }
                else
                {
                    Console.WriteLine("Column is full! Press any key to try again...");
                    Console.ReadKey();
                }
            }
        }
    }
}
