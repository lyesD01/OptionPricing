using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class ImpliedVolatility
    {
        public float Value { get; private set; }
        public ImpliedVolatility(float volatility)
        {
            if (volatility < 0) throw new Exception("Vol Negative ");
            Value = volatility;

        }
    }
}
