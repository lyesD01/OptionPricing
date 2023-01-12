using CalibrationDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calibration.Repository
{
    public class CalibrationRepository : ICalibrationRepository
    {

        public IntrestRatesData getIntrestRatesData()
        {
            HistoricalDataForCalibration historicalDataForCalibration = new HistoricalDataForCalibration();
            return historicalDataForCalibration.GetIntrestRateData().Result;
        }

    }
}
