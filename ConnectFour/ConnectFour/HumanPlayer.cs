namespace ConnectFour
{
    // HumanPlayer inherits from Player (Inheritance)
    public class HumanPlayer : Player
    {
        // AI Reference: The ': base(name, symbol)' constructor chaining syntax was clarified using AI (gemini)
        public HumanPlayer(string name, char symbol) : base(name, symbol) { }

        // Overrides abstract method - gets column choice from console input
        public override int ChooseColumn(Board board)
        {
            return ConsoleView.GetColumnInput(Name);
        }
    }
}
