using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisMain.Utility;

namespace TetrisMain.Interfaces
{
    public interface IFigure
    {
        Point UperLeftCorner { get; set; }

        bool[,] Form { get; set; }

        bool Exist { get; set; }

        void Left();

        void Right();

        void Down();

        void Rotate();

        void Up();
    }
}
