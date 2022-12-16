using TikTakToe.Core.Enums;

namespace TikTakToe.Core.Games {
    public interface IGame {
        public bool MakeMove(int x, int y);
        public Squares[,] GetBoard();
    }
}
