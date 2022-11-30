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
        public string[,] boardState;
        public int score = 0;
        
        public Board()
        {
            boardState = new string[3,3];
            score = 0;
            
        }

        public Board(string[,] boardState, int score)
        {
            this.boardState = boardState;
            this.score = score;
        }

        public bool checkMove(int square)
        {
            int x = Convert.ToInt32(Math.Floor((double)(square -1) / 3));
            int y = (square -1) % 3;
            if (boardState[x,y] == null)
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
            boardState[x, y] = "X";
        }
        public void makeMoveO(int square)
        {
            int x = Convert.ToInt32(Math.Floor((double)(square - 1) / 3));
            int y = (square - 1) % 3;
            boardState[x, y] = "O";
        }
        public void checkscore()
        {
            score = 0;
            if (boardState[1,1] == "X") //quick middlecheck for effectient updating 
            {
                if(boardState[2,2] == "X" && boardState[0,0] == "X") { score = 1; }
                else if(boardState[0,2] == "X" && boardState[2,0] == "X") {score = 1; }
                else if (boardState[1,0] == "X" && boardState[1,2] == "X") { score = 1; }
                else if (boardState[0, 1] == "X" && boardState[2, 1] == "X") { score = 1; }

            }
            else if (boardState[1, 1] == "O")
            {
                if (boardState[2, 2] == "O" && boardState[0, 0] == "O") { score = -1; }
                else if (boardState[0, 2] == "O" && boardState[2, 0] == "O") { score = -1; }
                else if (boardState[1, 0] == "O" && boardState[1, 2] == "O") { score = -1; }
                else if (boardState[0, 1] == "O" && boardState[2, 1] == "O") { score = -1; }

            }
            if(boardState[0,0] == "X" && boardState[0, 1] == "X" && boardState[0, 2] == "X") { score = 1; }
            if (boardState[2, 0] == "X" && boardState[2, 1] == "X" && boardState[2, 2] == "X") { score = 1; }
            if (boardState[0, 0] == "O" && boardState[0, 1] == "O" && boardState[0, 2] == "O") { score = -1; }
            if (boardState[2, 0] == "O" && boardState[2, 1] == "O" && boardState[2, 2] == "O") { score = -1; }
            //check logic again
            if (boardState[0, 0] == "X" && boardState[1, 0] == "X" && boardState[2, 0] == "X") { score = 1; }
            if (boardState[0, 2] == "X" && boardState[1, 2] == "X" && boardState[2, 2] == "X") { score = 1; }
            if (boardState[0, 0] == "O" && boardState[1, 0] == "O" && boardState[2, 0] == "O") { score = 1; }
            if (boardState[0, 2] == "O" && boardState[1, 2] == "O" && boardState[2, 2] == "O") { score = 1; }
            // give some points for 2 in a row with a null in them
            
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
                return null;
            }
        }
    }
}
