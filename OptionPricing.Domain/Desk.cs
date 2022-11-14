using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class Desk
    {
        public string deskName {get; private set;}
        
        public Desk(string deskName)
        {
            this.deskName = deskName;
        }
    }
}
