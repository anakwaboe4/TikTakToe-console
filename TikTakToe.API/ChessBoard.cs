using TikTakToe.Core.Games;
using TikTakToe.Core.Players;
using TikTakToe.Core.Boards;

namespace TikTakToe.API {
    public class ChessBoard {
        public IGame? Game { get; set; } = new Game(new User(), new User(), new Board());
    }
}
