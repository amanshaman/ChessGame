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
        private int player = (int)DataStructure.color.white;

        protected static List<DataStructure.point> possiblePossitions;

        protected Dictionary<string, DataStructure.point> myCollection;

        List<PictureBox> listOfControllers;

        /// <summary>
        /// Matrix for the board
        /// </summary>
        protected static int[,] boardMatrix;

        protected enum figures
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

            boardMatrix = nboard;

            DrawBackground();

            AddClickEventToPictures();
        }        

        /// <summary>
        /// Method for redrawing the board according to the matrix.
        /// </summary>
        private void DrawBackground()
        {
            myCollection = new Dictionary<string, DataStructure.point>();
            DataStructure.point p = new DataStructure.point();
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

        /// <summary>
        /// Method that moves figures on the board
        /// </summary>
        /// <param name="currentPosition">Current position of the figure</param>
        /// <param name="newPosition">Next position of the figure</param>
        protected void MoveFigure(DataStructure.point currentPosition, DataStructure.point newPosition)
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
        
        private void PictureClick(object sender, EventArgs e)
        {

            PictureBox oBox = (PictureBox)sender;

            SelectUnselectPiece(oBox);            


        }

        DataStructure.point pickedPiece = new DataStructure.point();
        private Boolean pickedFlag = false;
        void SelectUnselectPiece(PictureBox oBox)
        {
            if (!pickedFlag)
            {
                if (player == (int)DataStructure.color.white)
                {
                    pickedPiece.i = myCollection[oBox.Name].i;
                    pickedPiece.j = myCollection[oBox.Name].j;
                    if (Validation.FigureColor(pickedPiece, boardMatrix) == DataStructure.color.white)
                    {
                        pickedFlag = true;

                        switch (boardMatrix[myCollection[oBox.Name].i, myCollection[oBox.Name].j])
                        {
                            case (int)figures.white_pawn:
                                possiblePossitions = Pawn.findPossibleMoves(DataStructure.color.white, pickedPiece, boardMatrix);
                                break;                           
                            case (int)figures.white_rock:
                                possiblePossitions = Rock.findPossibleMoves(DataStructure.color.white, pickedPiece, boardMatrix);
                                break;
                            case (int)figures.white_knight:
                                possiblePossitions = Knight.findPossibleMoves(DataStructure.color.white, pickedPiece, boardMatrix);
                                break;
                            case (int)figures.white_bishop:
                                possiblePossitions = Bishopcs.findPossibleMoves(DataStructure.color.white, pickedPiece, boardMatrix);
                                break;
                            case (int)figures.white_queen:
                                possiblePossitions = Queen.findPossibleMoves(DataStructure.color.white, pickedPiece, boardMatrix);
                                break;
                            case (int)figures.white_king:
                                possiblePossitions = King.FindPossibleMoves(DataStructure.color.white, pickedPiece, boardMatrix);
                                break;
                            default:
                                break;
                        }
                        DrawBackground();
                        HighligtSelectedPiece(oBox);
                    }
                }
                else
                {
                    pickedPiece.i = myCollection[oBox.Name].i;
                    pickedPiece.j = myCollection[oBox.Name].j;
                    if (Validation.FigureColor(pickedPiece, boardMatrix) == DataStructure.color.black)
                    {
                        pickedFlag = true;
                        switch (boardMatrix[myCollection[oBox.Name].i, myCollection[oBox.Name].j])
                        {
                            case (int)figures.black_pawn:
                                possiblePossitions = Pawn.findPossibleMoves(DataStructure.color.black, pickedPiece, boardMatrix);
                                break;
                            case (int)figures.black_rock:
                                possiblePossitions = Rock.findPossibleMoves(DataStructure.color.black, pickedPiece, boardMatrix);
                                break;
                            case (int)figures.black_knight:
                                possiblePossitions = Knight.findPossibleMoves(DataStructure.color.black, pickedPiece, boardMatrix);
                                break;
                            case (int)figures.black_bishop:
                                possiblePossitions = Bishopcs.findPossibleMoves(DataStructure.color.black, pickedPiece, boardMatrix);
                                break;
                            case (int)figures.black_queen:
                                possiblePossitions = Queen.findPossibleMoves(DataStructure.color.black, pickedPiece, boardMatrix);
                                break;
                            case (int)figures.black_king:
                                possiblePossitions = King.FindPossibleMoves(DataStructure.color.black, pickedPiece, boardMatrix);
                                break;
                            default:
                                break;
                        }
                        DrawBackground();
                        HighligtSelectedPiece(oBox);
                    }
                }
            }
            else
            {
                if (pickedPiece.i == myCollection[oBox.Name].i && pickedPiece.j == myCollection[oBox.Name].j)
                {
                    pickedPiece.i = -1;
                    pickedPiece.j = -1;

                    pickedFlag = false;
                    DrawBackground();
                }
                else
                {
                    DataStructure.point temp = new DataStructure.point(myCollection[oBox.Name].i, myCollection[oBox.Name].j);
                    //if it is one of highlighted fields go on. if not than 
                    //if it is a empty field or not highlighted enemy piece do nothing if it is a friendly piece select it 
                    if (Validation.IsItHighlightedField(possiblePossitions, temp))
                    {
                        MoveFigure(pickedPiece, temp);
                        if (boardMatrix[temp.i, temp.j] == (int)DataStructure.figures.white_pawn ||
                            boardMatrix[temp.i, temp.j] == (int)DataStructure.figures.black_pawn)
                        {
                            Pawn.KickingOutFreebie(pickedPiece, temp, boardMatrix, player);
                            Pawn.EndofTheMove(temp, boardMatrix);
                            Pawn.WasDoubleJump(pickedPiece, temp);
                        }
                        
                        pickedFlag = false;
                        DrawBackground();
                        ChangePlayer();
                    }
                    else if (Validation.IsEmpty(temp, boardMatrix))
                    {
                        //do nothing
                    }
                    else
                    {
                        if (boardMatrix[pickedPiece.i, pickedPiece.j] % 2 == (int)DataStructure.color.white)
                        {
                            if (!Validation.IsOpponent(temp, DataStructure.color.white, boardMatrix))
                            {
                                pickedPiece.i = -1;
                                pickedPiece.j = -1;

                                pickedFlag = false;
                                SelectUnselectPiece(oBox);
                            }
                            //else do nothing
                        }
                        else if (boardMatrix[pickedPiece.i, pickedPiece.j] % 2 == (int)DataStructure.color.black)
                        {
                            if (!Validation.IsOpponent(temp, DataStructure.color.black, boardMatrix))
                            {
                                pickedPiece.i = -1;
                                pickedPiece.j = -1;

                                pickedFlag = false;
                                SelectUnselectPiece(oBox);
                            }
                            //else do nothing
                        }
                    }

                }

            }

        }

        /// <summary>
        /// Method for drawing out possible moves and possible pieces of figures to be kick out.
        /// </summary>
        /// <param name="oBox"></param>
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
            try
            {                
                foreach (var p in possiblePossitions)
                {
                    int k = 0;
                    foreach (var item in myCollection)
                    {
                        if (item.Value.i == p.i && item.Value.j == p.j)
                        {
                            //if value of the field is 0 than its empty so just change color of background
                            if (boardMatrix[p.i,p.j] == 0)
                            {
                                listOfControllers[k].BackColor = Color.Green;
                            }
                            else
                            {
                                //if %2 == 0 than field is white otherwise brown
                                if ((p.i + p.j) % 2 == 0)
                                {
                                    switch (boardMatrix[p.i, p.j])
                                    {
                                        case (int)figures.white_pawn:
                                            listOfControllers[k].Image = Properties.Resources.selected_white_pawn_white;
                                            break;
                                        case (int)figures.black_pawn:
                                            listOfControllers[k].Image = Properties.Resources.selected_black_pawn_white;
                                            break;
                                        case (int)figures.white_rock:
                                            listOfControllers[k].Image = Properties.Resources.selected_white_rock_white;
                                            break;
                                        case (int)figures.black_rock:
                                            listOfControllers[k].Image = Properties.Resources.selected_black_rock_white;
                                            break;
                                        case (int)figures.white_knight:
                                            listOfControllers[k].Image = Properties.Resources.selected_white_knight_white;
                                            break;
                                        case (int)figures.black_knight:
                                            listOfControllers[k].Image = Properties.Resources.selected_black_knight_white;
                                            break;
                                        case (int)figures.white_bishop:
                                            listOfControllers[k].Image = Properties.Resources.selected_white_bishop_white;
                                            break;
                                        case (int)figures.black_bishop:
                                            listOfControllers[k].Image = Properties.Resources.selected_black_bishop_white;
                                            break;
                                        case (int)figures.white_queen:
                                            listOfControllers[k].Image = Properties.Resources.selected_white_queen_white;
                                            break;
                                        case (int)figures.black_queen:
                                            listOfControllers[k].Image = Properties.Resources.selected_black_queen_white;
                                            break;
                                        case (int)figures.white_king:
                                            listOfControllers[k].Image = Properties.Resources.selected_white_king_white;
                                            break;
                                        case (int)figures.black_king:
                                            listOfControllers[k].Image = Properties.Resources.selected_black_King_white;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (boardMatrix[p.i, p.j])
                                    {
                                        case (int)figures.white_pawn:
                                            listOfControllers[k].Image = Properties.Resources.selected_white_pawn_brown;
                                            break;
                                        case (int)figures.black_pawn:
                                            listOfControllers[k].Image = Properties.Resources.selected_black_pawn_brown;
                                            break;
                                        case (int)figures.white_rock:
                                            listOfControllers[k].Image = Properties.Resources.selected_white_rock_brown;
                                            break;
                                        case (int)figures.black_rock:
                                            listOfControllers[k].Image = Properties.Resources.selected_black_rock_brown;
                                            break;
                                        case (int)figures.white_knight:
                                            listOfControllers[k].Image = Properties.Resources.selected_white_knight_brown;
                                            break;
                                        case (int)figures.black_knight:
                                            listOfControllers[k].Image = Properties.Resources.selected_black_knight_brown;
                                            break;
                                        case (int)figures.white_bishop:
                                            listOfControllers[k].Image = Properties.Resources.selected_white_bishop_brown;
                                            break;
                                        case (int)figures.black_bishop:
                                            listOfControllers[k].Image = Properties.Resources.selected_black_bishop_brown;
                                            break;
                                        case (int)figures.white_queen:
                                            listOfControllers[k].Image = Properties.Resources.selected_white_queen_brown;
                                            break;
                                        case (int)figures.black_queen:
                                            listOfControllers[k].Image = Properties.Resources.selected_black_queen_brown;
                                            break;
                                        case (int)figures.white_king:
                                            listOfControllers[k].Image = Properties.Resources.selected_white_king_brown;
                                            break;
                                        case (int)figures.black_king:
                                            listOfControllers[k].Image = Properties.Resources.selected_black_King_brown;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                        k++;
                    }
                }


            //possiblePossitions = null;

            }
            catch (Exception e)
            {
                Console.WriteLine("Problem in HighligtSelectedPiece" + e.ToString());
            }

        }



        private void ChangePlayer()
        {
            if (player == (int)DataStructure.color.white)
            {
                player = (int)DataStructure.color.black;
            }
            else
            {
                player = (int)DataStructure.color.white;
            }
        }

    }
}
