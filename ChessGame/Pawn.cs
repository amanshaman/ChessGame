using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Model;

namespace ChessGame
{
    public class Pawn :IFigureMoves
    {
        static DataStructure.Point EnPassant;

        public List<DataStructure.Point> FindPossibleMoves(DataStructure.Point possition, int[,] boardMatrix)
        {
            if (EnvironmentVariables.Player == DataStructure.Color.white)
            {
                return FindMovesWhite(possition, boardMatrix);
            }
            else return FindMovesBlack(possition, boardMatrix);
        }

        List<DataStructure.Point> FindMovesWhite(DataStructure.Point possition, int[,] boardMatrix)
        {
            List<DataStructure.Point> possiblePossitions = new List<DataStructure.Point>();

            DataStructure.Point p;

            //if it is first move of the pawn than check 2 columns
            if (possition.i == 1)
            {//if first is empty than add it and check second
                p = new DataStructure.Point(possition.i + 1, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {//if second is empty add it
                    possiblePossitions.Add(p);
                    p = new DataStructure.Point(possition.i + 2, possition.j);
                    if (Validation.IsEmpty(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                }
            }
            else
            {
                p = new DataStructure.Point(possition.i + 1, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
            }
            //check for corner pawns. if it is first or last the moves won`t be add together 
            //with occupied possitions with friendly characters.
            p = new DataStructure.Point(possition.i + 1, possition.j - 1);
            if (Validation.IsValidPosition(p))
            {
                if (Validation.IsOpponent(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                if (EnPassant.i == possition.i && EnPassant.j == possition.j - 1)
                {
                    possiblePossitions.Add(p);
                }
                if (EnPassant.i == possition.i - 1 && EnPassant.j == possition.j - 1)
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i + 1, possition.j + 1);
            if (Validation.IsValidPosition(p))
            {
                if (Validation.IsOpponent(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                if (EnPassant.i == possition.i && EnPassant.j == possition.j + 1)
                {
                    possiblePossitions.Add(p);
                }
                if (EnPassant.i == possition.i - 1 && EnPassant.j == possition.j + 1)
                {
                    possiblePossitions.Add(p);
                }
            }

            return possiblePossitions;
        }

        List<DataStructure.Point> FindMovesBlack(DataStructure.Point possition, int[,] boardMatrix)
        {
            List<DataStructure.Point> possiblePossitions = new List<DataStructure.Point>();

            DataStructure.Point p;

            //if it is first move of the pawn than check 2 columns
            if (possition.i == 6)
            {//if first is empty than add it and check second
                p = new DataStructure.Point(possition.i - 1, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {//if second is empty add it
                    possiblePossitions.Add(p);
                    p = new DataStructure.Point(possition.i - 2, possition.j);
                    if (Validation.IsEmpty(p, boardMatrix))
                    {
                        possiblePossitions.Add(p);
                    }
                }
            }
            else
            {
                p = new DataStructure.Point(possition.i - 1, possition.j);
                if (Validation.IsEmpty(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
            }
            //check for corner pawns. if it is first or last the moves won`t be add together 
            //with occupied possitions with friendly characters.
            p = new DataStructure.Point(possition.i - 1, possition.j - 1);
            if (Validation.IsValidPosition(p))
            {
                if (Validation.IsOpponent(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                if (EnPassant.i == possition.i && EnPassant.j == possition.j - 1)
                {
                    possiblePossitions.Add(p);
                }
                if (EnPassant.i == possition.i + 1 && EnPassant.j == possition.j - 1)
                {
                    possiblePossitions.Add(p);
                }
            }
            p = new DataStructure.Point(possition.i - 1, possition.j + 1);
            if (Validation.IsValidPosition(p))
            {
                if (Validation.IsOpponent(p, boardMatrix))
                {
                    possiblePossitions.Add(p);
                }
                if (EnPassant.i == possition.i && EnPassant.j == possition.j + 1)
                {
                    possiblePossitions.Add(p);
                }
                if (EnPassant.i == possition.i + 1 && EnPassant.j == possition.j + 1)
                {
                    possiblePossitions.Add(p);
                }
            }
            return possiblePossitions;
        }

        /// <summary>
        /// Check if pawn landed on the last row of the column. If yes the promote to queen (for now)
        /// </summary>
        /// <param name="possition"></param>
        /// <param name="boardMatrix"></param>
        public static void EndofTheColumn(DataStructure.Point possition, int[,] boardMatrix)
        {
            //TODO UX,UI etc
            if (possition.i == 0)
            {
                boardMatrix[possition.i, possition.j] = (int)DataStructure.Figures.black_queen;
            }
            else if(possition.i == 7)
            {
                boardMatrix[possition.i, possition.j] = (int)DataStructure.Figures.white_queen;
            }

            EnPassant.i = -2;
            EnPassant.j = -2;
        }

        public static void WasDoubleJump(DataStructure.Point prev, DataStructure.Point current)
        {
            if (Math.Abs(prev.i - current.i) > 1)
            {
                EnPassant = current;
            }
        }

        public static void KickingOutEnPassant(DataStructure.Point prev, DataStructure.Point current, int[,] boardMatrix)
        {
           if (current.j == EnPassant.j && prev.j != current.j)
           {
                if (current.i != EnPassant.i)
                {
                    boardMatrix[EnPassant.i, EnPassant.j] = (int)DataStructure.Figures.empty;
                }               
           }
        }
    }
}
