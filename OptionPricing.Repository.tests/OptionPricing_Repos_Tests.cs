using OptionPricing.Domain;
using OptionPricingDAO;

namespace OptionPricing.Repository.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
       

        [Test]
        public void OptionPricing_Repos_Tests()
        {
            // Arrange : 
            // Act     : 
            PricingDAO _pricingDAO  = new PricingDAO();
            OptionRepository _optionRepository = new OptionRepository(_pricingDAO);
            
            Pricing pricing = _optionRepository.GetPricingById(12);
            
            int id_ = _optionRepository.InsertPricing(pricing);
            
            // Assert : 

            Assert.AreEqual(19, id_);

            Assert.Pass();
        }
    }
}