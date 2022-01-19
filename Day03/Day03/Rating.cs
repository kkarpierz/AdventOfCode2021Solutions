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
            // todo
            // calculations and alghorythms for calculating
            // print result (or even store in variable somewhere here)
            Console.WriteLine("Oxygen rating calculated");
        }

        public void CO2RatingCalculate()
        {
            // todo calculations
            Console.WriteLine("CO2 rating calculated");
        }

    }
}
