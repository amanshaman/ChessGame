using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model
{
    static class EnvironmentVariables
    {
        private static DataStructure.Color player;

        public static DataStructure.Color Player
        {
            get { return player; }

            set
            {
                player = value;
                if (player == DataStructure.Color.white)
                {
                    //StartMove();
                }
                if (player == DataStructure.Color.black)
                {
                    //StartMove();
                }
            }
        }
    }
}
