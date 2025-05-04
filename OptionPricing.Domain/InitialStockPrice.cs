using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class InitialStockPrice
    {
        public float initialStockPrice { get; private set; }   

        public InitialStockPrice(float initialStockPrice)
        {
            if (initialStockPrice < 0) throw new Exception("Initial Price is negative, only positive values handled...");
            this.initialStockPrice = initialStockPrice;
        }
    }
}
