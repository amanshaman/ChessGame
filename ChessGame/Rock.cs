using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Model;

namespace ChessGame
{
    class Rock : IFigureMoves
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
            for (int i = possition.i-1; i > -1; i--)
            {
                p = new DataStructure.Point( i, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            for (int i = possition.i + 1 ; i < 8; i++)
            {
                p = new DataStructure.Point(i, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            for (int j = possition.j - 1; j > -1; j--)
            {
                p = new DataStructure.Point(possition.i, j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            for (int j = possition.j + 1; j < 8; j++)
            {
                p = new DataStructure.Point(possition.i, j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            return possiblePossitions;
        }

        static List<DataStructure.Point> FindMovesBlack(DataStructure.Point possition, int[,] boardMatrix)
        {
            List<DataStructure.Point> possiblePossitions = new List<DataStructure.Point>();

            DataStructure.Point p;
            for (int i = possition.i - 1; i > -1; i--)
            {
                p = new DataStructure.Point(i, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            for (int i = possition.i + 1; i < 8; i++)
            {
                p = new DataStructure.Point(i, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            for (int j = possition.j - 1; j > -1; j--)
            {
                p = new DataStructure.Point(possition.i, j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            for (int j = possition.j + 1; j < 8; j++)
            {
                p = new DataStructure.Point(possition.i, j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }

            return possiblePossitions;
        }



    }
}
