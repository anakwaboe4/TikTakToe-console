using TikTakToe.Core.Boards;
using TikTakToe.Core.Enums;
using TikTakToe.Core.Players;

namespace TikTakToe.Core.Games {
    public class Game : IGame {
        private Player player1;
        private Player player2;
        private Board board;

        public Game(Player player1, Player player2, Board board) {
            this.player1 = player1;
            this.player2 = player2;
            this.board = board;
        }

        public bool MakeMove(int position) {
            return board.MakeMove(position, (board.Move % 2) == 0 ? Squares.X : Squares.O);
        }

        public bool MakeMove(int x, int y)
        {
            return board.MakeMove(x * y, (board.Move % 2) == 0 ? Squares.X : Squares.O);
        }

        public int GetMoves() {
            return board.Move;
        }

        public Squares[,] GetBoard()
        {
            throw new NotImplementedException();
        }
    }
}
