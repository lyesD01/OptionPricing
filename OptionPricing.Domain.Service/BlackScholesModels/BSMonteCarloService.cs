using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OptionPricing.Domain.Service
{
    public class BSMonteCarloService : IPrice
    {

        private static int numberOfCores = Environment.ProcessorCount; //Number of cores.
        public double Price(Pricing pricing)
        {
            return European_MonteCarlor_Simulations(pricing); 
        }


        public double European_MonteCarlor_Simulations(Pricing pricingObj)
        {

            double stockPrice    = pricingObj.option.underlying.initialStockPrice.Value;
            double volatility    = pricingObj.option.underlying.impliedVolatility.Value;
            double riskFreeRate  = pricingObj.option.underlying.riskFreeRate.Value;
            double strike        = pricingObj.option.strike.Value;
            TimeSpan maturity    = pricingObj.option.maturity.Value - pricingObj.pricingDate.Value;
            double normalizedMaturity = (maturity.TotalDays+1) / 365.0;
            //int numberOfSimualtions = pricingObj.numberOfSimulations.numberOfSimulations;
            int numberOfSimualtions = 100000;

            string CallPutFlag = pricingObj.option.optionType.ToString().ToUpper();

            double logStockPrice = Math.Log(stockPrice);
            double nudt          = (riskFreeRate - 0.5 * Math.Pow(volatility, 2) ) * normalizedMaturity;
            double volStdt       = volatility * Math.Sqrt(normalizedMaturity);
            double finalPayoff;
            double expStockPrice;
            double NextLogStockPrice;
            
            Task[] MCSimulationsTasks = new Task[numberOfCores];
            double[] payOffPerThread = new double[numberOfCores];

            for (int core = 0; core < numberOfCores; core++)
            {
                double sumPayOff = 0.0;
                double payOff;
                int IndexCore = core;
                 MCSimulationsTasks[IndexCore] = Task.Factory.StartNew(() =>
                {

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
                    payOffPerThread[IndexCore] = sumPayOff;
                }
                );
            }    

            Task.WaitAll(MCSimulationsTasks);
            finalPayoff = payOffPerThread.Sum();


            // Expectation computation : 
            double ExpectedCallPrice = Math.Exp(-riskFreeRate * normalizedMaturity) * finalPayoff / (numberOfSimualtions * numberOfCores);

            return ExpectedCallPrice;
        }




        public double European_MonteCarlor_Simulations_withoutMT(Pricing pricingObj)
        {

            int numberOfSimualtions = 100000; //// Warning 
            double stockPrice = pricingObj.option.underlying.initialStockPrice.Value;
            double volatility = pricingObj.option.underlying.impliedVolatility.Value;
            double riskFreeRate = pricingObj.option.underlying.riskFreeRate.Value;
            double strike = pricingObj.option.strike.Value;
            TimeSpan maturity = pricingObj.option.maturity.Value - pricingObj.pricingDate.Value;
            double normalizedMaturity = (maturity.TotalDays + 1) / 365.0;
            numberOfSimualtions = numberOfSimualtions * numberOfCores; //// Check it again here ********

            string CallPutFlag = pricingObj.option.optionType.ToString().ToUpper();

            double logStockPrice = Math.Log(stockPrice);
            double nudt = (riskFreeRate - 0.5 * Math.Pow(volatility, 2)) * normalizedMaturity;
            double volStdt = volatility * Math.Sqrt(normalizedMaturity);
            double expStockPrice;
            double NextLogStockPrice;

            double sumPayOff = 0.0;
            double payOff;
            for (int i = 0; i < numberOfSimualtions; i++)
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
            double ExpectedCallPrice = Math.Exp(-riskFreeRate * normalizedMaturity) * sumPayOff / (numberOfSimualtions);


            return ExpectedCallPrice;
        }


        public Dictionary<string, List<double> > American_MonteCarlo_Simulations(Pricing pricingObj)
        {

            TimeSpan timeSpan           = pricingObj.option.maturity.Value - pricingObj.pricingDate.Value;
            double normalizedMaturity   = (timeSpan.TotalDays + 1) / 365f; 
            double logStockPrice        = Math.Log(pricingObj.option.underlying.initialStockPrice.Value);
            double strike               = pricingObj.option.strike.Value;
            double volatility           = pricingObj.option.underlying.impliedVolatility.Value;
            double riskFreeRate         = pricingObj.option.underlying.riskFreeRate.Value;



            double dt                   = normalizedMaturity / timeSpan.TotalDays;
            double NuDt                 = (riskFreeRate - 0.5 * Math.Pow(volatility, 2) ) * dt;
            double VolDt                = volatility * Math.Sqrt(dt);

            int numberOfSimulations     = 1000000000; 

            Dictionary<string, List<double>> DictSimulations = new Dictionary<string, List<double>>();
            List<double> ASimulation                         = new List<double>();  




            //MathNet.Numerics.Distributions.Normal.Samples(normalDistSample, 0, 1); (Normal distribution sample)
            throw new Exception("Method not implemented yet...");
        }


    }
}
