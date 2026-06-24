namespace ConnectFour
{
    public abstract class Player
    {
        public string Name { get; }
        public char Symbol { get; }

        protected Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public abstract int ChooseColumn(Board board);
    }
}  
