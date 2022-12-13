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
            Pricing pricing = CreatePricing();
            BSMonteCarloService blackScholes = new BSMonteCarloService();
            

            // ACT      : 
            double premium = blackScholes.Price(pricing);

            // Assert   : 
            Console.WriteLine($"The simulated price ...... {premium} ");

            Assert.Pass();
        }






        private Pricing CreatePricing()
        {
            Desk deskName = new Desk("DeltaOne");
            Trader trader = new Trader("Pierre", "Cariou", deskName);

            InitialStockPrice initialStockPrice = new InitialStockPrice(250f);
            ImpliedVolatility implied_volatility = new ImpliedVolatility(0.4f);
            Maturity maturity = new Maturity(new DateTime(2023, 2, 1) );
            Strike strike = new Strike(255);
            PricingDate pricingDate = new PricingDate(DateTime.Today);
            RiskFreeRate riskFreeRate = new RiskFreeRate(0.02f);

            UnderlyingType underlyingType = UnderlyingType.Commodity;
            PricingModel model = PricingModel.Monte_Carlo;
            Underlying underlying = new Underlying(initialStockPrice, implied_volatility, riskFreeRate, underlyingType);
            OptionType optionType = OptionType.Call;
            NumberOfSimulations numberOfSimulations = new NumberOfSimulations(1000);

            Option option = new Option(trader, strike, maturity, optionType, underlying);
            Pricing pricing = new Pricing(option, model, pricingDate,numberOfSimulations);

            return pricing;
        }
    }
}