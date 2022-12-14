using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OptionPricing.Domain.Service
{
    public class BSMonteCarloService : IPrice
    {
        

        public double Price(Pricing pricing)
        {
            return European_MonteCarlor_Simulations(pricing); 
        }


        public double European_MonteCarlor_Simulations(Pricing pricingObj)
        {
            double stockPrice    = pricingObj.option.underlying.initialStockPrice.initialStockPrice;
            double volatility    = pricingObj.option.underlying.impliedVolatility.impliedVolatility;
            double riskFreeRate  = pricingObj.option.underlying.riskFreeRate.rate;
            double strike        = pricingObj.option.strike.strike;
            TimeSpan maturity    = pricingObj.option.maturity.maturity - pricingObj.pricingDate.pricingDate;
            double normalizedMaturity = (maturity.TotalDays+1) / 365.0;
            int numberOfSimualtions = pricingObj.numberOfSimulations.numberOfSimulations;
            string CallPutFlag = pricingObj.option.optionType.ToString().ToUpper();

            double logStockPrice = Math.Log(stockPrice);
            double nudt          = (riskFreeRate - 0.5 * Math.Pow(volatility, 2) ) * normalizedMaturity;
            double volStdt       = volatility * Math.Sqrt(normalizedMaturity);
            double expStockPrice;
            double sumPayOff = 0.0;
            double NextLogStockPrice;
            double payOff;

            for (int i=0; i<numberOfSimualtions; i++)
            {
                NextLogStockPrice = logStockPrice + nudt + volStdt * MathNet.Numerics.Distributions.Normal.Sample(0, 1);
                expStockPrice = Math.Exp(NextLogStockPrice);
                if (CallPutFlag == "CALL") payOff = Math.Max(0, expStockPrice - strike);
                else
                {
                    if (CallPutFlag == "PUT") payOff = Math.Max(0, strike - expStockPrice);
                    else throw new Exception("Pricing impossible for this option with this model....");
                }
                sumPayOff = sumPayOff + payOff;
            }

            // Expectation computation : 
            double ExpectedCallPrice = Math.Exp(-riskFreeRate * normalizedMaturity) * sumPayOff / numberOfSimualtions;


            return ExpectedCallPrice;
        }




        public List<double> American_MonteCarlo_Simulations(Pricing pricingObj)
        {
            //MathNet.Numerics.Distributions.Normal.Samples(normalDistSample, 0, 1); (Normal distribution sample)
            throw new Exception("Method not implemented yet...");
        }


    }
}
