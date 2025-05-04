using CalibrationDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calibration.Repository
{
    internal interface ICalibrationRepository
    {
        IntrestRatesData getIntrestRatesData();
    }
}
