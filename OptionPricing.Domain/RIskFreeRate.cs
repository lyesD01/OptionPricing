using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class RiskFreeRate
    {
        public float Value { get; private set; }

        public RiskFreeRate(float rate)
        {
            if (rate < 0) throw new Exception("Risk Free Rate must be positive...");
            Value = rate;
        }
    }
}
