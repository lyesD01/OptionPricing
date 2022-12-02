using MathNet.Numerics.Distributions;
using System;

namespace OptionPricing.Domain.Service
{
    public class BlackScholes_PricingService : IPrice
    {
        public double Price(Pricing price)
        {

			double S = price.option.underlying.initialStockPrice.initialStockPrice;
			double r = price.option.underlying.riskFreeRate.rate;
			double X = price.option.strike.strike;
			double v = price.option.underlying.impliedVolatility.impliedVolatility;
			TimeSpan Tspan = price.option.maturity.maturity - price.pricingDate.pricingDate;
			double T = Tspan.TotalDays;
			string CallPutFlag = price.option.underlying.underlyingType.ToString();


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
            double cdfValue = MathNet.Numerics.Distributions.Normal.CDF(0, 1, X) ;
            return cdfValue;
        }
    }
}