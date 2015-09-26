namespace TetrisMain.Figures
{
    using Utility;

    public class ReversedLForm : Figure
    {
        private readonly Point ReversedLFormCorner = new Point(0, 3);

        private readonly bool[,] ReversedLFormForm =
        {
            {false, false, true, false},
            {false, false, true, false},
            {false, true, true, false },
            {false, false, false, false}
        };


        public ReversedLForm() :
            base()
        {
            this.Form = ReversedLFormForm;
            this.UperLeftCorner = ReversedLFormCorner;
        }
    }
}
