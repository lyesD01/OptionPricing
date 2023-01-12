using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace CalibrationDAO
{
    public class HistoricalDataForCalibration : IRates
    {
        public IntrestRatesData historicalRatesData;
        public async Task<IntrestRatesData> GetIntrestRateData()
        {

            IntrestRatesData historicalData = new IntrestRatesData();

            DateTime startingDateCalibration = DateTime.Now.AddYears(-5);
            DateTime endingDateCalibration = DateTime.Now;


            var historicalIntrestRates = await Yahoo.GetHistoricalAsync("^NTX", startingDateCalibration, endingDateCalibration);

            foreach(var historicalIntrestRate in historicalIntrestRates)
            {
                historicalData.Dates.Add(historicalIntrestRate.DateTime);
                historicalData.HistoricalData.Add(historicalIntrestRate.Close);
            }

            historicalRatesData = historicalData;
            return historicalRatesData;
        }
    }
}
