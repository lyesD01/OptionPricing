using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class PricingDate
    {
        public DateTime pricingDate { get; private set; }

        public PricingDate(DateTime pricingDate)
        {
            if (pricingDate < DateTime.Today) throw new Exception("Not possible to price with previous date");
            this.pricingDate = pricingDate;
        }
    }
}
