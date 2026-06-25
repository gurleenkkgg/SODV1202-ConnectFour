namespace ConnectFour
{
    // Model class - handles all game data and logic (Encapsulation)
    public class Board
    {
        // Private grid - hidden from outside classes
        private char[,] grid = new char[6, 7];

        public Board() { ResetBoard(); }

        // Resets all cells to empty
        public void ResetBoard()
        {
            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 7; c++)
                    grid[r, c] = ' ';
        }

        // Returns the piece at a given position
        public char GetPiece(int row, int col) => grid[row, col];

        // Checks if a column has space available
        public bool IsValidMove(int col) => col >= 0 && col < 7 && grid[0, col] == ' ';

        // Drops a piece into the lowest available row in a column
        public bool PlacePiece(int col, char symbol)
        {
            if (!IsValidMove(col)) return false;

            for (int r = 5; r >= 0; r--)
            {
                if (grid[r, col] == ' ')
                {
                    grid[r, col] = symbol;
                    return true;
                }
            }
            return false;
        }

        // Checks for four in a row horizontally
        public bool CheckHorizontalWin(char symbol)
        {
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (grid[r, c] == symbol && grid[r, c + 1] == symbol &&
                        grid[r, c + 2] == symbol && grid[r, c + 3] == symbol)
                        return true;
                }
            }
            return false;
        }

        // Checks for four in a row vertically
        public bool CheckVerticalWin(char symbol)
        {
            for (int c = 0; c < 7; c++)
            {
                for (int r = 0; r < 3; r++)
                {
                    if (grid[r, c] == symbol && grid[r + 1, c] == symbol &&
                        grid[r + 2, c] == symbol && grid[r + 3, c] == symbol)
                        return true;
                }
            }
            return false;
        }

        // Checks for four in a row diagonally (both directions)
        // AI Reference: The boundary conditions for diagonal loop limits (r < 3, c < 4)
        //               were confirmed using AI assistance to avoid index out of bounds
        public bool CheckDiagonalWin(char symbol)
        {
            // Descending diagonal (\)
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 4; c++)
                    if (grid[r, c] == symbol && grid[r + 1, c + 1] == symbol &&
                        grid[r + 2, c + 2] == symbol && grid[r + 3, c + 3] == symbol) return true;

            // Ascending diagonal (/)
            for (int r = 3; r < 6; r++)
                for (int c = 0; c < 4; c++)
                    if (grid[r, c] == symbol && grid[r - 1, c + 1] == symbol &&
                        grid[r - 2, c + 2] == symbol && grid[r - 3, c + 3] == symbol) return true;

            return false;
        }

        // Returns true if no empty spaces remain (draw condition)
        public bool IsBoardFull()
        {
            for (int c = 0; c < 7; c++)
                if (grid[0, c] == ' ') return false;
            return true;
        }

        // Removes the top piece from a column (used by ComputerPlayer to test moves)
        public void UndoLastMove(int col)
        {
            for (int r = 0; r < 6; r++)
            {
                if (grid[r, col] != ' ')
                {
                    grid[r, col] = ' ';
                    return;
                }
            }
        }

    } 
}     
