using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    static class Bishopcs
    {
        public static List<DataStructure.point> findPossibleMoves(DataStructure.color pieceColor, DataStructure.point possition, int[,] boardMatrix)
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

            try
            {
                int i = possition.i - 1;
                int j = possition.j - 1;
                while (i > -1 && j > -1)
                {
                    p = new DataStructure.point(i, j);
                    if (Validation.IsEmpty(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    else
                    {
                        if (Validation.IsOpponent(p, DataStructure.color.white, boardMatrix))
                        {
                            possiblePossitions.Add(p);
                        }
                        break;
                    }
                    i--;
                    j--;
                }
                i = possition.i - 1;
                j = possition.j + 1;
                while (i > -1 && j < 8)
                {
                    p = new DataStructure.point(i, j);
                    if (Validation.IsEmpty(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    else
                    {
                        if (Validation.IsOpponent(p, DataStructure.color.white, boardMatrix))
                        {
                            possiblePossitions.Add(p);
                        }
                        break;
                    }
                    i--;
                    j++;
                }
                i = possition.i + 1;
                j = possition.j - 1;
                while (i <8 && j > -1)
                {
                    p = new DataStructure.point(i, j);
                    if (Validation.IsEmpty(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    else
                    {
                        if (Validation.IsOpponent(p, DataStructure.color.white, boardMatrix))
                        {
                            possiblePossitions.Add(p);
                        }
                        break;
                    }
                    i++;
                    j--;
                }
                i = possition.i + 1;
                j = possition.j + 1;
                while (i < 8 && j < 8)
                {
                    p = new DataStructure.point(i, j);
                    if (Validation.IsEmpty(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    else
                    {
                        if (Validation.IsOpponent(p, DataStructure.color.white, boardMatrix))
                        {
                            possiblePossitions.Add(p);
                        }
                        break;
                    }
                    i++;
                    j++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return possiblePossitions;
        }

        static List<DataStructure.point> FindMovesBlack(DataStructure.point possition, int[,] boardMatrix)
        {
            List<DataStructure.point> possiblePossitions = new List<DataStructure.point>();

            DataStructure.point p;

            try
            {
                int i = possition.i - 1;
                int j = possition.j - 1;
                while (i > -1 && j > -1)
                {
                    p = new DataStructure.point(i, j);
                    if (Validation.IsEmpty(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    else
                    {
                        if (Validation.IsOpponent(p, DataStructure.color.black, boardMatrix))
                        {
                            possiblePossitions.Add(p);
                        }
                        break;
                    }
                    i--;
                    j--;
                }
                i = possition.i - 1;
                j = possition.j + 1;
                while (i > -1 && j < 8)
                {
                    p = new DataStructure.point(i, j);
                    if (Validation.IsEmpty(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    else
                    {
                        if (Validation.IsOpponent(p, DataStructure.color.black, boardMatrix))
                        {
                            possiblePossitions.Add(p);
                        }
                        break;
                    }
                    i--;
                    j++;
                }
                i = possition.i + 1;
                j = possition.j - 1;
                while (i < 8 && j > -1)
                {
                    p = new DataStructure.point(i, j);
                    if (Validation.IsEmpty(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    else
                    {
                        if (Validation.IsOpponent(p, DataStructure.color.black, boardMatrix))
                        {
                            possiblePossitions.Add(p);
                        }
                        break;
                    }
                    i++;
                    j--;
                }
                i = possition.i + 1;
                j = possition.j + 1;
                while (i < 8 && j < 8)
                {
                    p = new DataStructure.point(i, j);
                    if (Validation.IsEmpty(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                    else
                    {
                        if (Validation.IsOpponent(p, DataStructure.color.black, boardMatrix))
                        {
                            possiblePossitions.Add(p);
                        }
                        break;
                    }
                    i++;
                    j++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return possiblePossitions;
        }
    }
}
