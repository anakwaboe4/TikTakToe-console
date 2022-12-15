using TikTakToe.Core.Enums;

namespace TikTakToe.Core.Boards {
    public abstract class Board {
        public Squares[,] BoardSquares { get; set; }
        public int Score { get; set; } = 0;
        public int Move { get; set; } = 0;

        private int lengthX;
        private int lengthY;

        public Board() {
            BoardSquares = new Squares[3, 3];
            lengthX = BoardSquares.GetLength(0);
            lengthY = BoardSquares.GetLength(1);
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
