namespace TetrisMain.Figures
{
    using Utility;

    public class ZForm : Figure
    {
        private readonly Point ZFormCorner = new Point(0, 3);

        private readonly bool[,] ZFormForm =
        {
            {false, true, false, false},
            {false, true, true, false},
            {false, false, true, false },
            {false, false, false, false}
        };


        public ZForm() :
            base()
        {
            this.Form = ZFormForm;
            this.UperLeftCorner = ZFormCorner;
        }
    }
}