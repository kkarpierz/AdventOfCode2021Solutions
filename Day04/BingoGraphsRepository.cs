using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    public class BingoGraphsRepository
    {
        private List<string> _boardData;
        private string _bingoNumbersToType;
        private List<List<string>> _bingoDataSaved;
        private List<BingoGraph> _bingoGraphs;
        private List<int> _bingoNumbers;

        public BingoGraphsRepository(List<string> boardData, string bingoNumbersToType)
        {
            _boardData = boardData;
            _bingoNumbersToType = bingoNumbersToType;
            _bingoDataSaved = new();
            _bingoGraphs = new();
            _bingoNumbers = new();
        }

        private void SplitTextIntoSeparateBoards()
        {
            // split text data into separate boards
            List<List<string>> bingoDataSaved = new();
            List<string> tempSingleBingoBoard = new();

            foreach (var board in _boardData)
            {
                if (board == string.Empty)
                {
                    bingoDataSaved.Add(tempSingleBingoBoard);
                    tempSingleBingoBoard = new();
                    continue;
                }

                tempSingleBingoBoard.Add(board);
            }

            _bingoDataSaved = bingoDataSaved;
        }

        private void ConvertTextIntoGraphs()
        {
            List<BingoGraph> bingoGraphs = new();

            foreach (var board in _bingoDataSaved)
            {
                BingoGraphDirector bingoDirector = new();
                BingoGraphBuilder bingoGraphBuilder = new();
                bingoDirector.BuildingoGraphBuilder = bingoGraphBuilder;

                bingoDirector.BuildBingoGraphWithFilledMatrix(board);

                bingoGraphs.Add(bingoGraphBuilder.BingoGraph);
            }

            _bingoGraphs = bingoGraphs;
        }

        private void ConvertTypedNumbersIntoList()
        {
            _bingoNumbers = _bingoNumbersToType.Split(',').Select(int.Parse).ToList();
        }

        private void IterateThroughNumbersAndCheckResults()
        {
            bool firstResultIsSet = false;
            bool lastResultIsSet = false;
            int lastNumber = 0;

            List<BingoGraph> bingoGraphsWithoutSolutionYet = new();
            foreach(var tempBingoGraph in _bingoGraphs)
            {
                bingoGraphsWithoutSolutionYet.Add(new BingoGraph(tempBingoGraph));
            }

            foreach (var number in _bingoNumbers)
            {
                foreach(var bingoGraph in _bingoGraphs)
                {
                    bingoGraph.FindNumberInMatrix(number);
                    if (bingoGraph.FindBingoCombination())
                    {
                        if (!firstResultIsSet)
                        {
                            Console.WriteLine("\nPart1 solution | Final Result after multiplying not mentioned elements in row and current number: " +
                                bingoGraph.MultiplyOfRowAndNumberResult());
                            firstResultIsSet = true;
                        }

                        bingoGraphsWithoutSolutionYet.RemoveAll(x => x.Matrix == bingoGraph.Matrix);
                        lastNumber = number;
                        if (bingoGraphsWithoutSolutionYet.Count() == 1)
                        {
                            lastResultIsSet = true;
                            break;
                        }
                    }
                }
                if (lastResultIsSet)
                  break;
            }

            if (lastResultIsSet && bingoGraphsWithoutSolutionYet.Count == 1)
            {
                var lastResult = bingoGraphsWithoutSolutionYet.FirstOrDefault().MultiplyUnmarkedNumsUntilConcreteOne(_bingoNumbers, lastNumber);
                Console.WriteLine("\nPart2 solution: " + lastResult); // part2 solution
            }

            if (!firstResultIsSet || !lastResultIsSet)
                Console.WriteLine("Cannot find any result");

        }

        public void StartBingoGame()
        {
            SplitTextIntoSeparateBoards();
            ConvertTextIntoGraphs();
            ConvertTypedNumbersIntoList();

            Console.WriteLine("Part1, Part2");
            IterateThroughNumbersAndCheckResults();
        }

    }
}
