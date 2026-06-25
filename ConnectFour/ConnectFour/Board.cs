namespace ConnectFour{
    public class Board    {
        private char[,] grid = new char[6, 7];

        public Board() { ResetBoard(); }

        public void ResetBoard()        {
            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 7; c++)
                    grid[r, c] = ' ';
        }

        public char GetPiece(int row, int col) => grid[row, col];

        public bool IsValidMove(int col) => col >= 0 && col < 7 && grid[0, col] == ' ';

        public bool PlacePiece(int col, char symbol)        {
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
    }
}
