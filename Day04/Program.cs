// Advent of code 2021
// Day04
// solution by Karol Karpierz

using BusinessLogic;
using BusinessLogic.FileDataMgmt;
using Day04;

Console.WriteLine("Advent of code - day 04\n*******************\n");

// getting data from file
Console.WriteLine("Getting File Data");
Invoker invoker = new Invoker();
var fileCommand = new FileLinesExtractCommand("day04Board");
invoker.SetOnStart(fileCommand);
invoker.FileDataLines();

List<string> boardData = fileCommand.DataLines;

string commandForBingo = "25,8,32,53,22,94,55,80,33,4,63,14,60,95,31,89,30,5,47,66,84,70,17,74,99,82,21,35,64,2,76,9,90,56,78,28,51,86,49,98,29,96,23,58,52,75,41,50,13,72,92,83,62,37,18,11,34,71,91,85,27,12,24,73,7,77,10,93,15,61,3,46,16,97,1,57,65,40,0,48,69,6,20,68,19,45,42,79,88,44,26,38,36,54,81,59,43,87,39,67";

// part 1, 2

BingoGraphsRepository bingoGraphs = new(boardData, commandForBingo);
bingoGraphs.StartBingoGame();

Console.ReadKey();


