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
            BingoGraph bingoGraphWithResult = new();
            bool resultIsSet = false;
            int result;

            foreach (var number in _bingoNumbers)
            {
                foreach(var bingoGraph in _bingoGraphs)
                {
                    bingoGraph.FindNumberInMatrix(number);
                    if (bingoGraph.FindBingoCombination())
                    {
                        result = bingoGraph.MultiplyOfRowAndNumberResult();
                        bingoGraphWithResult = bingoGraph;
                        resultIsSet = true;
                        Console.WriteLine("\nFinal Result after multiplying sum of elements in row and current number: " + result);
                        break;
                    }
                }
                if (resultIsSet)
                    break;
            }

            if (!resultIsSet)
                Console.WriteLine("Cannot find result");

        }

        public void StartBingoGame()
        {
            SplitTextIntoSeparateBoards();
            ConvertTextIntoGraphs();
            ConvertTypedNumbersIntoList();
            IterateThroughNumbersAndCheckResults();
        }

    }
}
