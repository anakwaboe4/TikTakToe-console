using TikTakToe.Core.Boards;

namespace TikTakToe.Core.Players {
    public abstract class Player {
        public bool IsAI { get; }

        public abstract int CalculateNextMove(Board board);

        public abstract int CalculateBestMove(Board board);
    }
}
