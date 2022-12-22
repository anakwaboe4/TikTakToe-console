using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTakToe.Core.Boards;
using TikTakToe.Core.Helpers;
using TikTakToe.Core.Enums;

namespace TikTakToe.Core.Players {
    public class AIRandom : Player {
        Random rnd = new Random();

        public override int CalculateBestMove(Board board) {
            board.CalculateScore();

            if(board.Score < 1000 && board.Score > -1000) {
                var moves = new List<int>();
                for(int i = 1; i < 10; i++) {

                    if(board.CheckMove(i)) {
                        moves.Add(i);
                    }

                }
                if(moves.Count == 0) {
                    return -1;

                }

                return moves[rnd.Next(moves.Count)];
            }
            return -1;
        }

        public override int CalculateNextMove(Board board) {
            throw new NotImplementedException();
        }
    }
}
