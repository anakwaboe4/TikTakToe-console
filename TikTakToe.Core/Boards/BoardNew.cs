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

        public override int CalculateScore() {
            Score = 0;
            if (boardSquares[1, 1] == Squares.X) //quick middlecheck for effectient updating 
            {
                if (boardSquares[2, 2] == Squares.X && boardSquares[0, 0] == Squares.X) { Score = 1; }
                else if (boardSquares[0, 2] == Squares.X && boardSquares[2, 0] == Squares.X) { Score = 1; }
                else if (boardSquares[1, 0] == Squares.X && boardSquares[1, 2] == Squares.X) { Score = 1; }
                else if (boardSquares[0, 1] == Squares.X && boardSquares[2, 1] == Squares.X) { Score = 1; }

            }
            else if (boardSquares[1, 1] == Squares.O)
            {
                if (boardSquares[2, 2] == Squares.O && boardSquares[0, 0] == Squares.O) { Score = -1; }
                else if (boardSquares[0, 2] == Squares.O && boardSquares[2, 0] == Squares.O) { Score = -1; }
                else if (boardSquares[1, 0] == Squares.O && boardSquares[1, 2] == Squares.O) { Score = -1; }
                else if (boardSquares[0, 1] == Squares.O && boardSquares[2, 1] == Squares.O) { Score = -1; }

            }
            if (boardSquares[0, 0] == Squares.X && boardSquares[0, 1] == Squares.X && boardSquares[0, 2] == Squares.X) { Score = 1; }
            if (boardSquares[2, 0] == Squares.X && boardSquares[2, 1] == Squares.X && boardSquares[2, 2] == Squares.X) { Score = 1; }
            if (boardSquares[0, 0] == Squares.O && boardSquares[0, 1] == Squares.O && boardSquares[0, 2] == Squares.O) { Score = -1; }
            if (boardSquares[2, 0] == Squares.O && boardSquares[2, 1] == Squares.O && boardSquares[2, 2] == Squares.O) { Score = -1; }
            //check logic again
            if (boardSquares[0, 0] == Squares.X && boardSquares[1, 0] == Squares.X && boardSquares[2, 0] == Squares.X) { Score = 1; }
            if (boardSquares[0, 2] == Squares.X && boardSquares[1, 2] == Squares.X && boardSquares[2, 2] == Squares.X) { Score = 1; }
            if (boardSquares[0, 0] == Squares.O && boardSquares[1, 0] == Squares.O && boardSquares[2, 0] == Squares.O) { Score = -1; }
            if (boardSquares[0, 2] == Squares.O && boardSquares[1, 2] == Squares.O && boardSquares[2, 2] == Squares.O) { Score = -1; }
            // give some points for 2 in a row with a 0 in them

            return Score;
        }

        public override Squares[,] GetBoard() {
            return boardSquares;
        }
    }
}
