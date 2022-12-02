using OptionPricing.Domain;
using OptionPricingDAO;
using NSubstitute;
namespace OptionPricing.Repository.tests
{
    public class Tests
    {
        private IPricing _pricing;
        private IPricingDAO _pricingDAO;
        [SetUp]
        public void Setup()
        {
            _pricing = Substitute.For<IPricing>();
            _pricingDAO = Substitute.For<IPricingDAO>();
        }
       

        [Test]
        public void OptionPricing_Repos_Tests()
        {

            var optionRepository = new PricingRepository(_pricingDAO);

            int id_ = optionRepository.InsertPricing((Pricing)_pricing); 
               
        }

        private PricingDTO CreatDTO()
        {
            PricingDTO DTO = new PricingDTO();

            DTO.DatePricing = DateTime.Today;
            DTO.Premium = 1.2f;
            DTO.ModelType = "BlackSholes";
            DTO.Strike = 255;
            DTO.Maturity = DateTime.Today;
            DTO.FirstName = "Cariou";
            DTO.SecondName = "Pierre";
            DTO.DeskName = "DeltaOne";
            DTO.StockPrice = 250f;
            DTO.ImpliedVolatility = 0.4f;
            DTO.RiskFreeRate = 0.02f;
            DTO.UnderlyingType = "Commodity";

            return DTO;
        }


        private Pricing ShouldPrice()
        {
            Pricing pricing = Substitute.For<Pricing>();
            
            return pricing;
        }

    }
}