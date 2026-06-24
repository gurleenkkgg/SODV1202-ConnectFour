if (board.PlacePiece(chosenCol, currentPlayer.Symbol))
{
    if (board.CheckHorizontalWin(currentPlayer.Symbol) || 
        board.CheckVerticalWin(currentPlayer.Symbol) || 
        board.CheckDiagonalWin(currentPlayer.Symbol))
    {
        ConsoleView.DisplayBoard(board);
        Console.WriteLine($"🎉 CONGRATULATIONS! {currentPlayer.Name} ({currentPlayer.Symbol}) wins!");
        running = false;
    }
    else if (board.IsBoardFull())
    {
        ConsoleView.DisplayBoard(board);
        Console.WriteLine("🤝 It's a draw! The board is full.");
        running = false;
    }
    else    {
        currentPlayer = (currentPlayer == player1) ? player2 : player1;
    }
}
