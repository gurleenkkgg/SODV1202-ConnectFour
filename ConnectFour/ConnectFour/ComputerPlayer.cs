using System;
using System.Xml.Linq;

namespace ConnectFour
{
    // ComputerPlayer inherits from Player (Inheritance & Polymorphism)
    // Milestone 6: Optional AI/Computer player implementation
    public class ComputerPlayer : Player
    {
        private Random random = new Random();

        // AI Reference: The Random class usage for column selection was referenced using AI assistance
        public ComputerPlayer(string name, char symbol) : base(name, symbol) { }

        // Overrides ChooseColumn with automated logic instead of console input (Polymorphism)
        public override int ChooseColumn(Board board)
        {
            Console.WriteLine($"{Name} is thinking...");
            System.Threading.Thread.Sleep(1000); // Small delay to simulate thinking

            // Strategy 1: Check if computer can win immediately
            for (int c = 0; c < 7; c++)
            {
                if (board.IsValidMove(c))
                {
                    board.PlacePiece(c, Symbol);
                    bool wins = board.CheckHorizontalWin(Symbol) ||
                                board.CheckVerticalWin(Symbol) ||
                                board.CheckDiagonalWin(Symbol);
                    board.UndoLastMove(c); // Undo test move
                    if (wins) return c;
                }
            }

            // Strategy 2: Block opponent from winning
            char opponentSymbol = (Symbol == 'X') ? 'O' : 'X';
            for (int c = 0; c < 7; c++)
            {
                if (board.IsValidMove(c))
                {
                    board.PlacePiece(c, opponentSymbol);
                    bool opponentWins = board.CheckHorizontalWin(opponentSymbol) ||
                                       board.CheckVerticalWin(opponentSymbol) ||
                                       board.CheckDiagonalWin(opponentSymbol);
                    board.UndoLastMove(c); // Undo test move
                    if (opponentWins) return c;
                }
            }

            // Strategy 3: Pick a random valid column
            int col;
            do { col = random.Next(0, 7); }
            while (!board.IsValidMove(col));
            return col;
        }
    }
}
