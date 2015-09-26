namespace TetrisMain.Figures
{
    using Utility;

    public class TForm : Figure
    {
        private readonly Point TFormCorner = new Point(0, 3);

        private readonly bool[,] TFormForm =
        {
            {false, true, false, false},
            {false, true, true, false},
            {false, true, false, false },
            {false, false, false, false}
        };


        public TForm() :
            base()
        {
            this.Form = TFormForm;
            this.UperLeftCorner = TFormCorner;
        }
    }
}