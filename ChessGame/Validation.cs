using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessGame.Model;

namespace ChessGame
{
    static class Validation
    {
        /// <summary>
        /// Method to determinade if a field is empty.
        /// </summary>
        /// <param name="possition">Position to move.</param>
        /// <returns></returns>
        public static bool IsEmpty(DataStructure.Point possition, int[,] boardMatrix)
        {
            try
            {
                if (boardMatrix[possition.i, possition.j] == 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("IsEmpty methid failure: Values of x and y axis needs to be between 0 to 7.");
                Console.WriteLine(e.ToString());
            }
            return false;
        }

        /// <summary>
        /// Method for validating a position. It has to be matrix 0 to 7 in x and y axis.
        /// </summary>
        /// <param name="possition">position to be validated</param>
        /// <returns></returns>
        public static bool IsValidPosition(DataStructure.Point possition)
        {
            try
            {
                if (possition.i < 0 || possition.i > 7)
                {
                    return false;
                }
                else if (possition.j < 0 || possition.j > 7)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("IsValidPosition method failure: Values of x and y axis needs to be between 0 to 7.");
                Console.WriteLine(e.ToString());
            }
            return true;
        }

        public static bool IsOpponent(DataStructure.Point possition, int[,] boardMatrix)
        {
            try
            {
                //if (int)color % 2 != 0 it means its 1 therefore an odd number = white.
                //if (color == (int)DataStructure.Color.white)
                if (EnvironmentVariables.Player == DataStructure.Color.white)
                {
                    //than if value on the possition is equal to 0 (even number) than its black and can be kicked out
                    //value needs to be bigger than 0 as it is empty value.
                    if (boardMatrix[possition.i, possition.j] > 0 && boardMatrix[possition.i, possition.j] % 2 == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    //than if value on the possition is equal to 1 (odd number) than its white and can be kicked out
                    if (boardMatrix[possition.i, possition.j] % 2 == 1)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("IsOpponent methid failure: Values of x and y axis needs to be between 0 to 7.");
                Console.WriteLine(e.ToString());
            }

            return false;
        }

        /// <summary>
        /// Checks if selectedField is in possiblePossitions
        /// </summary>
        /// <param name="possiblePossitions">list of x,y coordinates</param>
        /// <param name="selectedField">one x,y coordinate. </param>
        /// <returns>true/false based if selectedfield x,y coordinate is in the list of possiblePossitions coordinates</returns>
        public static bool IsItHighlightedField(List<DataStructure.Point> possiblePossitions, DataStructure.Point selectedField)
        {
            foreach (DataStructure.Point p in possiblePossitions)
            {
                if (p.i == selectedField.i && p.j == selectedField.j)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Find out what color is a selected piece.
        /// </summary>
        /// <param name="selectedField">x,y coordinates for selected field</param>
        /// <param name="boardMatrix">matrix itself</param>
        /// <returns>Color of the selected figure, or that no figure was selected (empty)</returns>
        public static DataStructure.Color FigureColor(DataStructure.Point selectedField, int[,] boardMatrix)
        {
            if (boardMatrix[selectedField.i, selectedField.j] == 0)
            {
                return DataStructure.Color.empty;
            }
            if (boardMatrix[selectedField.i, selectedField.j] % 2 == (int)DataStructure.Color.white)
            {
                return DataStructure.Color.white;
            }
            else
            {
                return DataStructure.Color.black;
            }
        }

        public static bool IsOpponent(DataStructure.Point enemyPossition, DataStructure.Point allyPossition, int[,] boardMatrix)
        {
            try
            {
                if (boardMatrix[enemyPossition.i,enemyPossition.j] != (int)DataStructure.Figures.empty)
                {
                    if (boardMatrix[enemyPossition.i,enemyPossition.j] % 2 != boardMatrix[allyPossition.i,allyPossition.j] % 2)
                    {
                        return true;
                    }
                }
                
                ////if (int)color % 2 != 0 it means its 1 therefore an odd number = white.
                //if ((int)color % 2 != 0)
                //{
                //    //than if value on the possition is equal to 0 (even number) than its black and can be kicked out
                //    //value needs to be bigger than 0 as it is empty value.
                //    if (boardMatrix[possition.i, possition.j] > 0 && boardMatrix[possition.i, possition.j] % 2 == 0)
                //    {
                //        return true;
                //    }
                //}
                //else
                //{
                //    //than if value on the possition is equal to 1 (odd number) than its white and can be kicked out
                //    if (boardMatrix[possition.i, possition.j] % 2 == 1)
                //    {
                //        return true;
                //    }
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine("IsOpponent methid failure: Values of x and y axis needs to be between 0 to 7.");
                Console.WriteLine(e.ToString());
            }

            return false;
        }
    }
}
