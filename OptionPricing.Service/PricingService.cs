using OptionPricing.Domain;
using OptionPricing.Domain.Service;
using OptionPricing.Infrastructure;
using OptionPricing.Repository;
using OptionPricingDAO;

namespace OptionPricing.Service
{
    public class PricingService
    {
        private readonly IPricingRepository _pricingRepository;
        private readonly IOptionPricingSerialiser _optionPricingSerialiser;
        public PricingService(IPricingRepository pricingRepo, IOptionPricingSerialiser mySerialiser)
        {
            _pricingRepository = pricingRepo;
            _optionPricingSerialiser = mySerialiser;
        }

        //Method : 
        public string PriceAndPersist(string myString)  // Inserer conteneur d'instance en second paramètre...
        {
            // Etape 1 : Déserialisation. 
            // Create string Json :

            //string myPricing = @"{""DeskName"" : ""Delta One"", ""FirstName"" : ""Yann"", ""SecondName"" : ""Bloum"", ""StockPrice"" : ""250"",
                               //""RiskFreeRate"" : ""0.02"", ""ImpliedVolatility"" : ""0.4"", ""Maturity"" : ""2025/09/15"", ""Strike"" : ""200"",
                               //""DatePricing"" : ""2022/11/10"", ""Premium"" : ""0.66"", ""ModelType"" : ""HJM"", ""OptionType"" : ""Call"", 
                               //""UnderlyingType"" : ""Commodity"" }";


            Pricing pricing = _optionPricingSerialiser.Deserialise<Pricing>(myString);
            
            
            // Etape 2 : Pricing.
            

            // Etape 3 : Insert in DB.
            var id_ = _pricingRepository.InsertPricing(pricing);


            // Etape 4 : Sérialisation.
            _optionPricingSerialiser.Serialise(pricing); 



            // Implémenter des méthodes de pricing.

            return "";
        }
    }
}