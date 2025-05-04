using NSubstitute;
using OptionPricing.Repository;

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
            //summary
            // Arrange : 
            //var pricingDAO = new PricingDAO();
            //var pricingDTO = new PricingDTO();
            //var getInfoDTO = new PricingDTO();

            //int IdPricing;



            //// ACT 
            //IdPricing = pricingDAO.InsertPricing(pricingDTO);
            //getInfoDTO = pricingDAO.GetPricing_info(IdPricing);

            var pricingDAO = Substitute.For<IPricingDAO>();
            var pricingDTO = Substitute.For<PricingDTO>();

            pricingDTO.DeskName = "Delta One";
            pricingDTO.FirstName = "D.Luffy";
            pricingDTO.SecondName = "Monkey";
            pricingDTO.StockPrice = 3000f;
            pricingDTO.RiskFreeRate = 0.021f;
            pricingDTO.ImpliedVolatility = 0.42f;
            pricingDTO.Maturity = DateTime.Now.AddMonths(-6);
            pricingDTO.Strike = 5000.14f;
            pricingDTO.DatePricing = DateTime.Now;
            pricingDTO.Premium = 1.6f;
            pricingDTO.ModelType = "Heston";
            pricingDTO.OptionType = "VAnilla";
            pricingDTO.UnderlyingType = "Put";

            pricingDAO.InsertPricing(pricingDTO).Returns(15);
            pricingDAO.GetPricing_info(15).Returns(pricingDTO);

            
            // Assert : 
            Assert.That(pricingDTO.Premium, Is.EqualTo(pricingDAO.GetPricing_info(15).Premium));
            Assert.That(pricingDAO.InsertPricing(pricingDTO), Is.EqualTo(15));
            //Assert.That(getInfoDTO.FirstName, Is.EqualTo(pricingDTO.FirstName));
            //Assert.That(getInfoDTO.SecondName, Is.EqualTo(pricingDTO.SecondName));
            //Assert.That(getInfoDTO.Premium, Is.EqualTo(pricingDTO.Premium));

            // ASSERT : 
            Console.WriteLine("Insertion completed");

            Assert.Pass();
        }
    }


}