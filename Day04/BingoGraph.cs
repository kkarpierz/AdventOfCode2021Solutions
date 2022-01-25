using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    public class BingoGraph
    {
        private List<List<int>> _matrix = new();
        private List<int> _foundNumbers = new();
        private List<int> _foundBingoLine = new();

        public void FillMatrix(List<string> matrixData)
        {
            List<List<int>> tempMatrix = new();
            int rowsCount = matrixData.Count;

            foreach(var elementRow in matrixData)
            {
                var cells = elementRow.Split(' ').ToList().Where(x => x != string.Empty);
                List<int> tempRow = new();

                foreach (var cell in cells)
                    tempRow.Add(int.Parse(cell));

                tempMatrix.Add(tempRow);
            }

            if (CheckIfMatrixHasSquareDimensions(tempMatrix))
                _matrix = tempMatrix;
            else
                throw new Exception("This matrix should contain the same amount of columns as rows");
        }

        public void FindNumberInMatrix(int number)
        {
            foreach (var row in _matrix)
            {
                if (row.Contains(number))
                {
                    _foundNumbers.Add(number);
                    break;
                }
            }
        }

        public bool FindBingoCombination()
        {
            if (!CheckIfMatrixHasSquareDimensions(_matrix))
                throw new Exception("This matrix should contain the same amount of columns as rows");

            if (_foundNumbers.Count < _matrix.Count)
                return false; // not enough found numbers for a bingo

            // find horizontally
            foreach (var row in _matrix)
            {
                if (row.Intersect(_foundNumbers).ToList().Count() == row.Count()) // be aware if distinct is needed here also
                {
                    _foundBingoLine = row;
                    return true;
                }
            }

            // find vertically
            for (int i = 0; i < _matrix.ElementAt(0).Count; i++)
            {
                List<int> column = new();

                foreach (var cell in _matrix.ElementAt(i))
                    column.Add(cell);

                // think of extracting of this below
                // be aware if distinct is needed here also
                if (column.Intersect(_foundNumbers).ToList().Count() == column.Count()) 
                {
                    _foundBingoLine = column;
                    return true;
                }
            }

            return false;
        }

        private bool CheckIfMatrixHasSquareDimensions(List<List<int>> matrix)
        {
            // Matrix cannot be empty
            if (matrix.Count == 0)
                return false;

            foreach (var row in matrix)
                // This matrix should contain the same amount of columns as rows
                if (row.Count != matrix.Count)
                    return false;

            return true;
        }

        //sum of all unmarked numbers * curent
        public int MultiplyOfRowAndNumberResult()
        {
            if (_foundBingoLine == null)
                throw new Exception("Bingo line not found yet.");

            int sumOfElementsNotFound = 0;

            foreach(var row in _matrix)
                sumOfElementsNotFound += row.Where(x => !_foundNumbers.Contains(x)).Sum();

            return sumOfElementsNotFound * _foundNumbers.Last();
        }
    }
}
