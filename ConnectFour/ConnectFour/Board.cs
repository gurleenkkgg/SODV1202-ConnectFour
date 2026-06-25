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
    public bool CheckHorizontalWin(char symbol)
{
    for (int r = 0; r < 6; r++)
    {
        for (int c = 0; c < 4; c++)
        {
            if (grid[r, c] == symbol && grid[r, c+1] == symbol && 
                grid[r, c+2] == symbol && grid[r, c+3] == symbol)
                return true;
        }
    }
    return false;
}

public bool CheckVerticalWin(char symbol)
{
    for (int c = 0; c < 7; c++)
    {
        for (int r = 0; r < 3; r++)
        {
            if (grid[r, c] == symbol && grid[r+1, c] == symbol && 
                grid[r+2, c] == symbol && grid[r+3, c] == symbol)
                return true;
        }
    }
    return false;
}
}
