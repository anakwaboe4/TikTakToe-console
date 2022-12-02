using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    class Board : ICloneable
    {
        public int[,] boardState;
        public int score = 0;
        
        public Board()
        {
            boardState = new int[3,3];
            score = 0;
            
        }

        public Board(int[,] boardState, int score)
        {
            this.boardState = boardState;
            this.score = score;
        }

        public bool checkMove(int square)
        {
            int x = Convert.ToInt32(Math.Floor((double)(square -1) / 3));
            int y = (square -1) % 3;
            if (boardState[x,y] == 0)
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
            int x = Convert.ToInt32(Math.Floor((double)(square -1) / 3));
            int y = (square -1) % 3;
            boardState[x, y] = 1;
        }
        public void makeMoveO(int square)
        {
            int x = Convert.ToInt32(Math.Floor((double)(square - 1) / 3));
            int y = (square - 1) % 3;
            boardState[x, y] = 2;
        }
        public void checkscore()
        {
            score = 0;
            if (boardState[1,1] == 1) //quick middlecheck for effectient updating 
            {
                if(boardState[2,2] == 1 && boardState[0,0] == 1) { score = 1; }
                else if(boardState[0,2] == 1 && boardState[2,0] == 1) {score = 1; }
                else if (boardState[1,0] == 1 && boardState[1,2] == 1) { score = 1; }
                else if (boardState[0, 1] == 1 && boardState[2, 1] == 1) { score = 1; }

            }
            else if (boardState[1, 1] == 2)
            {
                if (boardState[2, 2] == 2 && boardState[0, 0] == 2) { score = -1; }
                else if (boardState[0, 2] == 2 && boardState[2, 0] == 2) { score = -1; }
                else if (boardState[1, 0] == 2 && boardState[1, 2] == 2) { score = -1; }
                else if (boardState[0, 1] == 2 && boardState[2, 1] == 2) { score = -1; }

            }
            if(boardState[0,0] == 1 && boardState[0, 1] == 1 && boardState[0, 2] == 1) { score = 1; }
            if (boardState[2, 0] == 1 && boardState[2, 1] == 1 && boardState[2, 2] == 1) { score = 1; }
            if (boardState[0, 0] == 2 && boardState[0, 1] == 2 && boardState[0, 2] == 2) { score = -1; }
            if (boardState[2, 0] == 2 && boardState[2, 1] == 2 && boardState[2, 2] == 2) { score = -1; }
            //check logic again
            if (boardState[0, 0] == 1 && boardState[1, 0] == 1 && boardState[2, 0] == 1) { score = 1; }
            if (boardState[0, 2] == 1 && boardState[1, 2] == 1 && boardState[2, 2] == 1) { score = 1; }
            if (boardState[0, 0] == 2 && boardState[1, 0] == 2 && boardState[2, 0] == 2) { score = -1; }
            if (boardState[0, 2] == 2 && boardState[1, 2] == 2 && boardState[2, 2] == 2) { score = -1; }
            // give some points for 2 in a row with a 0 in them
            
        }
        public object Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }
                return 0;
            }
        }

        public int Valcheck(Board obj)
        {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++)
                {
                    if (boardState[i, j] != obj.boardState[i, j])
                    {
                        return 5;
                    }

                }
            }
            return score;
        }
    }
}
