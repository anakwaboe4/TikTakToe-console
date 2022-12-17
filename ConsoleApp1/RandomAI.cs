using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    internal class RandomAI
    {
        public bool end;
        Random random = new Random();
        public RandomAI()
        {
            end = true;
        }

        public Board calculate(Board board)
        {
            board.checkscore();
            if (board.score < 1000 && board.score > -1000)
            {
                List<Board> moves = new List<Board>();
                for (int i = 1; i < 10; i++)
                {

                    if (board.checkMove(i))
                    {
                        Board newboard = (Board)board.Clone();
                        newboard.makeMoveO(i);
                        moves.Add(newboard);
                    }

                }
                if(moves.Count == 0)
                {
                    end = false;
                    return board;

                }
               
                return moves[random.Next(0,moves.Count())];
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

                    if (board.checkMove(i))
                    {
                        Board newboard = (Board)board.Clone();
                        newboard.makeMove(i);
                        moves.Add(newboard);
                    }

                }
                if (moves.Count == 0)
                {
                    end = false;
                    return board;
                }
                
                return moves[random.Next(0, moves.Count())];
            }
            return board;
        }
    }
    }
