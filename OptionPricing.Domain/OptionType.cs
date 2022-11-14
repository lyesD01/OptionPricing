using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class OptionType
    {
        public string optionType { get; private set; }

        public OptionType(string optionType)
        {
            this.optionType = optionType;
        }
    }
}
