using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace OptionPricing.Domain
{
    public interface IPricing
    {

    }
    public class Pricing
    {

        public Option option { get; private set; }
        public PricingModel model { get; private set; }
        public PricingDate pricingDate { get; private set; }
        public Premium premium { get; set; }
        public NumberOfSimulations numberOfSimulations { get; private set; }


        // Pricing with Monte Carlo as well.
        public Pricing(Option option, PricingModel model, PricingDate pricingDate, NumberOfSimulations numberOfSimulations)
        {
            if (model == PricingModel.Unknown) throw new Exception("No pricing model was specified, please insert the adapted one");
            if (option == null) throw new Exception("Null option object not callable...");
            if (pricingDate == null) throw new Exception("Null pricing date was given, please insert correct value");

            this.option = option;
            this.model = model;
            this.pricingDate = pricingDate;

            if (model != PricingModel.Monte_Carlo)
                this.numberOfSimulations = new NumberOfSimulations(1);
            else
                this.numberOfSimulations = numberOfSimulations;

        }


        // Pricing Needed only for the Repository\DAO to insert in DB


        //public Pricing GetPricing()
        //{
        //    Pricing myPricing = new Pricing(option, model, pricingDate);
        //    return myPricing;
        //}
    }
}
