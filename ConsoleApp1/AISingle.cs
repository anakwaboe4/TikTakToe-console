using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace ConsoleApp1
{
    class AISingle
    {
        public bool end;
        public int score;
        bool reverse = false;
        public AISingle()
        {
            end = true;
            score = 0;
        }

        public Board calculate(Board board)
        {
            board.checkscore();
            if (board.score < 1000 && board.score > -1000)
            {
                reverse = false;
                List<Board> moves = new List<Board>();
                for(int i = 1; i < 10; i++)
                {

                    if (board.checkMove(i))
                    {
                        Board newboard = (Board)board.Clone();
                        newboard.makeMoveO(i);
                        moves.Add(calculateBeta(newboard));
                    }

                }
                List<int> scores = new List<int>();
                foreach (Board board1 in moves)
                {
                    scores.Add(board1.score);
                }
                if (scores.Count == 0)
                {
                    Console.WriteLine("This was a draw, want to play again?");
                    end = false;
                    return board;
                }
                int minimumValueIndex = scores.IndexOf(scores.Min());
                return moves[minimumValueIndex];
            }
            return board;
        }
        public Board calculateReverse(Board board)
        {
            board.checkscore();
            if (board.score < 1000 && board.score > -1000)
            {
                List<Board> moves = new List<Board>();
                for (int i = 1; i < 10; i++)
                {
                    reverse = true;
                    if (board.checkMove(i))
                    {
                        Board newboard = (Board)board.Clone();
                        newboard.makeMove(i);
                        moves.Add(calculateAlfa(newboard));
                    }

                }
                List<int> scores = new List<int>();
                foreach (Board board1 in moves)
                {
                    scores.Add(board1.score);
                }
                if (scores.Count == 0)
                {
                    Console.WriteLine("This was a draw, want to play again?");
                    end = false;
                    return board;
                }
                int minimumValueIndex = scores.IndexOf(scores.Max());
                return moves[minimumValueIndex];
            }
            return board;
        }
        public Board calculateBeta(Board board)
        {
            board.checkscore();
            if (board.score < 1000 && board.score > -1000)
            {
                List<int> scores = new List<int>();
                for (int i = 1; i < 10; i++)
                {

                    if (board.checkMove(i))
                    {
                        Board newboard = (Board)board.Clone();
                        newboard.makeMove(i);
                        scores.Add(calculateAlfa(newboard).score);
                    }
                }
                if (scores.Count == 0)
                {
                    return board;
                }
                board.score = scores.Max();
                if (!reverse && board.score != 1000)
                {
                    board.score = scores.Sum() / scores.Count();
                }

            }
            return board;
        }
        public Board calculateAlfa(Board board)
        {
            board.checkscore();
            if (board.score < 1000 && board.score > -1000)
            {
                List<int> scores = new List<int>();
                for (int i = 1; i < 10; i++)
                {
                    if (board.checkMove(i))
                    {
                        Board newboard = (Board)board.Clone();
                        newboard.makeMoveO(i);
                        scores.Add(calculateBeta(newboard).score);
                    }
                }
                if (scores.Count == 0)
                {
                    return board;
                }
                board.score = scores.Min();
                if (reverse && board.score != -1000)
                {
                    board.score = scores.Sum() / scores.Count();
                }

            }
            return board;
        }

    }
}
