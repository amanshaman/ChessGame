using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    static class Rock
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
            for (int i = possition.i-1; i > -1; i--)
            {
                p = new DataStructure.point( i, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, (int)DataStructure.color.white, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            for (int i = possition.i + 1 ; i < 8; i++)
            {
                p = new DataStructure.point(i, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, (int)DataStructure.color.white, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            for (int j = possition.j - 1; j > -1; j--)
            {
                p = new DataStructure.point(possition.i, j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, (int)DataStructure.color.white, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            for (int j = possition.j + 1; j < 8; j++)
            {
                p = new DataStructure.point(possition.i, j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, (int)DataStructure.color.white, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            return possiblePossitions;
        }

        static List<DataStructure.point> FindMovesBlack(DataStructure.point possition, int[,] boardMatrix)
        {
            List<DataStructure.point> possiblePossitions = new List<DataStructure.point>();

            DataStructure.point p;
            for (int i = possition.i - 1; i > -1; i--)
            {
                p = new DataStructure.point(i, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, (int)DataStructure.color.black, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            for (int i = possition.i + 1; i < 8; i++)
            {
                p = new DataStructure.point(i, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, (int)DataStructure.color.black, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            for (int j = possition.j - 1; j > -1; j--)
            {
                p = new DataStructure.point(possition.i, j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, (int)DataStructure.color.black, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    break;
                }
            }
            for (int j = possition.j + 1; j < 8; j++)
            {
                p = new DataStructure.point(possition.i, j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                else
                {
                    if (Validation.IsOpponent(p, (int)DataStructure.color.black, boardMatrix))
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
