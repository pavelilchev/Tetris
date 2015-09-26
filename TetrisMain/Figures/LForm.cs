namespace TetrisMain.Figures
{
    using Utility;
    
    public class LForm : Figure
    {
        private readonly Point LFormCorner = new Point(0, 3);

        private readonly bool[,] LFormForm =
        {
            {false, true, false, false},
            {false, true, false, false},
            {false, true, true, false },
            {false, false, false, false}
        };


        public LForm() : 
            base()
        {
            this.Form = LFormForm;
            this.UperLeftCorner = LFormCorner;
        }
    }
}

