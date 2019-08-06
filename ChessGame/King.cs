using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    static class King
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
                for (int i = possition.i - 1; i <= possition.i + 1; i++)
                {
                    for (int j = possition.j - 1; j <= possition.j + 1; j++)
                    {
                        if (possition.i == i && possition.j == j)
                        {
                            //do nothing
                        }
                        else
                        {
                            p = new DataStructure.point(i, j);
                            if (Validation.IsValidPosition(p))
                            {
                                if (KingCanMove(p, boardMatrix, DataStructure.color.white))
                                {
                                    possiblePossitions.Add(p);
                                }
                            }                            
                        }
                    }
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
                for (int i = possition.i - 1; i <= possition.i + 1; i++)
                {
                    for (int j = possition.j - 1; j <= possition.j + 1; j++)
                    {
                        if (possition.i == i && possition.j == j)
                        {
                            //do nothing
                        }
                        else
                        {
                            p = new DataStructure.point(i, j);
                            if (Validation.IsValidPosition(p))
                            {
                                if (KingCanMove(p, boardMatrix, DataStructure.color.black))
                                {
                                    possiblePossitions.Add(p);
                                }
                            }                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return possiblePossitions;
        }

        static bool KingCanMove(DataStructure.point possition, int[,] boardMatrix, DataStructure.color color)
        {
            if (Validation.IsEmpty(possition, boardMatrix))
            {
                return true;
            }
            else
            {
                if (Validation.IsOpponent(possition, color, boardMatrix))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
