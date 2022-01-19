using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    public class StatsOptions
    {
        private ICommand _oxygenRatingCommand;
        private ICommand _co2RatingCommand;

        public StatsOptions(ICommand oxygenRating, ICommand co2Rating)
        {
            _oxygenRatingCommand = oxygenRating;
            _co2RatingCommand = co2Rating;
        }

        public void chooseOxygenRating()
        {
            _oxygenRatingCommand.Execute();
        }

        public void chooseCO2Rating()
        {
            _co2RatingCommand.Execute();
        }
    }
}
