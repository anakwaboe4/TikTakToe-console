using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Board 
    {
        public int[] boardState;
        public int score = 0;
        
        public Board()
        {
            boardState = new int[9];
            score = 0;
            
        }

        public Board(int[] boardState, int score)
        {
            this.boardState = boardState;
            this.score = score;
        }

        public bool checkMove(int square)
        {
            if (boardState[square-1] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void makeMove(int square)
        {
            boardState[square-1] = 1;
        }
        public void makeMoveO(int square)
        {
            int x = (square - 1) / 3;
            int y = (square - 1) % 3;
            boardState[square -1] = 2;
        }
        public void checkscore()
        {
            score = 0;
            if (boardState[4] == 1) //quick middlecheck for effectient updating 
            {
                if(boardState[8] == 1 && boardState[0] == 1) { score = 1000; return; }
                else if(boardState[2] == 1 && boardState[6] == 1) {score = 1000; return; }
                else if (boardState[3] == 1 && boardState[5] == 1) { score = 1000; return; }
                else if (boardState[1] == 1 && boardState[7] == 1) { score = 1000; return; }

            }
            else if (boardState[4] == 2)
            {
                if (boardState[8] == 2 && boardState[0] == 2) { score = -1000; return; }
                else if (boardState[2] == 2 && boardState[6] == 2) { score = -1000; return; }
                else if (boardState[3] == 2 && boardState[5] == 2) { score = -1000; return; }
                else if (boardState[1] == 2 && boardState[7] == 2) { score = -1000; return; }

            }
            if(boardState[0] == 1 && boardState[1] == 1 && boardState[2] == 1) { score = 1000; return; }
            if (boardState[6] == 1 && boardState[7] == 1 && boardState[8] == 1) { score = 1000; return; }
            if (boardState[0] == 2 && boardState[1] == 2 && boardState[2] == 2) { score = -1000; return; }
            if (boardState[6] == 2 && boardState[7] == 2 && boardState[8] == 2) { score = -1000; return; }
            //check logic again
            if (boardState[0] == 1 && boardState[3] == 1 && boardState[6] == 1) { score = 1000; return; }
            if (boardState[2] == 1 && boardState[5] == 1 && boardState[8] == 1) { score = 1000; return; }
            if (boardState[0] == 2 && boardState[3] == 2 && boardState[6] == 2) { score = -1000; return; }
            if (boardState[2] == 2 && boardState[5] == 2 && boardState[8] == 2) { score = -1000; return; }
        }
        public Board Clone()
        {
            Board board = new Board();
            for (int i = 0; i < boardState.Length; i++)
            {
                board.boardState[i] = boardState[i];
            }
            return board;

        }

        public int Valcheck(Board obj)
        {
            for (int i = 0; i < 9; i++) {
                if (boardState[i] != obj.boardState[i])
                {
                    return 5000;
                }
                
            }
            return score;
        }
    }
}
