namespace TetrisMain.Utility
{
    public class Point
    {
        public Point(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;        
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
