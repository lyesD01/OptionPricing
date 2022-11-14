using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OptionPricing.Domain.Service
{
    public interface IPricingService
    {
        double Price(Pricing price);
    }
}
