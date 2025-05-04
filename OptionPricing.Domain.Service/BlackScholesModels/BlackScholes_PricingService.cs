using MathNet.Numerics.Distributions;
using System;

namespace OptionPricing.Domain.Service
{
    public class BlackScholes_PricingService : IPrice
    {
        public double Price(Pricing price)
        {

			double S = price.option.underlying.initialStockPrice.Value;
			double r = price.option.underlying.riskFreeRate.Value;
			double X = price.option.strike.Value;
			double v = price.option.underlying.impliedVolatility.Value;
			TimeSpan Tspan = price.option.maturity.Value - price.pricingDate.Value;

			double T = Tspan.TotalDays / 365.0; // Normalized maturity.
			string CallPutFlag = price.option.optionType.ToString();


			double d1 = 0.0;
			double d2 = 0.0;
			double dBlackScholes = 0.0;
			
			d1 = (Math.Log(S / X) + (r + v * v / 2.0) * T) / (v * Math.Sqrt(T));
			d2 = d1 - v * Math.Sqrt(T);

			if (CallPutFlag.ToUpper() == "CALL")
			{				
				dBlackScholes = S * CND(d1) - X * Math.Exp(-r * T) * CND(d2);
			}
			else if (CallPutFlag.ToUpper() == "PUT") 
			{
				dBlackScholes = X * Math.Exp(-r * T) * CND(-d2) - S * CND(-d1);				
			}
			return dBlackScholes;
        }


        public double CND(double X)
        {
            return MathNet.Numerics.Distributions.Normal.CDF(0, 1, X) ;
        }

	
	}
}