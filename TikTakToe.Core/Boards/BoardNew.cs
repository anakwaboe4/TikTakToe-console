using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTakToe.Core.Enums;

namespace TikTakToe.Core.Boards {
    public class BoardNew : Board {

        public BoardNew() {
            
        }

        public Board(Squares[,] squares) {
            BoardSquares = squares;
            lengthX = BoardSquares.GetLength(0);
            lengthY = BoardSquares.GetLength(1);
        }

        public bool CheckMove(int position, int move) {
            int x = (position - 1) / lengthX;
            int y = (position - 1) % lengthX;

            if(BoardSquares[x, y] != Squares.Empty) {
                return true;
            }
            else
                return false;
        }

        public bool MakeMove(int position, Squares move) {
            int x = (position - 1) / lengthX;
            int y = (position - 1) % lengthX;

            if(BoardSquares[x, y] != Squares.Empty) {
                BoardSquares[x, y] = move;
                return true;
            }
            else
                return false;
        }
    }
}
