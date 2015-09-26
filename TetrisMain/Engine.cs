namespace TetrisMain
{
    using Figures;
    using System;
    using System.Threading;

    public class Engine
    {
        Board board = new Board();
        Figure currentFigure = GenerateFigure();
        Figure nextFigure = GenerateFigure();
        bool isRuning = true;
        int score = 0;
        int level = 1;
        int sleepTime = 400;

        public void Run()
        {
            Print();

            while (isRuning)
            {
                int removedLines = 0;

                int newLevel = UpdateLevel(score);
                if (newLevel > level)
                {
                    sleepTime -= 20;
                }

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.Spacebar:
                            ConsoleKeyInfo pausePressed = Console.ReadKey();
                            if (pausePressed.Key == ConsoleKey.Spacebar)
                            {
                                continue;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            currentFigure.Left();
                            if (CheckCollision(board, currentFigure))
                            {
                                currentFigure.Right();
                                continue;
                            }
                            Print();
                            break;
                        case ConsoleKey.RightArrow:
                            currentFigure.Right();
                            if (CheckCollision(board, currentFigure))
                            {
                                currentFigure.Left();
                                continue;
                            }
                            Print();
                            break;
                        case ConsoleKey.UpArrow:
                            currentFigure.Rotate();
                            if (CheckCollision(board, currentFigure))
                            {
                                currentFigure.UnRotate();
                            }
                            Print();
                            break;
                        case ConsoleKey.DownArrow:
                            currentFigure.Down();
                            if (CheckCollision(board, currentFigure))
                            {
                                currentFigure.Up();
                                AddFigureToBoard(board, currentFigure);
                                removedLines = RemoveLines(board);
                                score += UpdateScore(removedLines);
                                Print();

                                currentFigure = nextFigure;
                                nextFigure = GenerateFigure();
                                if (CheckCollision(board, currentFigure))
                                {
                                    currentFigure.Exist = false;
                                    isRuning = false;
                                }
                                continue;

                            }
                            Print();
                            break;
                    }
                }

                Thread.Sleep(sleepTime);
                currentFigure.Down();
                if (CheckCollision(board, currentFigure))
                {
                    currentFigure.Up();
                    AddFigureToBoard(board, currentFigure);
                    removedLines = RemoveLines(board);
                    score += UpdateScore(removedLines);
                    Print();

                    currentFigure = nextFigure;
                    nextFigure = GenerateFigure();

                    if (CheckCollision(board, currentFigure))
                    {
                        isRuning = false;
                    }

                    continue;
                }

                Print();
            }

            Console.SetCursorPosition(1, 4);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("GAME OVER");
            Console.SetCursorPosition(1, 6);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("press space");
           
        }

        private static int UpdateLevel(int score)
        {
            int level = 0;

            if (score <= 100)
            {
                level = 1;
            }
            else if (score > 100 && score <= 200)
            {
                level = 2;
            }
            else if (score > 200 && score <= 300)
            {
                level = 3;
            }
            else if (score > 300 && score <= 400)
            {
                level = 4;
            }
            else if (score > 400 && score <= 500)
            {
                level = 5;
            }
            else if (score > 500 && score <= 600)
            {
                level = 6;
            }
            else if (score > 600 && score <= 700)
            {
                level = 7;
            }
            else if (score > 700 && score <= 800)
            {
                level = 8;
            }
            else if (score > 800 && score <= 900)
            {
                level = 9;
            }
            else if (score > 900)
            {
                level = 10;
            }

            return level;
        }

        private static int UpdateScore(int removedLines)
        {
            int score = 0;

            switch (removedLines)
            {
                case 1: score += 1; break;
                case 2: score += 3; break;
                case 3: score += 7; break;
                case 4: score += 15; break;
            }


            return score;
        }

        private static void AddFigureToBoard(Board board, Figure figure)
        {
            int startRow = figure.UperLeftCorner.X;

            for (int i = 0; i < 4; i++)
            {
                int startCol = figure.UperLeftCorner.Y;
                for (int j = 0; j < 4; j++)
                {
                    if (figure.Form[i, j])
                    {
                        board.Form[startRow, startCol] = true;
                    }
                    startCol++;
                }
                startRow++;
            }


        }

        private static bool CheckCollision(Board board, Figure figure)
        {
            bool haveCollision = false;
            int startRow = figure.UperLeftCorner.X;

            for (int i = 0; i < 4; i++)
            {
                int startCol = figure.UperLeftCorner.Y;
                for (int j = 0; j < 4; j++)
                {
                    if (figure.Form[i, j])
                    {
                        if (startRow < 0 ||
                        startRow > 19 ||
                        startCol < 0 ||
                        startCol > 9 ||
                        board.Form[startRow, startCol]
                        )
                        {
                            haveCollision = true;
                            return haveCollision;
                        }
                    }
                    startCol++;
                }
                startRow++;
            }


            return haveCollision;
        }

        private int RemoveLines(Board board)
        {
            int countRemovedLines = 0;

            for (int i = 19; i >= 0; i--)
            {
                bool haveLine = true;

                for (int j = 0; j < 10; j++)
                {
                    if (!board.Form[i, j])
                    {
                        haveLine = false;
                    }
                }

                if (haveLine)
                {
                    countRemovedLines++;

                    for (int j = i; j > 0; j--)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            board.Form[j, l] = board.Form[j - 1, l];
                        }
                    }

                    i++;
                }
            }

            return countRemovedLines;
        }

        private void Print()
        {
            Console.Clear();
            PrintBoard(board);
            PrintFigure(currentFigure);
            PrintNextFigure(nextFigure);
            PrintScore(score);
            PrintLevel(level);
        }

        private static void PrintLevel(int level)
        {
            Console.SetCursorPosition(14, 12);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Level");
            Console.SetCursorPosition(14, 14);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(level);
        }

        private static void PrintScore(int score)
        {
            Console.SetCursorPosition(14, 7);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Score");
            Console.SetCursorPosition(14, 9);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(score);

        }

        private static void PrintNextFigure(Figure nextFigure)
        {
            int x = 2;
            char symbol = '\u2B1B';

            for (int i = 0; i < 4; i++)
            {
                int y = 14;
                for (int j = 0; j < 4; j++)
                {
                    if (nextFigure.Form[i, j])
                    {
                        Console.SetCursorPosition(y, x);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(symbol);
                    }
                    y++;
                }
                x++;
            }

            Console.SetCursorPosition(14, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("NEXT");
        }



        private static void PrintFigure(Figure figure)
        {
            int x = figure.UperLeftCorner.X;
            char symbol = '\u2B1B';

            for (int i = 0; i < 4; i++)
            {
                int y = figure.UperLeftCorner.Y + 1;
                for (int j = 0; j < 4; j++)
                {
                    if (figure.Form[i, j])
                    {
                        Console.SetCursorPosition(y, x);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(symbol);
                    }
                    y++;
                }
                x++;
            }
        }

        private static void ClearFigure(Figure figure)
        {
            int x = figure.UperLeftCorner.X;
            char symbol = ' ';

            for (int i = 0; i < 4; i++)
            {
                int y = figure.UperLeftCorner.Y + 1;
                for (int j = 0; j < 4; j++)
                {
                    if (figure.Form[i, j])
                    {
                        Console.SetCursorPosition(y, x);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(symbol);
                    }
                    y++;
                }
                x++;
            }
        }

        private static void PrintBoard(Board board)
        {
            int rows = board.Form.GetLength(0);
            int cols = board.Form.GetLength(1);
            char symbol = '\u2B1B';

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board.Form[i, j])
                    {
                        Console.SetCursorPosition(j + 1, i);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(symbol);
                    }

                    if (j == 0)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write('*');
                    }

                    if (j == 9)
                    {
                        Console.SetCursorPosition(j + 2, i);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write('*');
                    }

                    if (i == 19)
                    {
                        Console.SetCursorPosition(j, i + 1);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write('*');
                    }
                }
            }

            Console.SetCursorPosition(10, 20);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write('*');
            Console.SetCursorPosition(11, 20);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write('*');
        }

        private static void ClearBoard(Board board)
        {
            int rows = board.Form.GetLength(0);
            int cols = board.Form.GetLength(1);
            char symbol = ' ';

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board.Form[i, j])
                    {
                        Console.SetCursorPosition(j + 1, i);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(symbol);
                    }
                }
            }
        }

        private static Figure GenerateFigure()
        {
            Random rnd = new Random();
            Figure figure = null;
            int figureNumber = rnd.Next(1, 8);

            switch (figureNumber)
            {
                case 1:
                    figure = new LForm();
                    return figure;
                case 2:
                    figure = new Line();
                    return figure;
                case 3:
                    figure = new ReversedLForm();
                    return figure;
                case 4:
                    figure = new ReversedZForm();
                    return figure;
                case 5:
                    figure = new Square();
                    return figure;
                case 6:
                    figure = new TForm();
                    return figure;
                case 7:
                    figure = new ZForm();
                    return figure;
                default:
                    return figure;
            }
        }
    }
}
