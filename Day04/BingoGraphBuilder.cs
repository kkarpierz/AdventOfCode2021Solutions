using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    public class BingoGraphBuilder : IBingoGraphBuilder
    {
        private BingoGraph _bingoGraph = new();

        public BingoGraphBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _bingoGraph = new();
        }

        public void BuildBingoGraphTable(List<string> matrixData)
        {
            _bingoGraph.FillMatrix(matrixData);
        }

        public BingoGraph BingoGraph { get => _bingoGraph; }

    }
}
