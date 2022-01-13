using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    public class GammaCountCommand
    {
        private List<string> _vectorsData = new();
        private string _gammaRate = string.Empty;

        public GammaCountCommand(List<string> vectorsData)
        {
            _vectorsData = vectorsData;
        }

        //Gets most common bits at the same position
        public string CalculateGamma()
        {
            if (_vectorsData.Count == 0)
                throw new Exception("Vectors Data is empty. Please provide data into the class.");

            // without knowing that every string has same length => should be checked too
            // it is get because of the excercise knowledge that they are same length
            var lengthOfString = _vectorsData[0].Length;
            string result = String.Empty;
            var countOfVectors = _vectorsData.Count;

            for (int i = 0; i < lengthOfString; i++)
            {
                var countOfOnes = 0;
                for (int j = 0; j < countOfVectors; j++)
                {
                    char ourByte = _vectorsData[j].ElementAt(i);
                    if (ourByte == '1')
                        ++countOfOnes;
                }

                if (countOfOnes > countOfVectors / 2)
                    result += '1';
                else
                    result += '0';
            }

            _gammaRate = result;
            return result;
        }

        public string CalculateEpsilon()
        {
            string result = String.Empty;

            foreach (char item in _gammaRate)
            {
                if (item == '1')
                    result += '0';
                else
                    result += '1';
            }

            return result;
        }

        // make gamma and epsilon in one loop and then into property

    }
}
