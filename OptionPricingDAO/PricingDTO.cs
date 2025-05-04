using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricingDAO
{
    public class PricingDTO
    {
           
        public string DeskName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public float StockPrice { get; set; }
        public float RiskFreeRate { get; set; }
        public float ImpliedVolatility { get; set; }
        public DateTime Maturity { get; set; }
        public float Strike { get; set; }
        public DateTime DatePricing { get; set; }
        public float Premium { get; set; }
        public string ModelType { get; set; }
        public string OptionType { get; set; }
        public string UnderlyingType { get; set; }
    
    }
}
