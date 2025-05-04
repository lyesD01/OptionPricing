using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class Desk
    {
        public string value {get; private set;}
        
        public Desk(string deskName)
        {
            this.value = deskName;
        }
    }
}
