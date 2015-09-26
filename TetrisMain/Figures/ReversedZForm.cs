namespace TetrisMain.Figures
{
    using Utility;

    public class ReversedZForm : Figure
    {
        private readonly Point ReversedZFormCorner = new Point(0, 3);

        private readonly bool[,] ReversedZFormForm =
        {
            {false, false, true, false},
            {false, true, true, false},
            {false, true, false, false },
            {false, false, false, false}
        };


        public ReversedZForm() :
            base()
        {
            this.Form = ReversedZFormForm;
            this.UperLeftCorner = ReversedZFormCorner;
        }
    }
}