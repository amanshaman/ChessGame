using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    static class Pawn
    {
        static DataStructure.point freebie;

        public static List<DataStructure.point> findPossibleMoves(DataStructure.color pieceColor, DataStructure.point possition, int[,] boardMatrix)
        {
            if (pieceColor == DataStructure.color.white)
            {
                return FindMovesWhite(possition, boardMatrix);
            }
            else return FindMovesBlack(possition, boardMatrix);
        }

        static List<DataStructure.point> FindMovesWhite(DataStructure.point possition, int[,] boardMatrix)
        {
            List<DataStructure.point> possiblePossitions = new List<DataStructure.point>();

            DataStructure.point p;

            //if it is first move of the pawn than check 2 columns
            if (possition.i == 1)
            {//if first is empty than add it and check second
                p = new DataStructure.point(possition.i + 1, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {//if second is empty add it
                    possiblePossitions.Add(p);
                    p = new DataStructure.point(possition.i + 2, possition.j);
                    if (Validation.IsEmpty(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                }
            }
            else
            {
                p = new DataStructure.point(possition.i + 1, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
            }
            //check for corner pawns. if it is first or last the moves won`t be add together 
            //with occupied possitions with friendly characters.
            p = new DataStructure.point(possition.i + 1, possition.j - 1);
            if (Validation.IsValidPosition(p))
            {
                if (Validation.IsOpponent(p, DataStructure.color.white, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                if (freebie.i == possition.i && freebie.j == possition.j - 1)
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i + 1, possition.j + 1);
            if (Validation.IsValidPosition(p))
            {
                if (Validation.IsOpponent(p, DataStructure.color.white, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                if (freebie.i == possition.i && freebie.j == possition.j + 1)
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

            //if it is first move of the pawn than check 2 columns
            if (possition.i == 6)
            {//if first is empty than add it and check second
                p = new DataStructure.point(possition.i - 1, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {//if second is empty add it
                    possiblePossitions.Add(p);
                    p = new DataStructure.point(possition.i - 2, possition.j);
                    if (Validation.IsEmpty(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                }
            }
            else
            {
                p = new DataStructure.point(possition.i - 1, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
            }
            //check for corner pawns. if it is first or last the moves won`t be add together 
            //with occupied possitions with friendly characters.
            p = new DataStructure.point(possition.i - 1, possition.j - 1);
            if (Validation.IsValidPosition(p))
            {
                if (Validation.IsOpponent(p, DataStructure.color.black, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                if (freebie.i == possition.i && freebie.j == possition.j - 1)
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.point(possition.i - 1, possition.j + 1);
            if (Validation.IsValidPosition(p))
            {
                if (Validation.IsOpponent(p, DataStructure.color.black, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                if (freebie.i == possition.i && freebie.j == possition.j + 1)
                {
                    possiblePossitions.Add(p);
                }
            }
            return possiblePossitions;
        }

        public static void EndofTheMove(DataStructure.point possition, int[,] boardMatrix)
        {
            //TODO UX,UI etc
            if (possition.i == 0)
            {
                boardMatrix[possition.i, possition.j] = (int)DataStructure.figures.black_queen;
            }
            else if(possition.i == 7)
            {
                boardMatrix[possition.i, possition.j] = (int)DataStructure.figures.white_queen;
            }
            
            freebie.i = -2;
            freebie.j = -2;
        }

        public static void WasDoubleJump(DataStructure.point prev, DataStructure.point current)
        {
            if (Math.Abs(prev.i - current.i) > 1)
            {
                freebie = current;
            }
        }

        public static void KickingOutFreebie(DataStructure.point prev, DataStructure.point current, int[,] boardMatrix, int color)
        {
           if (current.j == freebie.j && prev.j != current.j)
           {
                if (current.i != freebie.i)
                {
                    boardMatrix[freebie.i, freebie.j] = (int)DataStructure.figures.empty;
                }
               
           }
        }
    }
}
