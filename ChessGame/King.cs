using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class King : IFigureMoves
    {
        private static DataStructure.Point whiteKing;
        private static DataStructure.Point blackKing;

        internal static DataStructure.Point WhiteKing { get => whiteKing; set => whiteKing = value; }
        internal static DataStructure.Point BlackKing { get => blackKing; set => blackKing = value; }



        public List<DataStructure.Point> FindPossibleMoves(DataStructure.Point possition, int[,] boardMatrix)
        {
            return FindMoves(possition, boardMatrix);
        }

        static List<DataStructure.Point> FindMoves(DataStructure.Point possition, int[,] boardMatrix)
        {
            List<DataStructure.Point> possiblePossitions = new List<DataStructure.Point>();

            DataStructure.Point p;
            try
            {
                for (int i = possition.i - 1; i <= possition.i + 1; i++)
                {
                    for (int j = possition.j - 1; j <= possition.j + 1; j++)
                    {
                        if (possition.i == i && possition.j == j)
                        {
                            //do nothing
                            //this is current possition of the king
                        }
                        else
                        {
                            p = new DataStructure.Point(i, j);
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

        public static bool IsItCheck(DataStructure.Point possition , int[,] boardMatrix, DataStructure.Color pieceColor)
        {

            return CheckKing(possition, boardMatrix, (int)pieceColor);
        }

        private static bool CheckHorizontal(DataStructure.Point possition, int[,] boardMatrix, int color)
        {
            //check for rock / queen to the left
            DataStructure.Point p;
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
                            case (int)DataStructure.Figures.white_rock:
                                return true;
                            case (int)DataStructure.Figures.white_queen:
                                return true;
                            case (int)DataStructure.Figures.black_rock:
                                return true;
                            case (int)DataStructure.Figures.black_queen:
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
                            case (int)DataStructure.Figures.white_rock:
                                return true;
                            case (int)DataStructure.Figures.white_queen:
                                return true;
                            case (int)DataStructure.Figures.black_rock:
                                return true;
                            case (int)DataStructure.Figures.black_queen:
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

        private static bool CheckVertical(DataStructure.Point possition, int[,] boardMatrix, int color)
        {
            //check for rock / queen to the left
            DataStructure.Point p;
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
                            case (int)DataStructure.Figures.white_rock:
                                return true;
                            case (int)DataStructure.Figures.white_queen:
                                return true;
                            case (int)DataStructure.Figures.black_rock:
                                return true;
                            case (int)DataStructure.Figures.black_queen:
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
                            case (int)DataStructure.Figures.white_rock:
                                return true;
                            case (int)DataStructure.Figures.white_queen:
                                return true;
                            case (int)DataStructure.Figures.black_rock:
                                return true;
                            case (int)DataStructure.Figures.black_queen:
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

        private static bool CheckDiagonal(DataStructure.Point possition, int[,] boardMatrix, int color)
        {
            try
            {
                DataStructure.Point p;
                //up , left
                int i = possition.i - 1;
                int j = possition.j - 1;
                while (i > -1 && j > -1)
                {
                    p = new DataStructure.Point(i, j);
                    if (!Validation.IsEmpty(p, boardMatrix))
                    {
                        if (Validation.IsOpponent(p, possition, boardMatrix))
                        {
                            switch (boardMatrix[p.i, p.j])
                            {
                                case (int)DataStructure.Figures.white_bishop:
                                    return true;
                                case (int)DataStructure.Figures.white_queen:
                                    return true;
                                case (int)DataStructure.Figures.black_bishop:
                                    return true;
                                case (int)DataStructure.Figures.black_queen:
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
                    p = new DataStructure.Point(i, j);
                    if (!Validation.IsEmpty(p, boardMatrix))
                    {
                        if (Validation.IsOpponent(p, possition, boardMatrix))
                        {
                            switch (boardMatrix[p.i, p.j])
                            {
                                case (int)DataStructure.Figures.white_bishop:
                                    return true;
                                case (int)DataStructure.Figures.white_queen:
                                    return true;
                                case (int)DataStructure.Figures.black_bishop:
                                    return true;
                                case (int)DataStructure.Figures.black_queen:
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
                    p = new DataStructure.Point(i, j);
                    if (!Validation.IsEmpty(p, boardMatrix))
                    {
                        if (Validation.IsOpponent(p, possition, boardMatrix))
                        {
                            switch (boardMatrix[p.i, p.j])
                            {
                                case (int)DataStructure.Figures.white_bishop:
                                    return true;
                                case (int)DataStructure.Figures.white_queen:
                                    return true;
                                case (int)DataStructure.Figures.black_bishop:
                                    return true;
                                case (int)DataStructure.Figures.black_queen:
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
                    p = new DataStructure.Point(i, j);
                    if (!Validation.IsEmpty(p, boardMatrix))
                    {
                        if (Validation.IsOpponent(p, possition, boardMatrix))
                        {
                            switch (boardMatrix[p.i, p.j])
                            {
                                case (int)DataStructure.Figures.white_bishop:
                                    return true;
                                case (int)DataStructure.Figures.white_queen:
                                    return true;
                                case (int)DataStructure.Figures.black_bishop:
                                    return true;
                                case (int)DataStructure.Figures.black_queen:
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

        private static bool CheckKnight(DataStructure.Point possition, int[,] boardMatrix, int color)
        {
            try
            {
                DataStructure.Point p;

                p = new DataStructure.Point(possition.i + 2, possition.j - 1);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }                
                p = new DataStructure.Point(possition.i + 1, possition.j - 2);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }
                p = new DataStructure.Point(possition.i - 1, possition.j - 2);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }
                p = new DataStructure.Point(possition.i - 2, possition.j - 1);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }
                p = new DataStructure.Point(possition.i - 2, possition.j + 1);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }
                p = new DataStructure.Point(possition.i - 1, possition.j + 2);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }
                p = new DataStructure.Point(possition.i + 1, possition.j + 2);
                if (HelpCheckKnight(p, possition, boardMatrix))
                {
                    return true;
                }
                p = new DataStructure.Point(possition.i + 2, possition.j + 1);
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
        private static bool HelpCheckKnight(DataStructure.Point enemyPossition, DataStructure.Point allyPossition ,int[,] boardMatrix)
        {
            if (Validation.IsValidPosition(enemyPossition))
            {
                if (Validation.IsOpponent(allyPossition, enemyPossition, boardMatrix))
                {
                    switch (boardMatrix[enemyPossition.i, enemyPossition.j])
                    {
                        case (int)DataStructure.Figures.white_knight:
                            return true;
                        case (int)DataStructure.Figures.black_knight:
                            return true;
                        default:
                            break;
                    }
                }
            }
            return false;
        }

        private static bool CheckPawn(DataStructure.Point possition, int[,] boardMatrix, int color)
        {
            try
            {
                DataStructure.Point p;

                if (color == (int)DataStructure.Figures.white_king)
                {
                    p = new DataStructure.Point(possition.i + 1, possition.j - 1);
                    if (Validation.IsValidPosition(p))
                    {
                        if (Validation.IsOpponent(p, boardMatrix))
                        {
                            if (boardMatrix[p.i,p.j] == (int)DataStructure.Figures.black_pawn)
                            {
                                return true;
                            }
                        }
                    }
                    p = new DataStructure.Point(possition.i + 1, possition.j + 1);
                    if (Validation.IsValidPosition(p))
                    {
                        if (Validation.IsOpponent(p, boardMatrix))
                        {
                            if (boardMatrix[p.i, p.j] == (int)DataStructure.Figures.black_pawn)
                            {
                                return true;
                            }
                        }
                    }
                }
                else if (color == (int)DataStructure.Figures.black_king)
                {
                    p = new DataStructure.Point(possition.i - 1, possition.j - 1);
                    if (Validation.IsValidPosition(p))
                    {
                        if (Validation.IsOpponent(p, boardMatrix))
                        {
                            if (boardMatrix[p.i, p.j] == (int)DataStructure.Figures.white_pawn)
                            {
                                return true;
                            }
                        }
                    }
                    p = new DataStructure.Point(possition.i - 1, possition.j + 1);
                    if (Validation.IsValidPosition(p))
                    {
                        if (Validation.IsOpponent(p, boardMatrix))
                        {
                            if (boardMatrix[p.i, p.j] == (int)DataStructure.Figures.white_pawn)
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

        private static bool CheckKing(DataStructure.Point possition, int[,] boardMatrix, int color)
        {
            DataStructure.Point p;
            
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
                            p = new DataStructure.Point(i, j);

                            if (Validation.IsValidPosition(p))
                            {
                                if (boardMatrix[p.i, p.j] != 0)
                                {
                                    if (boardMatrix[p.i, p.j] % 2 != color)
                                    {
                                        switch (boardMatrix[p.i, p.j])
                                        {
                                            case (int)DataStructure.Figures.white_king:
                                                return true;
                                            case (int)DataStructure.Figures.black_king:
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
