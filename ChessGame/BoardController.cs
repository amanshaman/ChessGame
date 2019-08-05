using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChessGame
{
    class BoardController
    {
        private Dictionary<string, point> myCollection;

        List<PictureBox> listOfControllers;

        /// <summary>
        /// Matrix for the board
        /// </summary>
        private int[,] boardMatrix;

        /// <summary>
        /// Get, set a board
        /// </summary>
        public int[,] BoardMatrix { get => boardMatrix; set => boardMatrix = value; }

        public enum figures
        {
            empty = 0,
            white_pawn = 1,
            black_pawn = 2,
            white_rock = 3,
            black_rock = 4,
            white_knight = 5,
            black_knight = 6,
            white_bishop = 7,
            black_bishop = 8,
            white_queen = 9,
            black_queen = 10,
            white_king = 11,
            black_king = 12,
        };

        public enum color
        {
            black,
            white
        }

        public struct point
        {
            public int i;
            public int j;

            public point(int i, int j)
            {
                this.i = i;
                this.j = j;
            }
        }

        public BoardController()
        {
            Console.WriteLine("Pls use BoardController(List<PictureBox> listOfControllers) method for creating board");
        }

        /// <summary>
        /// Create basic starting board
        /// </summary>
        public BoardController(List<PictureBox> listOfControllers)
        {
            this.listOfControllers = listOfControllers;
            int[,] nboard = new int[8, 8] {
            {3,5,7,11,9,7,5,3 },
            {1,1,1,1,1,1,1,1 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {2,2,2,2,2,2,2,2 },
            {4,6,8,12,10,8,6,4 }};

            this.BoardMatrix = nboard;

            DrawBackground();

            AddClickEventToPictures();
        }        

        /// <summary>
        /// Method for redrawing the board according to the matrix.
        /// </summary>
        private void DrawBackground()
        {
            myCollection = new Dictionary<string, point>();
            point p = new point();
            int k = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        switch (boardMatrix[i, j])
                        {
                            case (int)figures.empty:
                                listOfControllers[k].BackColor = Color.White;
                                listOfControllers[k].Image = null;
                                break;
                            case (int)figures.white_pawn:
                                listOfControllers[k].Image = Properties.Resources.white_pawn_white;
                                break;
                            case (int)figures.black_pawn:
                                listOfControllers[k].Image = Properties.Resources.black_pawn_white;
                                break;
                            case (int)figures.white_rock:
                                listOfControllers[k].Image = Properties.Resources.white_rock_white;
                                break;
                            case (int)figures.black_rock:
                                listOfControllers[k].Image = Properties.Resources.black_rock_white;
                                break;
                            case (int)figures.white_knight:
                                listOfControllers[k].Image = Properties.Resources.white_knight_white;
                                break;
                            case (int)figures.black_knight:
                                listOfControllers[k].Image = Properties.Resources.black_knight_white;
                                break;
                            case (int)figures.white_bishop:
                                listOfControllers[k].Image = Properties.Resources.white_bishop_white;
                                break;
                            case (int)figures.black_bishop:
                                listOfControllers[k].Image = Properties.Resources.black_bishop_white;
                                break;
                            case (int)figures.white_queen:
                                listOfControllers[k].Image = Properties.Resources.white_queen_white;
                                break;
                            case (int)figures.black_queen:
                                listOfControllers[k].Image = Properties.Resources.black_queen_white;
                                break;
                            case (int)figures.white_king:
                                listOfControllers[k].Image = Properties.Resources.white_king_white;
                                break;
                            case (int)figures.black_king:
                                listOfControllers[k].Image = Properties.Resources.black_King_white;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (boardMatrix[i, j])
                        {
                            case (int)figures.empty:
                                listOfControllers[k].BackColor = Color.RosyBrown;
                                listOfControllers[k].Image = null;
                                break;
                            case (int)figures.white_pawn:
                                listOfControllers[k].Image = Properties.Resources.white_pawn_brown;
                                break;
                            case (int)figures.black_pawn:
                                listOfControllers[k].Image = Properties.Resources.black_pawn_brown;
                                break;
                            case (int)figures.white_rock:
                                listOfControllers[k].Image = Properties.Resources.white_rock_brown;
                                break;
                            case (int)figures.black_rock:
                                listOfControllers[k].Image = Properties.Resources.black_rock_brown;
                                break;
                            case (int)figures.white_knight:
                                listOfControllers[k].Image = Properties.Resources.white_knight_brown;
                                break;
                            case (int)figures.black_knight:
                                listOfControllers[k].Image = Properties.Resources.black_knight_brown;
                                break;
                            case (int)figures.white_bishop:
                                listOfControllers[k].Image = Properties.Resources.white_bishop_brown;
                                break;
                            case (int)figures.black_bishop:
                                listOfControllers[k].Image = Properties.Resources.black_bishop_brown;
                                break;
                            case (int)figures.white_queen:
                                listOfControllers[k].Image = Properties.Resources.white_queen_brown;
                                break;
                            case (int)figures.black_queen:
                                listOfControllers[k].Image = Properties.Resources.black_queen_brown;
                                break;
                            case (int)figures.white_king:
                                listOfControllers[k].Image = Properties.Resources.white_king_brown;
                                break;
                            case (int)figures.black_king:
                                listOfControllers[k].Image = Properties.Resources.black_King_brown;
                                break;
                            default:
                                break;
                        }
                    }
                    p.i = i;
                    p.j = j;
                    myCollection.Add(listOfControllers[k].Name.ToString(), p);
                    k++;
                }
            }

        }

        private void AddClickEventToPictures()
        {
            foreach (PictureBox pictureBox in listOfControllers)
            {
                pictureBox.Click += PictureClick;
            }
        }


        point pickedPiece;
        Boolean pickedFlag = false;
        private void PictureClick(object sender, EventArgs e)
        {
            
            PictureBox oBox = (PictureBox)sender;
            bool t = false;
            //if previously there was no piece picked than pick some
            if (boardMatrix[myCollection[oBox.Name].i, myCollection[oBox.Name].j] != 0 && !pickedFlag)
            {
                pickedPiece = new point(myCollection[oBox.Name].i, myCollection[oBox.Name].j);
                pickedFlag = true;
                t = true;
            }
            //else put a piece on this place and unflag the flag
            else if (pickedFlag)
            {
                point temp = new point(myCollection[oBox.Name].i, myCollection[oBox.Name].j);
                MoveFigure(pickedPiece, temp);
                pickedFlag = false;
                t = false;
            }

            DrawBackground();
            if (t)
            {
                HighligtSelectedPiece(oBox);
            }
           

        }

        private void HighligtSelectedPiece(PictureBox oBox)
        {
            if (boardMatrix[myCollection[oBox.Name].i, myCollection[oBox.Name].j] != 0)
            {
                //if %2 == 0 than field is white otherwise brown
                if ((myCollection[oBox.Name].i + myCollection[oBox.Name].j) % 2 == 0)
                {
                    switch (boardMatrix[myCollection[oBox.Name].i, myCollection[oBox.Name].j])
                    {
                        case (int)figures.white_pawn:
                            oBox.Image = Properties.Resources.selected_white_pawn_white;
                            break;
                        case (int)figures.black_pawn:
                            oBox.Image = Properties.Resources.selected_black_pawn_white;
                            break;
                        case (int)figures.white_rock:
                            oBox.Image = Properties.Resources.selected_white_rock_white;
                            break;
                        case (int)figures.black_rock:
                            oBox.Image = Properties.Resources.selected_black_rock_white;
                            break;
                        case (int)figures.white_knight:
                            oBox.Image = Properties.Resources.selected_white_knight_white;
                            break;
                        case (int)figures.black_knight:
                            oBox.Image = Properties.Resources.selected_black_knight_white;
                            break;
                        case (int)figures.white_bishop:
                            oBox.Image = Properties.Resources.selected_white_bishop_white;
                            break;
                        case (int)figures.black_bishop:
                            oBox.Image = Properties.Resources.selected_black_bishop_white;
                            break;
                        case (int)figures.white_queen:
                            oBox.Image = Properties.Resources.selected_white_queen_white;
                            break;
                        case (int)figures.black_queen:
                            oBox.Image = Properties.Resources.selected_black_queen_white;
                            break;
                        case (int)figures.white_king:
                            oBox.Image = Properties.Resources.selected_white_king_white;
                            break;
                        case (int)figures.black_king:
                            oBox.Image = Properties.Resources.selected_black_King_white;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (boardMatrix[myCollection[oBox.Name].i, myCollection[oBox.Name].j])
                    {
                        case (int)figures.white_pawn:
                            oBox.Image = Properties.Resources.selected_white_pawn_brown;
                            break;
                        case (int)figures.black_pawn:
                            oBox.Image = Properties.Resources.selected_black_pawn_brown;
                            break;
                        case (int)figures.white_rock:
                            oBox.Image = Properties.Resources.selected_white_rock_brown;
                            break;
                        case (int)figures.black_rock:
                            oBox.Image = Properties.Resources.selected_black_rock_brown;
                            break;
                        case (int)figures.white_knight:
                            oBox.Image = Properties.Resources.selected_white_knight_brown;
                            break;
                        case (int)figures.black_knight:
                            oBox.Image = Properties.Resources.selected_black_knight_brown;
                            break;
                        case (int)figures.white_bishop:
                            oBox.Image = Properties.Resources.selected_white_bishop_brown;
                            break;
                        case (int)figures.black_bishop:
                            oBox.Image = Properties.Resources.selected_black_bishop_brown;
                            break;
                        case (int)figures.white_queen:
                            oBox.Image = Properties.Resources.selected_white_queen_brown;
                            break;
                        case (int)figures.black_queen:
                            oBox.Image = Properties.Resources.selected_black_queen_brown;
                            break;
                        case (int)figures.white_king:
                            oBox.Image = Properties.Resources.selected_white_king_brown;
                            break;
                        case (int)figures.black_king:
                            oBox.Image = Properties.Resources.selected_black_King_brown;
                            break;
                        default:
                            break;
                    }
                }



            }
        }

        /// <summary>
        /// Method that moves figures on the board
        /// </summary>
        /// <param name="currentPosition">Current position of the figure</param>
        /// <param name="newPosition">Next position of the figure</param>
        public void MoveFigure(point currentPosition, point newPosition)
        {
            try
            {
                boardMatrix[newPosition.i, newPosition.j] = boardMatrix[currentPosition.i, currentPosition.j];
                boardMatrix[currentPosition.i, currentPosition.j] = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("MoveFigure method failure: Values of x and y axis needs to be between 0 to 7.");
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Method for validating a position. It has to be matrix 0 to 7 in x and y axis.
        /// </summary>
        /// <param name="possition">position to be validated</param>
        /// <returns></returns>
        public bool IsValidPosition(point possition)
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

        /// <summary>
        /// Method to determinade if a field is empty.
        /// </summary>
        /// <param name="possition">Position to move.</param>
        /// <returns></returns>
        public bool IsEmpty(point possition)
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

        public bool IsOpponent(point possition, color color)
        {
            try
            {
                //if (int)color % 2 != 0 it means its 1 therefore an odd number = white.
                if ((int)color % 2 != 0)
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
    }
}
