using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class Pricing
    {
        public Option option { get; private set; }
        public PricingModel model { get; private set; }
        public PricingDate pricingDate { get; private set; }
        public Premium premium { get; private set; }

        public Pricing(Option option, PricingModel model, PricingDate pricingDate, Premium premium)
        {
            if (model == PricingModel.Unknown) throw new Exception("No pricing model was specified, please insert the adapted one");
            if (option == null) throw new Exception("Null option object not callable...");
            if (premium == null) throw new Exception("Null premium object not callable...");
            if (pricingDate == null) throw new Exception("Null pricing date was given, please insert correct value");

            this.option = option;
            this.model = model;
            this.pricingDate = pricingDate;
            this.premium = premium;
        }
    }
}
