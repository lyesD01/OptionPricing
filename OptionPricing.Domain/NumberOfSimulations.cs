using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Domain
{
    public class NumberOfSimulations
    {
        public int numberOfSimulations { get; private set; }

        public NumberOfSimulations(int numberOfSimulations)
        {
            if (numberOfSimulations < 1) throw new Exception($"Can't perform {numberOfSimulations}, please select at least more than one fore efficiency... ");
            if (numberOfSimulations.GetType() != typeof(int) ) throw new Exception($"Can't perform {numberOfSimulations}, please make sure you select an integer... ");
            this.numberOfSimulations = numberOfSimulations;
        }
    }
}
