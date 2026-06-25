namespace ConnectFour
{
    // Abstract base class demonstrating Abstraction and Inheritance
    public abstract class Player
    {
        // Encapsulated properties - read only from outside
        public string Name { get; }
        public char Symbol { get; }

        protected Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        // Abstract method - forces subclasses to implement their own version (Polymorphism)
        // AI Reference: Syntax for declaring an abstract method in C# was verified using gemini AI
        public abstract int ChooseColumn(Board board);
    }
}
