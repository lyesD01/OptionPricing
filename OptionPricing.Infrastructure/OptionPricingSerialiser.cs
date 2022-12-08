//using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OptionPricing.Infrastructure
{

    public interface IOptionPricingSerialiser
    {
        string Serialise<T>(T myObj);
        T Deserialise<T>(string myString);
    }

   public class OptionPricingSerialiser : IOptionPricingSerialiser
    {
        public string Serialise<T>(T myObj)
        {
            //return JsonConvert.SerializeObject(myObj);
            return JsonSerializer.Serialize<T>(myObj);
        }
        
        public T Deserialise<T>(string myString)
        {
            //return JsonConvert.DeserializeObject<T>(myString);
            return JsonSerializer.Deserialize<T>(myString);
        }
    }
}