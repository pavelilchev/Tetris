namespace TetrisMain.Figures
{
    using Utility;
   
    public class Square : Figure
    {
        private readonly Point SquareCorner = new Point(-1, 3);

        private readonly bool[,] SquareForm =
        {
            {false, false, false, false},
            {false, true, true, false},
            {false, true, true, false },
            {false, false, false, false}
        };


        public Square() : 
            base()
        {
            this.Form = SquareForm;
            this.UperLeftCorner = SquareCorner;
        }
    }
}
