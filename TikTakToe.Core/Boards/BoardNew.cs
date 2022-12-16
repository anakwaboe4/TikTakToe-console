using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTakToe.Core.Enums;

namespace TikTakToe.Core.Boards {
    public class BoardNew : Board {
        private Squares[,] boardSquares;

        public BoardNew(int lengthX, int lengthY) : base(lengthX, lengthY) {
            boardSquares = new Squares[lengthX, lengthY];
        }

        public override bool CheckMove(int position, int move) {
            int x = (position - 1) / LengthX;
            int y = (position - 1) % LengthX;

            if(boardSquares[x, y] != Squares.Empty) {
                return true;
            }
            else
                return false;
        }

        public override bool MakeMove(int position, Squares move) {
            int x = (position - 1) / LengthX;
            int y = (position - 1) % LengthX;

            if(boardSquares[x, y] != Squares.Empty) {
                boardSquares[x, y] = move;
                Move++;
                return true;
            }
            else
                return false;
        }

        public override Squares[,] Get2Dim() {
            return boardSquares;
        }
    }
}
