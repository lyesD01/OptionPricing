using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class Option
    {
        public Maturity maturity { get; private set; }
        public Strike strike { get; private set; }
        public OptionType optionType { get; private set; }
        public Underlying underlying { get; private set; }  
        public Trader trader { get; private set; }
        
        public Option(Trader trader, Strike strike, Maturity maturity, OptionType optionType, Underlying underlying)
        {
            if (trader.firstName == null) throw new Exception("Null first name) value is non callable...");
            if (trader.SecondName == null)  throw new Exception("Null family name value is non callable...");
            if (trader.deskName == null)  throw new Exception("Null desk name value is non callable...");
            if (strike == null) throw new Exception("Null value for the strike is non callable...");
            if (maturity == null) throw new Exception("Null value to maturity was given, please get a positive value...");
            if (optionType == null) throw new Exception("Null value for option type was given, please select one...");
            
            this.trader = trader;
            this.strike = strike;
            this.underlying = underlying;
            this.maturity = maturity;
            this.optionType = optionType;
        }
    }
}
