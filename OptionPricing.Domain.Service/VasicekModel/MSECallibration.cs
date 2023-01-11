using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearRegression;

namespace OptionPricing.Domain.Service.VasicekModel
{
    internal class MSECallibration
    {
        private List<double> interestRates = new List<double>();
        public MSECallibration(List<double> interestRates)
        {
            this.interestRates = interestRates;
        }

        private Dictionary<string, double> LinearRegressionParameters()
        {
            //Tuple<double, double> linearResult = Fit.Line();
            Dictionary<string, double> linearResults = new Dictionary<string, double>();
            return linearResults;
        }



    }
}
