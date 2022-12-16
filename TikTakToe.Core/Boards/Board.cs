using TikTakToe.Core.Enums;

namespace TikTakToe.Core.Boards {
    public abstract class Board {
        public int Score { get; internal set; } = 0;
        public int Move { get; internal set; } = 0;
        public int LengthX { get; }
        public int LengthY { get; }

        public Board(int lengthX, int lengthY) {
            LengthX = lengthX;
            LengthY = lengthY;
        }

        public abstract bool CheckMove(int position, int move);

        public abstract bool MakeMove(int position, Squares move);

        public abstract int CalculateScore();

        public abstract Squares[,] Get2Dim();
    }
}
