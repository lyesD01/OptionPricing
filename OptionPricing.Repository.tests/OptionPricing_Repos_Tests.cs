using OptionPricing.Domain;

namespace OptionPricing.Repository.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        private readonly IPricingRepository _pricingRepository;

        [Test]
        public void OptionPricing_Repos_Tests()
        {
            // Arrange : 
            // Act     : 
            var pricing = _pricingRepository.GetPricingById(1);
            Console.WriteLine("Object retrieved succesfully...");
            int id_ = _pricingRepository.InsertPricing(pricing);
            
            // Assert : 

            Assert.AreEqual(1, id_);

            Assert.Pass();
        }
    }
}