// Advent of code 2021
// Day03
// solution by Karol Karpierz

using BusinessLogic;
using BusinessLogic.FileDataMgmt;
using Day03;

Console.WriteLine("Advent of code - day 03\n*******************\n");

Console.WriteLine("Getting File Data");
Invoker invoker = new Invoker();
var fileCommand = new FileLinesExtractCommand("day03");
invoker.SetOnStart(fileCommand);
invoker.FileDataLines();

List<string> data = fileCommand.DataLines;

// part1
var GammaCalculate = new GammaCountCommand(data);
var gammaResult = GammaCalculate.CalculateGamma();
var epsilonResult = GammaCalculate.CalculateEpsilon();



Console.WriteLine("Results: gamma = " + gammaResult + " | epsilon = " + epsilonResult);

// then multiply it by yourself :)