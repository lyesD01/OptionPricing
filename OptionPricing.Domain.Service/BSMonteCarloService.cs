using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OptionPricing.Domain.Service
{
    public class BSMonteCarloService : IPrice
    {
        
        private int numberOfSimulations;
        private double[] normalDistSample;

        public double Price(Pricing pricing)
        {
            return Simulation(pricing); 
        }


        public double Simulation(Pricing pricingObj)
        {
            double stockPrice    = pricingObj.option.underlying.initialStockPrice.initialStockPrice;
            double volatility    = pricingObj.option.underlying.impliedVolatility.impliedVolatility;
            double riskFreeRate  = pricingObj.option.underlying.riskFreeRate.rate;
            TimeSpan maturity    = pricingObj.option.maturity.maturity - pricingObj.pricingDate.pricingDate;
            double normalizedMaturity = maturity.TotalDays;


            //MathNet.Numerics.Distributions.Normal.Samples(normalDistSample, 0, 1);


            return 200.0;
        }
    }
}
