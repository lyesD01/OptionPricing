﻿namespace OptionPricing.Domain
{
    public class Maturity
    {
        public DateTime maturity { get; private set; }

        public Maturity(DateTime maturity)
        {
            if (maturity < DateTime.Today) throw new Exception("Maturity should be later... \n");

            Value = maturity;

        }
    }
}