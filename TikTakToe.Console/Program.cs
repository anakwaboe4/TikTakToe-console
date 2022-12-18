using System.Diagnostics;
using TikTakToe.Core.Boards;
using TikTakToe.Core.Helpers;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var boards = new Board[1000];
var newBoards = new Board[1000];

for(int i = 0; i < 1000; i++) {
    boards[i] = new Board();
}

var stopwatch = new Stopwatch();
stopwatch.Start();

for(int i = 0; i < 1000; i++) {
    newBoards[i] = boards[i].DeepCloneByReflection();
}
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);

newBoards = new Board[1000];
stopwatch.Restart();
for(int i = 0; i < 3; i++) {
    newBoards[i] = boards[i].DeepCloneBySerialization();
}
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);

newBoards = new Board[1000];
stopwatch.Restart();
for(int i = 0; i < 3; i++) {
    newBoards[i] = boards[i].DeepCloneByCopy();
}
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
