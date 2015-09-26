namespace TetrisMain
{
    using System;
    using System.Text;

    public class TetrisMain
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            Console.SetWindowSize(25, 22);
            Console.SetBufferSize(25, 22);

            Engine eng = new Engine();

            while (true)
            {
                eng.Run();
                Console.ReadKey();
                Console.OutputEncoding = Encoding.Unicode;
                Console.CursorVisible = false;
                Console.SetWindowSize(25, 22);
                Console.SetBufferSize(25, 22);

                eng = new Engine();
            }
        }
    }
}
