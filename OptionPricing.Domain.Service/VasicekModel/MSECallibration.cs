using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibrationDAO;
using MathNet.Numerics;
using MathNet.Numerics.LinearRegression;

namespace OptionPricing.Domain.Service.VasicekModel
{
    internal class MSECallibration
    {
        private IntrestRatesData interestRates;
        public MSECallibration(IntrestRatesData interestRates)
        {
            this.interestRates = interestRates;
        }

        private void LinearRegressionParameters()
        {
            //Tuple<double, double> linearResult = Fit.Line();
            Dictionary<string, double> linearResults = new Dictionary<string, double>();
        }



    }
}

