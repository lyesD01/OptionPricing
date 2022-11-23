using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class ImpliedVolatility
    {
        public float impliedVolatility{ get; private set; }
        public ImpliedVolatility(float impliedVolatility)
        {
            if (impliedVolatility < 0) throw new Exception("Vol Negative ");
            this.impliedVolatility= impliedVolatility;

        }
    }
}
