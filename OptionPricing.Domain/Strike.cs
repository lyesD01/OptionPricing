﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class Strike
    {
        public float Value { get; private set; }

        public Strike(float strike)
        {
            if (strike <= 0) throw new Exception("Negative values not callable... \n");
            this.Vavlue = strike;
        }
    }
}
