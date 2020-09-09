using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    interface IFigureMoves
    {
        /// <summary>
        /// Find all possible moves for the piece.
        /// </summary>
        /// <param name="possition">picked piece possition</param>
        /// <param name="boardMatrix">matrix of the board to be use.</param>
        /// <returns></returns>
        List<DataStructure.Point> FindPossibleMoves(DataStructure.Point possition, int[,] boardMatrix);
    }
}
