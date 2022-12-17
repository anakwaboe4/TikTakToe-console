using ConsoleApp1;
using System.Diagnostics;
using System.Xml;
using TikTakToe;

Console.WriteLine("Hello, welcome to my simple game. TikTakToe");
Stopwatch sw = new Stopwatch();
bool transpotable = true;
bool randommover = false;
while (true)
{
    bool reverse = false;
    Board currentboard = new Board();
    AI ai = new AI();
    AISingle aISingle = new AISingle();
    AIMulti aIMulti = new AIMulti();
    RandomAI rando = new RandomAI();
    AI benchai = new AI();
    AITransMulti aITransMulti = new AITransMulti();
    Console.WriteLine("if you want to open the menu at any time type 100");

    while (ai.end && aIMulti.end)
    {
        Console.WriteLine("please type a number that correspons with the square (or type 0 to let me make this move)");
        Console.WriteLine("|1|2|3|");
        Console.WriteLine("|4|5|6|");
        Console.WriteLine("|7|8|9|");
        try
        {
            int square = Convert.ToInt32(Console.ReadLine());
            if (square == 100)
            {
                Console.WriteLine("1: start a new game");
                if (transpotable) { Console.WriteLine("2: turn of the \"cheaty\" transpotable (makes it slower)"); }
                else { Console.WriteLine("2: turn on the \"cheaty\" transpotable"); }
                if (randommover) { Console.WriteLine("3: turn off the random move maker"); }
                else { Console.WriteLine("3: turn on the random move maker"); }
                Console.WriteLine("4: bench with singel treath calculation");
                Console.WriteLine("5: bench with parrallel calculation");
                Console.WriteLine("6: bench with transpotable");
                Console.WriteLine("7: bench with parrallel transpo calculation ");
                Console.WriteLine("8: full bench");
                Console.WriteLine("9: random move vs perfect ai");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        ai.end = false;
                        break;
                    case 2:
                        transpotable = !transpotable;
                        break;
                    case 3:
                        randommover= !randommover;
                        break;
                    case 6:
                        benchai = new AI();
                        sw.Restart();
                        sw.Start();
                        _ = benchai.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("Score:" + sw.ElapsedMilliseconds + "ms");
                        Console.WriteLine("now we do it again but see the power of transpo after startup");
                        sw.Restart();
                        sw.Start();
                        _ = benchai.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("Score:" + sw.ElapsedMilliseconds + "ms");
                        break;
                    case 5:
                        sw.Restart();
                        sw.Start();
                        _ = aIMulti.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("Score:" + sw.ElapsedMilliseconds + "ms");
                        break;
                    case 4:
                        sw.Restart();
                        sw.Start();
                        _ = aISingle.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("Score:" + sw.ElapsedMilliseconds + "ms");
                        break;
                    case 8:
                        Console.WriteLine("making the cores hot and ready");
                        _ = aIMulti.calculate(new Board());
                        Console.WriteLine("and go" + Environment.NewLine);
                        sw.Restart();
                        sw.Start();
                        _ = aISingle.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("TimesSingle: " + sw.ElapsedMilliseconds + "ms");
                        sw.Restart();
                        sw.Start();
                        _ = aIMulti.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("TimesMulti: " + sw.ElapsedMilliseconds + "ms");
                        sw.Restart();
                        sw.Start();
                        Board temp = benchai.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("TimesTranspo: " + sw.ElapsedMilliseconds + "ms");
                        sw.Restart();
                        sw.Start();
                        _ = aITransMulti.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("TimeMultiTranspo: " + sw.ElapsedMilliseconds + "ms");
                        //second move
                        Console.WriteLine(Environment.NewLine + "now for the following move:" + Environment.NewLine);
                        temp = benchai.calculateReverse(temp);
                        sw.Restart();
                        sw.Start();
                        _ = aISingle.calculate(temp);
                        sw.Stop();
                        Console.WriteLine("TimesSingle: " + sw.ElapsedMilliseconds + "ms");
                        sw.Restart();
                        sw.Start();
                        _ = aIMulti.calculate(temp);
                        sw.Stop();
                        Console.WriteLine("TimesMulti: " + sw.ElapsedMilliseconds + "ms");
                        sw.Restart();
                        sw.Start();
                        _ = benchai.calculate(temp);
                        sw.Stop();
                        Console.WriteLine("TimesTranspo: " + sw.ElapsedMilliseconds + "ms");
                        sw.Restart();
                        sw.Start();
                        _ = aITransMulti.calculate(temp);
                        sw.Stop();
                        Console.WriteLine("TimeMultiTranspo: " + sw.ElapsedMilliseconds + "ms");
                        //new game
                        Console.WriteLine(Environment.NewLine + "and with a new game:" + Environment.NewLine);
                        sw.Restart();
                        sw.Start();
                        _ = aISingle.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("TimesSingle: " + sw.ElapsedMilliseconds + "ms");
                        sw.Restart();
                        sw.Start();
                        _ = aIMulti.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("TimesMulti: " + sw.ElapsedMilliseconds + "ms");
                        sw.Restart();
                        sw.Start();
                        _ = benchai.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("TimesTranspo: " + sw.ElapsedMilliseconds + "ms");
                        sw.Restart();
                        sw.Start();
                        _ = aITransMulti.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("TimeMultiTranspo: " + sw.ElapsedMilliseconds + "ms");
                        break;

                    case 7:
                        aITransMulti = new AITransMulti();
                        sw.Restart();
                        sw.Start();
                        _ = aITransMulti.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("TimeMultiTranspo: " + sw.ElapsedMilliseconds + "ms");
                        break;
                    case 9:
                        rando = new RandomAI();
                        Board randoboard = new Board();
                        int wins = 0;
                        int loses = 0;
                        int gamesplayed = 100;
                        Console.WriteLine("How many games want you to be played");
                        gamesplayed = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < gamesplayed / 2; i++)
                        {
                            rando = new RandomAI();
                            benchai.end = true;
                            randoboard = new Board();
                            while (benchai.end && rando.end)
                            {

                                randoboard = rando.calculateReverse(randoboard);
                                WriteBoard(randoboard.boardState);
                                randoboard.checkscore();
                                if (randoboard.score == 1000)
                                {
                                    wins++;
                                    benchai.end = false;
                                }
                                if (randoboard.score == -1000)
                                {
                                    loses++;
                                    benchai.end = false;
                                }
                                if (!rando.end || !benchai.end)
                                {
                                    break;
                                }
                                randoboard = ai.calculate(randoboard);
                                WriteBoard(randoboard.boardState);
                                randoboard.checkscore();
                                if (randoboard.score == 1000)
                                {
                                    wins++;
                                    benchai.end = false;
                                }
                                if (randoboard.score == -1000)
                                {
                                    loses++;
                                    benchai.end = false;
                                }


                            }
                            rando = new RandomAI();
                            benchai.end = true;
                            randoboard = new Board();
                            Console.WriteLine("-------next game-------");
                            while (benchai.end && rando.end)
                            {
                                randoboard = ai.calculateReverse(randoboard);
                                WriteBoard(randoboard.boardState);
                                randoboard.checkscore();
                                if (randoboard.score == 1000)
                                {
                                    loses++;
                                    benchai.end = false;
                                }
                                if (randoboard.score == -1000)
                                {
                                    wins++;
                                    benchai.end = false;
                                }
                                if (!benchai.end)
                                {
                                    break;
                                }
                                randoboard = rando.calculate(randoboard);
                                WriteBoard(randoboard.boardState);
                                randoboard.checkscore();
                                if (randoboard.score == 1000)
                                {
                                    loses++;
                                    benchai.end = false;
                                }
                                if (randoboard.score == -1000)
                                {
                                    wins++;
                                    benchai.end = false;
                                }
                            }
                            Console.WriteLine("-------next game-------");

                        }
                        Console.WriteLine("total games: " + gamesplayed);
                        Console.WriteLine("wins: " + wins);
                        Console.WriteLine("losses: " + loses);
                        Console.WriteLine("draws: " + (gamesplayed - wins - loses));
                        Console.WriteLine("notloserate: " + ((gamesplayed - loses) * 100 / gamesplayed) + "%");
                        break;
                    default: throw new Exception("not valid");
                }

            }
            else if (square == 0)
            {
                if (!reverse)
                {
                    if (randommover) { currentboard = rando.calculateReverse(currentboard); }
                    else if (transpotable) { currentboard = ai.calculateReverse(currentboard); }
                    else { currentboard = aIMulti.calculateReverse(currentboard); }
                    WriteBoard(currentboard.boardState);
                    Console.WriteLine("the current score is: " + currentboard.score);
                    currentboard.checkscore();
                    if (currentboard.score == 1)
                    {
                        Console.WriteLine("I win this game, want to try again?");
                        ai.end = false;
                    }
                    if (currentboard.score == -1)
                    {
                        Console.WriteLine("You win this game, want to play again?");
                        ai.end = false;
                    }
                }
                else
                {
                    if (randommover) { currentboard = rando.calculate(currentboard); }
                    else if (transpotable) { currentboard = ai.calculate(currentboard); }
                    else { currentboard = aIMulti.calculate(currentboard); }
                    WriteBoard(currentboard.boardState);
                    Console.WriteLine("the current score is: " + currentboard.score);
                    currentboard.checkscore();
                    if (currentboard.score == 1)
                    {
                        Console.WriteLine("You win this game, want to play again?");
                        ai.end = false;
                    }
                    if (currentboard.score == -1)
                    {
                        Console.WriteLine("I win this game, want to try again?");
                        ai.end = false;
                    }
                }
                reverse = !reverse;
            }
            else if (!reverse)
            {
                if (currentboard.checkMove(square))
                {
                    currentboard.makeMove(square);
                    WriteBoard(currentboard.boardState);
                    if (randommover) { currentboard = rando.calculate(currentboard); }
                    else if (transpotable) { currentboard = ai.calculate(currentboard); }
                    else { currentboard = aIMulti.calculate(currentboard); }
                    WriteBoard(currentboard.boardState);
                    Console.WriteLine("the current score is: " + currentboard.score);
                    currentboard.checkscore();
                    if (currentboard.score == 1000)
                    {
                        Console.WriteLine("You win this game, want to play again?");
                        ai.end = false;
                    }
                    if (currentboard.score == -1000)
                    {
                        Console.WriteLine("I win this game, want to try again?");
                        ai.end = false;
                    }
                }
                else
                {
                    Console.WriteLine("that is an illegal move, try again");
                }
            }
            else
            {
                if (currentboard.checkMove(square))
                {
                    currentboard.makeMoveO(square);
                    WriteBoard(currentboard.boardState);
                    if (randommover) { currentboard = rando.calculateReverse(currentboard); }
                    else if (transpotable) { currentboard = ai.calculateReverse(currentboard); }
                    else { currentboard = aIMulti.calculateReverse(currentboard); }
                    WriteBoard(currentboard.boardState);
                    Console.WriteLine("the current score is: " + currentboard.score);
                    currentboard.checkscore();
                    if (currentboard.score == 1000)
                    {
                        Console.WriteLine("I win this game, want to try again?");
                        ai.end = false;
                    }
                    if (currentboard.score == -1000)
                    {
                        Console.WriteLine("You win this game, want to play again?");
                        ai.end = false;
                    }
                }
                else
                {
                    Console.WriteLine("that is an illegal move, try again");
                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("That is not a allowed number :( ");
            //Console.WriteLine(e.Message);
        }

    }
}


static void WriteBoard(int[] arr)
{
    int Length = arr.GetLength(0);

    for (int i = 0; i < Length; i++)
    {
        Console.Write("|");
        if (arr[i] == 0) Console.Write(" ");
        if (arr[i] == 1) Console.Write("X");
        if (arr[i] == 2) Console.Write("O");
        if (i %3 == 0)
        {
            Console.WriteLine("|");
        }

    }
    Console.Write(Environment.NewLine);


}

