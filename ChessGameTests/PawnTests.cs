using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Tests
{
    [TestClass()]
    public class PawnTests
    {
        [TestMethod()]
        public void FindPossibleMovesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EndofTheColumnTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WasDoubleJumpTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void KickingOutEnPassantTest()
        {
            int[,] board = new int[8, 8] {
            {3,5,7,11,9,7,5,3 },
            {1,1,1,1,1,1,1,1 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 },
            {2,2,2,2,2,2,2,2 },
            {4,6,8,12,10,8,6,4 }};


            Assert.Fail();
        }
    }
}