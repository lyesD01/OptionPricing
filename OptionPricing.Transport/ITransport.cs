using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionPricing.Domain;

namespace OptionPricing.Transport
{
    public interface ITransport
    {
        Pricing Connect(string host, int port, Pricing pricing);
    }
}
