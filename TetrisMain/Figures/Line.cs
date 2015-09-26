namespace TetrisMain.Figures
{
    using global::TetrisMain.Utility;

    public class Line : Figure
    {
        private readonly Point LineCorner = new Point(-2, 3);

        private readonly bool[,] LineForm =
        {
            {false, false, false, false},
            {false, false, false, false},
            {true, true, true, true },
            {false, false, false, false}
        };

        
        public Line() : 
            base()
        {
            this.Form = LineForm;
            this.UperLeftCorner = LineCorner;
        }
    }
}
