using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public interface IPricing
    {

    }
    public class Pricing
    {
        public Option option { get; set; }
        public PricingModel model { get; set; }
        public PricingDate pricingDate { get; set; }
        public Premium premium { get; set; }

        public Pricing(Option option, PricingModel model, PricingDate pricingDate)
        {
            if (model == PricingModel.Unknown) throw new Exception("No pricing model was specified, please insert the adapted one");
            if (option == null) throw new Exception("Null option object not callable...");
            if (pricingDate == null) throw new Exception("Null pricing date was given, please insert correct value");

            this.option = option;
            this.model = model;
            this.pricingDate = pricingDate;

        }

        //public Pricing GetPricing()
        //{
        //    Pricing myPricing = new Pricing(option, model, pricingDate);
        //    return myPricing;
        //}
    }
}
