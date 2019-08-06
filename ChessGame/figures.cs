using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    interface figures
    {
        List<Tuple<int, int>> move();
    }
}
