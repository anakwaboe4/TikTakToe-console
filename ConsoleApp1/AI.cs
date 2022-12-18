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
    class AI
    {
        public bool end;
        public int score;
        public List<Board> transpotable = new List<Board>();
        bool reverse = false;
        public AI()
        {
            end = true;
            score = 0;
            transpotable = new List<Board>();
            
        }

        public Board calculate(Board board)
        {
            
            board.checkscore();
            if (board.score < 1000 && board.score > -1000)
            {
                reverse = false;
                List<Board> moves = new List<Board>();
                List<int> scores = new List<int>();
                for (int i = 1; i < 10; i++)
                {

                    if (board.checkMove(i))
                    {
                        Board newboard = (Board)board.CloneReflection();
                        newboard.makeMoveO(i);
                        moves.Add(calculateBeta(newboard));
                        scores.Add(newboard.score);
                    }

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
                reverse = true;
                List<Board> moves = new List<Board>();
                List<int> scores = new List<int>();
                for (int i = 1; i < 10; i++)
                {

                    if (board.checkMove(i))
                    {
                        Board newboard = (Board)board.CloneReflection();
                        newboard.makeMove(i);
                        moves.Add(calculateAlfa(newboard));
                        scores.Add(newboard.score);
                    }

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
                foreach (Board board1 in transpotable)
                {
                    int score = board1.Valcheck(board);
                    if (score != 5000)
                    {
                        board.score = score;
                        return board;
                    }
                }
                List<int> scores = new List<int>();
                for (int i = 1; i < 10; i++)
                {

                    if (board.checkMove(i))
                    {
                        Board newboard = (Board)board.CloneReflection();
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
            transpotable.Add(board);
            return board;
        }
        public Board calculateAlfa(Board board)
        {
            board.checkscore();
            if (board.score < 1000 && board.score > -1000)
            {
                foreach (Board board1 in transpotable)
                {
                    int score = board1.Valcheck(board);
                    if (score != 5000)
                    {
                        board.score = score;
                        return board;
                    }
                }
                List<int> scores = new List<int>();
                for (int i = 1; i < 10; i++)
                {
                    if (board.checkMove(i))
                    {
                        Board newboard = (Board)board.CloneReflection();
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
                    board.score = scores.Sum()/ scores.Count();
                }
                


            }
            transpotable.Add(board);
            return board;
        }
    }
}
