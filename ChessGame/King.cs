﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    static class King
    {
        private static DataStructure.point whiteKing;
        private static DataStructure.point blackKing;

        internal static DataStructure.point WhiteKing { get => whiteKing; set => whiteKing = value; }
        internal static DataStructure.point BlackKing { get => blackKing; set => blackKing = value; }



        public static List<DataStructure.point> FindPossibleMoves(DataStructure.color pieceColor, DataStructure.point possition, int[,] boardMatrix)
        {
            return FindMoves(possition, boardMatrix);
        }

        static List<DataStructure.point> FindMoves(DataStructure.point possition, int[,] boardMatrix)
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
                                if (Validation.IsEmpty(p, boardMatrix))
                                {
                                    //if (!CheckKing(p, boardMatrix, boardMatrix[possition.i, possition.j] % 2))
                                    //{
                                    //    possiblePossitions.Add(p);
                                    //}
                                    //if (!CheckPawn(p,boardMatrix, boardMatrix[possition.i, possition.j]))
                                    //{
                                    //    possiblePossitions.Add(p);
                                    //}
                                }
                                else if (Validation.IsOpponent(p, possition, boardMatrix))
                                {
                                    //if (!CheckKing(p, boardMatrix, boardMatrix[possition.i, possition.j] % 2))
                                    //{
                                    //    possiblePossitions.Add(p);
                                    //}
                                    //if (!CheckPawn(p, boardMatrix, boardMatrix[possition.i, possition.j]))
                                    //{
                                    //    possiblePossitions.Add(p);
                                    //}
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

        public static bool IsItCheck(DataStructure.point possition , int[,] boardMatrix, DataStructure.color pieceColor)
        {

            return CheckKing(possition, boardMatrix, (int)pieceColor);
        }

        private static bool CheckHorizontal(DataStructure.point possition, int[,] boardMatrix, int color)
        {
            //check for rock / queen to the left
            DataStructure.point p;
            for (int i = possition.i-1; i > -1; i--)
            {
                p.i = i;
                p.j = possition.j;
                if (!Validation.IsEmpty(p,boardMatrix))
                {
                    if (Validation.IsOpponent(p, possition, boardMatrix))
                    {
                        switch (boardMatrix[p.i, p.j])
                        {
                            case (int)DataStructure.figures.white_rock:
                                return true;
                            case (int)DataStructure.figures.white_queen:
                                return true;
                            case (int)DataStructure.figures.black_rock:
                                return true;
                            case (int)DataStructure.figures.black_queen:
                                return true;
                            default:
                                break;
                        }                        
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //check for rock / queen to the right
            for (int i = possition.i + 1; i < 8; i++)
            {
                p.i = i;
                p.j = possition.j;
                if (!Validation.IsEmpty(p, boardMatrix))
                {
                    if (Validation.IsOpponent(p, possition, boardMatrix))
                    {
                        switch (boardMatrix[p.i, p.j])
                        {
                            case (int)DataStructure.figures.white_rock:
                                return true;
                            case (int)DataStructure.figures.white_queen:
                                return true;
                            case (int)DataStructure.figures.black_rock:
                                return true;
                            case (int)DataStructure.figures.black_queen:
                                return true;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return false;
        }

        private static bool CheckVertical(DataStructure.point possition, int[,] boardMatrix, int color)
        {
            //check for rock / queen to the left
            DataStructure.point p;
            for (int j = possition.j - 1; j > -1; j--)
            {
                p.i = possition.i;
                p.j = j;
                if (!Validation.IsEmpty(p, boardMatrix))
                {
                    if (Validation.IsOpponent(p, possition, boardMatrix))
                    {
                        switch (boardMatrix[p.i, p.j])
                        {
                            case (int)DataStructure.figures.white_rock:
                                return true;
                            case (int)DataStructure.figures.white_queen:
                                return true;
                            case (int)DataStructure.figures.black_rock:
                                return true;
                            case (int)DataStructure.figures.black_queen:
                                return true;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //check for rock / queen to the right
            for (int j = possition.i + 1; j < 8; j++)
            {
                p.i = possition.i;
                p.j = j;
                if (!Validation.IsEmpty(p, boardMatrix))
                {
                    if (Validation.IsOpponent(p, possition, boardMatrix))
                    {
                        switch (boardMatrix[p.i, p.j])
                        {
                            case (int)DataStructure.figures.white_rock:
                                return true;
                            case (int)DataStructure.figures.white_queen:
                                return true;
                            case (int)DataStructure.figures.black_rock:
                                return true;
                            case (int)DataStructure.figures.black_queen:
                                return true;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return false;
        }

        private static bool CheckDiagonal(DataStructure.point possition, int[,] boardMatrix, int color)
        {
            try
            {
                DataStructure.point p;
                //up , left
                int i = possition.i - 1;
                int j = possition.j - 1;
                while (i > -1 && j > -1)
                {
                    p = new DataStructure.point(i, j);
                    if (!Validation.IsEmpty(p, boardMatrix))
                    {
                        if (Validation.IsOpponent(p, possition, boardMatrix))
                        {
                            switch (boardMatrix[p.i, p.j])
                            {
                                case (int)DataStructure.figures.white_bishop:
                                    return true;
                                case (int)DataStructure.figures.white_queen:
                                    return true;
                                case (int)DataStructure.figures.black_bishop:
                                    return true;
                                case (int)DataStructure.figures.black_queen:
                                    return true;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }                    
                    i--;
                    j--;
                }
                //up, right
                i = possition.i - 1;
                j = possition.j + 1;
                while (i > -1 && j < 8)
                {
                    p = new DataStructure.point(i, j);
                    if (!Validation.IsEmpty(p, boardMatrix))
                    {
                        if (Validation.IsOpponent(p, possition, boardMatrix))
                        {
                            switch (boardMatrix[p.i, p.j])
                            {
                                case (int)DataStructure.figures.white_bishop:
                                    return true;
                                case (int)DataStructure.figures.white_queen:
                                    return true;
                                case (int)DataStructure.figures.black_bishop:
                                    return true;
                                case (int)DataStructure.figures.black_queen:
                                    return true;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    i--;
                    j++;
                }
                //down, left
                i = possition.i + 1;
                j = possition.j - 1;
                while (i < 8 && j > -1)
                {
                    p = new DataStructure.point(i, j);
                    if (!Validation.IsEmpty(p, boardMatrix))
                    {
                        if (Validation.IsOpponent(p, possition, boardMatrix))
                        {
                            switch (boardMatrix[p.i, p.j])
                            {
                                case (int)DataStructure.figures.white_bishop:
                                    return true;
                                case (int)DataStructure.figures.white_queen:
                                    return true;
                                case (int)DataStructure.figures.black_bishop:
                                    return true;
                                case (int)DataStructure.figures.black_queen:
                                    return true;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    i++;
                    j--;
                }
                //down, right
                i = possition.i + 1;
                j = possition.j + 1;
                while (i < 8 && j < 8)
                {
                    p = new DataStructure.point(i, j);
                    if (!Validation.IsEmpty(p, boardMatrix))
                    {
                        if (Validation.IsOpponent(p, possition, boardMatrix))
                        {
                            switch (boardMatrix[p.i, p.j])
                            {
                                case (int)DataStructure.figures.white_bishop:
                                    return true;
                                case (int)DataStructure.figures.white_queen:
                                    return true;
                                case (int)DataStructure.figures.black_bishop:
                                    return true;
                                case (int)DataStructure.figures.black_queen:
                                    return true;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    i++;
                    j++;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        private static bool CheckKnight(DataStructure.point possition, int[,] boardMatrix, int color)
        {
            try
            {
                DataStructure.point p;

                p = new DataStructure.point(possition.i + 2, possition.j - 1);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }                
                p = new DataStructure.point(possition.i + 1, possition.j - 2);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }
                p = new DataStructure.point(possition.i - 1, possition.j - 2);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }
                p = new DataStructure.point(possition.i - 2, possition.j - 1);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }
                p = new DataStructure.point(possition.i - 2, possition.j + 1);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }
                p = new DataStructure.point(possition.i - 1, possition.j + 2);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }
                p = new DataStructure.point(possition.i + 1, possition.j + 2);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }
                p = new DataStructure.point(possition.i + 2, possition.j + 1);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        /// <summary>
        /// Additional method for private static bool CheckKnight(DataStructure.point possition, int[,] boardMatrix)
        /// </summary>
        /// <param name="enemyPossition"></param>
        /// <param name="allyPossition"></param>
        /// <param name="boardMatrix"></param>
        /// <returns></returns>
        private static bool HelpCheckKnight(DataStructure.point enemyPossition, DataStructure.point allyPossition ,int[,] boardMatrix)
        {
            if (Validation.IsValidPosition(enemyPossition))
            {
                if (Validation.IsOpponent(allyPossition, enemyPossition, boardMatrix))
                {
                    switch (boardMatrix[enemyPossition.i, enemyPossition.j])
                    {
                        case (int)DataStructure.figures.white_knight:
                            return true;
                        case (int)DataStructure.figures.black_knight:
                            return true;
                        default:
                            break;
                    }
                }
            }
            return false;
        }

        private static bool CheckPawn(DataStructure.point possition, int[,] boardMatrix, int color)
        {
            try
            {
                DataStructure.point p;

                if (color == (int)DataStructure.figures.white_king)
                {
                    p = new DataStructure.point(possition.i + 1, possition.j - 1);
                    if (Validation.IsValidPosition(p))
                    {
                        if (Validation.IsOpponent(p, (int)DataStructure.color.white, boardMatrix))
                        {
                            if (boardMatrix[p.i,p.j] == (int)DataStructure.figures.black_pawn)
                            {
                                return true;
                            }
                        }
                    }
                    p = new DataStructure.point(possition.i + 1, possition.j + 1);
                    if (Validation.IsValidPosition(p))
                    {
                        if (Validation.IsOpponent(p, (int)DataStructure.color.white, boardMatrix))
                        {
                            if (boardMatrix[p.i, p.j] == (int)DataStructure.figures.black_pawn)
                            {
                                return true;
                            }
                        }
                    }
                }
                else if (color == (int)DataStructure.figures.black_king)
                {
                    p = new DataStructure.point(possition.i - 1, possition.j - 1);
                    if (Validation.IsValidPosition(p))
                    {
                        if (Validation.IsOpponent(p, (int)DataStructure.color.black, boardMatrix))
                        {
                            if (boardMatrix[p.i, p.j] == (int)DataStructure.figures.white_pawn)
                            {
                                return true;
                            }
                        }
                    }
                    p = new DataStructure.point(possition.i - 1, possition.j + 1);
                    if (Validation.IsValidPosition(p))
                    {
                        if (Validation.IsOpponent(p, (int)DataStructure.color.black, boardMatrix))
                        {
                            if (boardMatrix[p.i, p.j] == (int)DataStructure.figures.white_pawn)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        private static bool CheckKing(DataStructure.point possition, int[,] boardMatrix, int color)
        {
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
                                if (boardMatrix[p.i, p.j] != 0)
                                {
                                    if (boardMatrix[p.i, p.j] % 2 != color)
                                    {
                                        switch (boardMatrix[p.i, p.j])
                                        {
                                            case (int)DataStructure.figures.white_king:
                                                return true;
                                            case (int)DataStructure.figures.black_king:
                                                return true;
                                            default:
                                                break;
                                        }
                                    }                                    
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

            return false;
        }


        

        

        
    }
}
