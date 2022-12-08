using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public enum PricingModel
    {
        Unknown,
        Black_Scholes,
        Heston,
        HJM,
        Local_Volatility,
        Monte_Carlo,
    }
}
