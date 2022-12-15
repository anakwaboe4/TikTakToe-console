﻿using ConsoleApp1;
using System.Diagnostics;
using System.Xml;
using TikTakToe;

Console.WriteLine("Hello, welcome to my simple game. TikTakToe");
Stopwatch sw = new Stopwatch();
bool transpotable = true;
while (true)
{
    bool reverse = false;
    Board currentboard = new Board();
    AI ai = new AI();
    AISingle aISingle = new AISingle();
    AIMulti aIMulti = new AIMulti();
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
                Console.WriteLine("3: bench with transpotable");
                Console.WriteLine("4: bench with parrallel calculation");
                Console.WriteLine("5: bench with singel treath calculation");
                Console.WriteLine("6: full benchmark");
                Console.WriteLine("7: bench with parrallel transpo calculation (failed ai)");
                Console.WriteLine("8: random move vs perfect ai");
                int option = Convert.ToInt32(Console.ReadLine());
                AI benchai = new AI();
                switch (option)
                {
                    case 1:
                        ai.end = false;
                        break;
                    case 2:
                        transpotable = !transpotable;
                        break;
                    case 3:
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
                    case 4:
                        sw.Restart();
                        sw.Start();
                        _ = aIMulti.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("Score:" + sw.ElapsedMilliseconds + "ms");
                        break;
                    case 5:
                        sw.Restart();
                        sw.Start();
                        _ = aISingle.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("Score:" + sw.ElapsedMilliseconds + "ms");
                        break;
                    case 6:
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
                        Console.WriteLine(Environment.NewLine + "and with a new game:" + Environment.NewLine);
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
                        break;
                    case 7:
                        AITransMulti aITransMulti = new AITransMulti();
                        sw.Restart();
                        sw.Start();
                        _ = aITransMulti.calculate(new Board());
                        sw.Stop();
                        Console.WriteLine("TimeMultiTranspo: " + sw.ElapsedMilliseconds + "ms");
                        break;
                    case 8:
                        RandomAI rando = new RandomAI();
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
                                if (randoboard.score == 10)
                                {
                                    wins++;
                                    benchai.end = false;
                                }
                                if (randoboard.score == -10)
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
                                if (randoboard.score == 10)
                                {
                                    wins++;
                                    benchai.end = false;
                                }
                                if (randoboard.score == -10)
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
                                if (randoboard.score == 10)
                                {
                                    loses++;
                                    benchai.end = false;
                                }
                                if (randoboard.score == -10)
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
                                if (randoboard.score == 10)
                                {
                                    loses++;
                                    benchai.end = false;
                                }
                                if (randoboard.score == -10)
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
                    if (transpotable) { currentboard = ai.calculateReverse(currentboard); }
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
                    if (transpotable) { currentboard = ai.calculate(currentboard); }
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
                    if (transpotable) { currentboard = ai.calculate(currentboard); }
                    else { currentboard = aIMulti.calculate(currentboard); }
                    WriteBoard(currentboard.boardState);
                    Console.WriteLine("the current score is: " + currentboard.score);
                    currentboard.checkscore();
                    if (currentboard.score == 10)
                    {
                        Console.WriteLine("You win this game, want to play again?");
                        ai.end = false;
                    }
                    if (currentboard.score == -10)
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
                    if (transpotable) { currentboard = ai.calculateReverse(currentboard); }
                    else { currentboard = aIMulti.calculateReverse(currentboard); }
                    WriteBoard(currentboard.boardState);
                    Console.WriteLine("the current score is: " + currentboard.score);
                    currentboard.checkscore();
                    if (currentboard.score == 10)
                    {
                        Console.WriteLine("I win this game, want to try again?");
                        ai.end = false;
                    }
                    if (currentboard.score == -10)
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


static void WriteBoard(int[,] arr)
{
    int rowLength = arr.GetLength(0);
    int colLength = arr.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        Console.Write("|");
        for (int j = 0; j < colLength; j++)
        {
            if (arr[i, j] == 0) Console.Write(" ");
            if (arr[i, j] == 1) Console.Write("X");
            if (arr[i, j] == 2) Console.Write("O");
            Console.Write("|");
        }
        Console.Write(Environment.NewLine);
    }
    Console.Write(Environment.NewLine);


}

