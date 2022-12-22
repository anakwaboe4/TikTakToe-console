using TikTakToe.Core.Enums;

namespace TikTakToe.Core.Games {
    public interface IGame {
        public bool MakeMove(int position);
        public bool MakeMove(int x, int y);
        public int GetMoves();
        public Squares[,] GetBoard();
    }
}
