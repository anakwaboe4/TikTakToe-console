using TikTakToe.Core.AIs;
using TikTakToe.Core.Boards;
using TikTakToe.Core.Enums;

namespace TikTakToe.Core.Games {
    public class Game : IGame {
        private AI ai;
        private Board board;

        public Game(AI ai, Board board) {
            this.ai = ai;
            this.board = board;
        }

        public bool MakeMove(int position)
        {
            return board.MakeMove(position, Squares.X);
        }

        public Squares[,] GetBoard()
        {
            throw new NotImplementedException();
        }
    }
}
