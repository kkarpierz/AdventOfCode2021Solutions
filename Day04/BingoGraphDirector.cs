using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    public class BingoGraphDirector
    {
        private IBingoGraphBuilder _buildingoGraphBuilder;

        public IBingoGraphBuilder BuildingoGraphBuilder { set => _buildingoGraphBuilder = value; }

        public void BuildBingoGraphWithFilledMatrix(List<string> bingoMatrix)
        {
            _buildingoGraphBuilder.BuildBingoGraphTable(bingoMatrix);
        }
    }
}
