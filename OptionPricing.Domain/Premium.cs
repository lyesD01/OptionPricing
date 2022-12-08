using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class Premium
    {
        public float premium { get; private set; }

        public Premium(float premium)
        {
            this.premium = premium;
        }
    }
}
