using ConsoleApp1;
using System.Xml;

Console.WriteLine("Hello, welcome to my simple game. TikTakToe");
while (true)
{
    Board currentboard = new Board();
    AI ai = new AI();

    while (ai.end)
    {
        Console.WriteLine("please type a number that correspons with the square");
        Console.WriteLine("|1|2|3|");
        Console.WriteLine("|4|5|6|");
        Console.WriteLine("|7|8|9|");
        try
        {
            int square = Convert.ToInt32(Console.ReadLine());
            if (currentboard.checkMove(square))
            {
                currentboard.makeMove(square);
                WriteBoard(currentboard.boardState);
                currentboard = ai.calculate(currentboard);
                WriteBoard(currentboard.boardState);
                Console.WriteLine("the current score is: " + currentboard.score);
                currentboard.checkscore();
                if (currentboard.score == 1)
                {
                    Console.WriteLine("You win this game, want to play again");
                    ai.end = false;
                }
                if (currentboard.score == -1)
                {
                    Console.WriteLine("I win this game, want to try again");
                    ai.end = false;
                }
            }
            else
            {
                Console.WriteLine("that is an illegal move, try again");
            }
        }
        catch(Exception e) { Console.WriteLine("That is not a allowed number :( "); }
        
    }
}


static void WriteBoard(string[,] arr)
{
    int rowLength = arr.GetLength(0);
    int colLength = arr.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        Console.Write("|");
        for (int j = 0; j < colLength; j++)
        {
            if (arr[i, j] == null) Console.Write(" ");
            else Console.Write(arr[i, j]);
            Console.Write("|");
        }
        Console.Write(Environment.NewLine + Environment.NewLine);
    }
    

}

