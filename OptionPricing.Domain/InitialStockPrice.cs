using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class InitialStockPrice
    {
        public float Value { get; private set; }   

        public InitialStockPrice(float price)
        {
            if (price < 0) throw new Exception("Initial Price is negative, only positive values handled...");
            Value = price;
        }
    }
}
