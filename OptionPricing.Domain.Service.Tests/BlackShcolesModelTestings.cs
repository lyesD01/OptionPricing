using System.Diagnostics;

namespace OptionPricing.Domain.Service.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BlackScholes_ClosedFormula_Tests()
        {
            // Arrange  : 
            var timer = new Stopwatch();

            Pricing pricing = CreatePricing();
            BSMonteCarloService blackScholes = new BSMonteCarloService();
            BlackScholes_PricingService blackScholes_PricingService = new BlackScholes_PricingService();
            
            // ACT      : 
            timer.Start();
            double MCpremium = blackScholes.Price(pricing);
            timer.Stop();
            Console.WriteLine($"The SIMULATED PRICE with Monte Carlo    : ************ {MCpremium} ");
            Console.WriteLine($"Execution Time                          : ************ {timer.ElapsedMilliseconds} ");
            
            timer.Restart();
            double ClosedPremium = blackScholes_PricingService.Price(pricing);
            timer.Stop();
            Console.WriteLine($"The SIMULATED PRICE with Closed Formula : ************ {ClosedPremium} ");
            Console.WriteLine($"Execution Time                          : ************ {timer.ElapsedMilliseconds} ");

            timer.Restart();
            double MCPremimuWithoutThread = blackScholes.European_MonteCarlor_Simulations_withoutMT(pricing);
            timer.Stop();
            Console.WriteLine($"The SIMULATED PRICE without MultiThread : ************ {MCPremimuWithoutThread} ");
            Console.WriteLine($"Execution Time                          : ************ {timer.ElapsedMilliseconds} ");
            // Assert   : 


            Assert.Pass();
        }






        private Pricing CreatePricing()
        {
            Desk deskName = new Desk("DeltaOne");
            Trader trader = new Trader("Pierre", "Cariou", deskName);

            InitialStockPrice initialStockPrice = new InitialStockPrice(101.15f);
            ImpliedVolatility implied_volatility = new ImpliedVolatility(0.0991f);
            Maturity maturity = new Maturity(new DateTime(2023, 3, 13) );
            Strike strike = new Strike(98.01f);
            PricingDate pricingDate = new PricingDate(DateTime.Today);
            RiskFreeRate riskFreeRate = new RiskFreeRate(0.01f);

            UnderlyingType underlyingType = UnderlyingType.Commodity;
            PricingModel model = PricingModel.Monte_Carlo;
            Underlying underlying = new Underlying(initialStockPrice, implied_volatility, riskFreeRate, underlyingType);
            OptionType optionType = OptionType.Call;
            NumberOfSimulations numberOfSimulations = new NumberOfSimulations(150000);

            Option option = new Option(trader, strike, maturity, optionType, underlying);
            Pricing pricing = new Pricing(option, model, pricingDate,numberOfSimulations);

            return pricing;
        }
    }
}