using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Model;

namespace ChessGame
{
    class Knight : IFigureMoves
    {
        public List<DataStructure.Point> FindPossibleMoves(DataStructure.Point possition, int[,] boardMatrix)
        {
            if (DataStructure.Color.white == EnvironmentVariables.Player)
            {
                return FindMovesWhite(possition, boardMatrix);
            }
            else return FindMovesBlack(possition, boardMatrix);
        }

        static List<DataStructure.Point> FindMovesWhite(DataStructure.Point possition, int[,] boardMatrix)
        {
            List<DataStructure.Point> possiblePossitions = new List<DataStructure.Point>();

            DataStructure.Point p;

            p = new DataStructure.Point(possition.i+2, possition.j-1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i+1, possition.j-2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i-1, possition.j-2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i-2, possition.j-1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i-2, possition.j+1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i-1, possition.j+2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i+1, possition.j+2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i+2, possition.j+1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.white))
                {
                    possiblePossitions.Add(p);
                }
            }
            return possiblePossitions;
        }

        static List<DataStructure.Point> FindMovesBlack(DataStructure.Point possition, int[,] boardMatrix)
        {
            List<DataStructure.Point> possiblePossitions = new List<DataStructure.Point>();

            DataStructure.Point p;

            p = new DataStructure.Point(possition.i + 2, possition.j - 1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i + 1, possition.j - 2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i - 1, possition.j - 2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i - 2, possition.j - 1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i - 2, possition.j + 1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i - 1, possition.j + 2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i + 1, possition.j + 2);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.black))
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i + 2, possition.j + 1);
            if (Validation.IsValidPosition(p))
            {
                if (KnightCanMove(p, boardMatrix, DataStructure.Color.black))
                {
                    possiblePossitions.Add(p);
                }
            }

            return possiblePossitions;
        }

        static bool KnightCanMove(DataStructure.Point possition, int[,] boardMatrix, DataStructure.Color color)
        {
            if (Validation.IsEmpty(possition, boardMatrix))
            {
                return true;
            }
            else
            {
                if (Validation.IsOpponent(possition, boardMatrix))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
