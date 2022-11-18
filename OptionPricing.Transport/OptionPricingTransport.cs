using NetMQ;
using NetMQ.Sockets;
using OptionPricing.Domain;
using OptionPricing.Infrastructure;
namespace OptionPricing.Transport
{
    public class OptionPricingTransport : ITransport
    {

        private readonly IOptionPricingSerialiser _optionPricingSerialiser;
        public OptionPricingTransport(IOptionPricingSerialiser mySerialiser)
        {
            _optionPricingSerialiser = mySerialiser;
        }

        public Pricing Connect(string host, int port, Pricing pricing)
        {

            using (var requestSocket = new RequestSocket($">tcp://{host}:{port}"))
            {
                var request = _optionPricingSerialiser.Serialise(pricing);

                requestSocket.SendFrame(request);
                var message = requestSocket.ReceiveFrameString();
                pricing = _optionPricingSerialiser.Deserialise<Pricing>(message);
                
            }
            return pricing;
        }
    }
}