namespace OptionPricingDAO.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PricingDTO_Insert_Test()
        {
            // Arrange : 
            var pricingDAO = new PricingDAO();
            var pricingDTO = new PricingDTO();
            var getInfoDTO = new PricingDTO();
            
            int IdPricing;

            pricingDTO.DeskName = "Delta One";
            pricingDTO.FirstName = "D.Luffy";
            pricingDTO.SecondName = "Monkey";
            pricingDTO.StockPrice = 250f;
            pricingDTO.RiskFreeRate = 0.021f;
            pricingDTO.ImpliedVolatility = 0.42f;
            pricingDTO.Maturity = new DateTime(2024,1,2);
            pricingDTO.Strike = 140.14f;
            pricingDTO.DatePricing = DateTime.Today;
            pricingDTO.Premium = 1.6f;
            pricingDTO.ModelType = "Black Scholes";
            pricingDTO.OptionType = "VAnilla";
            pricingDTO.UnderlyingType = "Call";


            //// ACT 
            IdPricing = pricingDAO.InsertPricing(pricingDTO);
            getInfoDTO = pricingDAO.GetPricing_info(IdPricing);


            // Assert : 
            Assert.AreEqual(pricingDTO.DeskName, getInfoDTO.DeskName);
            Assert.AreEqual(pricingDTO.FirstName, getInfoDTO.FirstName);
            Assert.AreEqual(pricingDTO.SecondName, getInfoDTO.SecondName);
            Assert.AreEqual(pricingDTO.DatePricing, getInfoDTO.DatePricing);

            // ASSERT : 
            Console.WriteLine("Insertion completed");

            Assert.Pass();
        }
    }


}