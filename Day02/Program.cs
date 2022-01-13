// Advent of code 2021
// Day02
// solution by Karol Karpierz


using Day02;
using System.Linq;

int counter = 0;
var instructions = new List<string>();


// Read the file and display it line by line.  
foreach (string line in System.IO.File.ReadLines(@"..\..\..\instructionMovement.txt"))
{
    instructions.Add(line);
    counter++;
}

// part1
var position = new Position();

foreach (var instruction in instructions)
{
    position.Move(instruction);
}

// part1 result
Console.WriteLine("Result:" + position.calculateResult());

// part2

var positionForAim = new Position();

foreach (var instruction in instructions)
{
    positionForAim.MoveWithAim(instruction);
}

// part2 result
Console.WriteLine("Result:" + positionForAim.calculateResult());