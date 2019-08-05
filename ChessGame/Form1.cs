using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //PictureBox[,] pictureboxes = new PictureBox[8, 8];
            List<PictureBox> pictureBoxes = new List<PictureBox>();
            Control[] matches;
            for (int i = 0; i < 64; i++)
            {
                matches = this.Controls.Find("pictureBox" + i.ToString(), true);
                if (matches.Length > 0 && matches[0] is PictureBox)
                {
                    pictureBoxes.Add((PictureBox)matches[0]);
                }
            }

            BoardController board = new BoardController(pictureBoxes);
        }

        
    }
}
