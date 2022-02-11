// Advent of code 2021
// Day05
// solution by Karol Karpierz

using BusinessLogic;
using BusinessLogic.FileDataMgmt;
using Day05;
using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Advent of code - day 05\n*******************\n");

// getting data from file
Console.WriteLine("Getting File Data");
Invoker invoker = new Invoker();
var fileCommand = new FileLinesExtractCommand("day05");
invoker.SetOnStart(fileCommand);
invoker.FileDataLines();

List<string> dataInText = fileCommand.DataLines;

List<Line> lines = new();
string[] separator = { ",", " -> " };
foreach (var line in dataInText) {
    var lineInfo = line.Split(separator, 4, StringSplitOptions.RemoveEmptyEntries);

    if (lineInfo.Count() == 4)
        lines.Add(new Line(new Point(short.Parse(lineInfo[0]), short.Parse(lineInfo[1])), new Point(short.Parse(lineInfo[2]), short.Parse(lineInfo[3]))));
}

Area area = new(lines);

// part2 (for part 1 - comment diagonal in area class
Console.WriteLine("Points where line crossing more than once: " + area.CountResult());

int w = 0;

Console.ReadKey();