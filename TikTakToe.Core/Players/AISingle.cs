using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTakToe.Core.Boards;

namespace TikTakToe.Core.Players {
    internal class AISingle : Player {
        public override int CalculateBestMove(Board board) {
            board.CalculateScore();

            if(board.Score < 1000 && board.Score > -1000) {
                bool reverse = Convert.ToBoolean(board.Move % 2);

                List<Board> moves = new List<Board>();
                List<int> scores = new List<int>();
                for(int i = 1; i < 10; i++) {

                    if(board.checkMove(i)) {
                        Board newboard = (Board)board.CloneReflection();
                        newboard.makeMoveO(i);
                        moves.Add(calculateBeta(newboard));
                        scores.Add(newboard.score);
                    }

                }
                if(scores.Count == 0) {
                    Console.WriteLine("This was a draw, want to play again?");
                    end = false;
                    return board;
                }
                int minimumValueIndex = scores.IndexOf(scores.Min());
                return moves[minimumValueIndex];
            }
            return board;
        }

        public override int CalculateNextMove(Board board) {
            throw new NotImplementedException();
        }
    }
}
