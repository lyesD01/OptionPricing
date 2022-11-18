using OptionPricing.Domain;
using OptionPricingDAO;
using NSubstitute;
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


            var pricingDAO = Substitute.For<IPricingDAO>();
            var pricing = Substitute.For<Pricing>();

            var _id = 1;

            var pricingRepository = new OptionRepository(pricingDAO);
            

            //pricingRepository.InsertPricing(Arg.Any<Pricing>()).Returns(1);
            pricingRepository.InsertPricing(pricing);

            pricingRepository.Received().InsertPricing(pricing);

            

            
            
            //// Act     : 
            
            
            //PricingDAO _pricingDAO  = new PricingDAO();
            //OptionRepository _optionRepository = new OptionRepository(_pricingDAO);
            
            //Pricing pricing = _optionRepository.GetPricingById(12);
            
            //int id_ = _optionRepository.InsertPricing(pricing);
            
            //// Assert : 

            //Assert.AreEqual(19, id_);

            //Assert.Pass();
        }
    }
}