using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class Strike
    {
        public double Value { get; private set; }

        public Strike(double strike)
        {
            if (strike <= 0) throw new Exception("Negative values not callable... \n");
            Value = strike;
        }
    }
}
