using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    static class Knight
    {
        public static List<DataStructure.point> FindPossibleMoves(DataStructure.color pieceColor, DataStructure.point possition, int[,] boardMatrix)
        {
            if (DataStructure.color.white == pieceColor)
            {
                return FindMovesWhite(possition, boardMatrix);
            }
            else return FindMovesBlack(possition, boardMatrix);
        }

        static List<DataStructure.point> FindMovesWhite(DataStructure.point possition, int[,] boardMatrix)
        {
            List<DataStructure.point> possiblePossitions = new List<DataStructure.point>();

            DataStructure.point p;

            p = new DataStructure.point(possition.i+2, possition.j-1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i+1, possition.j-2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i-1, possition.j-2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i-2, possition.j-1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i-2, possition.j+1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i-1, possition.j+2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i+1, possition.j+2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i+2, possition.j+1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            return possiblePossitions;
        }

        static List<DataStructure.point> FindMovesBlack(DataStructure.point possition, int[,] boardMatrix)
        {
            List<DataStructure.point> possiblePossitions = new List<DataStructure.point>();

            DataStructure.point p;

            p = new DataStructure.point(possition.i + 2, possition.j - 1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i + 1, possition.j - 2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i - 1, possition.j - 2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i - 2, possition.j - 1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i - 2, possition.j + 1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i - 1, possition.j + 2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i + 1, possition.j + 2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i + 2, possition.j + 1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.color.black))
                {
                    possiblePossitions.Add(p);
                }
            }

            return possiblePossitions;
        }

        static bool KnightCanMove(DataStructure.point possition, int[,] boardMatrix, DataStructure.color color)
        {
            if (Validation.IsEmpty(possition, boardMatrix))
            {
                return true;
            }
            else
            {
                if (Validation.IsOpponent(possition, (int)color, boardMatrix))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
