using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class Underlying
    {
        public InitialStockPrice initialStockPrice { get; private set; }
        public ImpliedVolatility impliedVolatility { get; private set; }
        public RiskFreeRate riskFreeRate { get; private set; }
        public UnderlyingType underlyingType { get; private set; }

        public Underlying(InitialStockPrice initialStockPrice, ImpliedVolatility impliedVolatility, 
                          RiskFreeRate riskFreeRate, UnderlyingType underlyingType )
        {
            if (initialStockPrice == null) throw new Exception("Null Initial Price Values not callable...");
            if (impliedVolatility == null) throw new Exception("NUll Implied Volatility non Callable");
            if (riskFreeRate == null) throw new Exception("NUll Risk Free Rate non Callable");
            if (underlyingType == UnderlyingType.Unknown) throw new Exception(@"/!\ : Underlying type Unknown");

            this.initialStockPrice = initialStockPrice;
            this.impliedVolatility = impliedVolatility;
            this.riskFreeRate = riskFreeRate;
            this.underlyingType = underlyingType;
        }
    }
}
