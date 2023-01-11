using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationDAO
{
    public class IntrestRatesData
    {
        public List<decimal> HistoricalData { get; set; }
        public List<DateTime> Dates { get; set; }
    }
}
