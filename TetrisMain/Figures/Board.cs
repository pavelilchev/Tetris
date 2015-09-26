namespace TetrisMain.Figures
{
    public class Board
    {
        private const int BoardHeight = 20;

        private const int BoardWidth = 10;

        public Board()
        {
            this.Form = new bool[BoardHeight, BoardWidth];
        }

        public bool[,] Form { get; set; }
    }
}
