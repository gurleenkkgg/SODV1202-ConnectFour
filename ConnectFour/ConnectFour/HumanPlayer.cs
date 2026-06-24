namespace ConnectFour
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, char symbol) : base(name, symbol) { }

        public override int ChooseColumn(Board board)
        {
            return ConsoleView.GetColumnInput(Name);
        }
    }
}
