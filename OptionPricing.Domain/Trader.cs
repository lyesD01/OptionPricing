using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class Trader
    {
        public string firstName { get; private set; }
        public string SecondName { get; private set; }
        public Desk deskName { get; private set; }

        public Trader(string firstName, string SecondName, Desk deskName)
        {
            this.firstName = firstName;
            this.SecondName = SecondName;
            this.deskName = deskName;
        }
    }
}
