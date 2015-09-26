namespace TetrisMain.Figures
{
    using Interfaces;
    using Utility;

    public abstract class Figure : IFigure
    {
        private const char Symbol = '\u2B1B';

        private const int FigureSize = 4;

        public Figure()
            : this(new bool[FigureSize, FigureSize], new Point())
        {                
        }
       
        protected Figure(bool[,] form, Point uperCornerLeft)
        {
            this.Form = form;
            this.UperLeftCorner = uperCornerLeft;
            this.Exist = true;
        }

        public bool Exist { get; set; }

        public Point UperLeftCorner { get; set; }

        public bool[,] Form { get; set; }

        public void Left()
        {
            this.UperLeftCorner = new Point(this.UperLeftCorner.X, this.UperLeftCorner.Y - 1);
        }

        public void Right()
        {
            this.UperLeftCorner = new Point(this.UperLeftCorner.X, this.UperLeftCorner.Y + 1);
        }
               
        public void Down()
        {
            this.UperLeftCorner = new Point(this.UperLeftCorner.X + 1, this.UperLeftCorner.Y);
        }

        public void Up()
        {
            this.UperLeftCorner = new Point(this.UperLeftCorner.X - 1, this.UperLeftCorner.Y);
        }

        public void UnRotate()
        {
            int height = this.Form.GetLength(0);
            int width = this.Form.GetLength(1);
            bool[,] matrix = new bool[height, width];
            int oldMatrixCol = 3;

            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
                {
                    matrix[row, col] = this.Form[col, oldMatrixCol];
                }
                oldMatrixCol--;
            }

            this.Form = matrix;
        }

        public void Rotate()
        {
            int height = this.Form.GetLength(0);
            int width = this.Form.GetLength(1);
            bool[,] matrix = new bool[height, width];           

            for (int row = 0; row < width; row++)
            {
                int oldMatrixRow = height;

                for (int col = 0; col < height; col++)
                {
                    matrix[row, col] = this.Form[oldMatrixRow - 1, row];
                    oldMatrixRow--;
                }
            }

            this.Form = matrix;
        }
    }
}
