using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationDAO
{
    public interface IRates
    {
        Task<IntrestRatesData> GetIntrestRateData();
    }
}
