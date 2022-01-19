using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    public class OxygenRatingCommand : ICommand
    {
        private Rating _rating;

        public OxygenRatingCommand(Rating rating)
        {
            _rating = rating;
        }

        void ICommand.Execute()
        {
            _rating.OxygenRatingCalculate();
        }
    }
}
