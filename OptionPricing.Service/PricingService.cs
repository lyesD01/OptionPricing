using OptionPricing.Domain;
using OptionPricing.Domain.Service;
using OptionPricing.Infrastructure;
using OptionPricing.Repository;
using OptionPricingDAO;
using System.Security;

namespace OptionPricing.Service
{

    public interface IPricingService
    {
        string PriceAndPersist(string JsonString, OptionPricingRegistration optionPricingRegistration);
    }

    public class PricingService : IPricingService
    {
        private readonly IPricingRepository _pricingRepository;
        private readonly IOptionPricingSerialiser _optionPricingSerialiser;
        public PricingService(IPricingRepository pricingRepo, IOptionPricingSerialiser mySerialiser)
        {
            _pricingRepository = pricingRepo;
            _optionPricingSerialiser = mySerialiser;
        }

        //Method : 
        public string PriceAndPersist(string JsonString, OptionPricingRegistration optionPricingRegistration)  // Inserer conteneur d'instance en second paramètre...
        {
            // Etape 1 : Déserialisation
            Pricing pricing = _optionPricingSerialiser.Deserialise<Pricing>(JsonString);

            // Etape 2 : Pricing.
            var pricer = optionPricingRegistration.Resolve<IPrice>(pricing.model);
            var price = pricer.Price(pricing);

            pricing.premium = new Premium((float)price);


            // Etape 3 : Insert in DB.
            var id_ = _pricingRepository.InsertPricing(pricing);


            // Etape 4 : Sérialisation.
            _optionPricingSerialiser.Serialise<Pricing>(pricing); 



            // Implémenter des méthodes de pricing.

            return JsonString;
        }
    }
}