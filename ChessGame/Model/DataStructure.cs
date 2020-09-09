using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    static class DataStructure
    {
        public struct Point
        {
            public int i;
            public int j;

            public Point(int i, int j)
            {
                this.i = i;
                this.j = j;
            }
        }

        public enum Color
        {
            black,
            white,
            empty
        }

        public enum Figures
        {
            empty = 0,
            white_pawn = 1,
            black_pawn = 2,
            white_rock = 3,
            black_rock = 4,
            white_knight = 5,
            black_knight = 6,
            white_bishop = 7,
            black_bishop = 8,
            white_queen = 9,
            black_queen = 10,
            white_king = 11,
            black_king = 12,
        };
    }
}
