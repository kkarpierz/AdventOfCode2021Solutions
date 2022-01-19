using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    public class CO2RatingCommand : ICommand
    {
        private Rating _rating;

        public CO2RatingCommand(Rating rating)
        {
            _rating = rating;
        }

        public void Execute()
        {
            _rating.CO2RatingCalculate();
        }
    }
}
