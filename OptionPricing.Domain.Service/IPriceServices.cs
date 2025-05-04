using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OptionPricing.Domain.Service
{
    public interface IPrice
    {
        double Price(Pricing price);
    }
}
