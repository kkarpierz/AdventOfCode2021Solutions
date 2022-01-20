using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    public class Rating
    {
        private List<string> _data;
        private string _oxygenRatingResult;
        private string _co2RatingResult;

        public Rating(List<string> data)
        {
            _data = data;
            _oxygenRatingResult = String.Empty;
            _co2RatingResult = String.Empty;
        }

        // todo
        // methods for example multiplying them


        public void OxygenRatingCalculate()
        {

            if (_data.Count == 0)
            {
                throw new Exception("Data from the input file cannot be empty");
            }

            List<string> selectedSequence = _data;

            for (int i = 0; i < _data.ElementAt(0).Length; i++)
            {
                bool oneIsTheMostCommon = IsOneTheMostCommonBitOnGivenPlace(selectedSequence, i);

                // then keep all with ones at the currently iterating position (from '1' bit)
                if (oneIsTheMostCommon)
                {
                    selectedSequence = selectedSequence.Where(sequence => sequence.ElementAt(i) == '1').ToList();
                }
                else
                {
                    selectedSequence = selectedSequence.Where(sequence => sequence.ElementAt(i) == '0').ToList();
                }

                if (selectedSequence.Count == 1)
                    break;
            }

            if (selectedSequence.Count == 1)
                _oxygenRatingResult = selectedSequence.ElementAt(0);
            else
                _oxygenRatingResult = "Not calculated properly..";

            Console.WriteLine("Oxygen rating calculated");
            Console.WriteLine("Oxygen rating: " + _oxygenRatingResult);
        }

        public void CO2RatingCalculate()
        {
            if (_data.Count == 0)
            {
                throw new Exception("Data from the input file cannot be empty");
            }

            List<string> selectedSequence = _data;

            for (int i = 0; i < _data.ElementAt(0).Length; i++)
            {
                bool zeroIsTheLeastCommon = IsOneTheMostCommonBitOnGivenPlace(selectedSequence, i);

                // then keep all with ones at the currently iterating position (from '0' bit)
                // we find here the least common, so when the ones are more commons than zeros then zeros is result
                if (zeroIsTheLeastCommon)
                {
                    selectedSequence = selectedSequence.Where(sequence => sequence.ElementAt(i) == '0').ToList();
                }
                else
                {
                    selectedSequence = selectedSequence.Where(sequence => sequence.ElementAt(i) == '1').ToList();
                }

                if (selectedSequence.Count == 1)
                    break;
            }

            if (selectedSequence.Count == 1)
                _co2RatingResult = selectedSequence.ElementAt(0);
            else
                _co2RatingResult = "Not calculated properly";

            Console.WriteLine("CO2 scrubber rating calculated");
            Console.WriteLine("CO2 scrubber rating: " + _co2RatingResult);
        }

        private bool IsOneTheMostCommonBitOnGivenPlace(List<string> actualSequences, int placeNum)
        {
            int calculateOnesOccurences = 0;
            int calculateZerosOccurences = 0;

            calculateOnesOccurences = actualSequences.Count(sequence => sequence.ElementAt(placeNum) == '1');
            calculateZerosOccurences = actualSequences.Count(sequence => sequence.ElementAt(placeNum) == '0');

            return calculateOnesOccurences >= calculateZerosOccurences;
        }

    }
}
