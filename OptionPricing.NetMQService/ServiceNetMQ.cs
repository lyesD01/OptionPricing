using NetMQ;
using NetMQ.Sockets;
using OptionPricing.Domain;
using OptionPricing.Domain.Service;
using OptionPricing.Infrastructure;
using OptionPricing.Repository;
using OptionPricing.Service;
using OptionPricingDAO;


var registration = new OptionPricingRegistration();

registration.Register<IPricingDAO, PricingDAO>();
registration.Register<IOptionPricingSerialiser, OptionPricingSerialiser>();
registration.Register<IPricingRepository, PricingRepository>();

registration.Register<IPrice, BlackScholes_PricingService>(PricingModel.Black_Scholes);
registration.Register<IPrice, HJM_PricingService>(PricingModel.HJM);
//registration.Register<IPrice, HJM_PricingService>(PricingModel.Local_Volatility);
//registration.Register<IPrice, HJM_PricingService>(PricingModel.Heston);

registration.Register<IPricingService, PricingService>();

var optionService = registration.Resolve<IPricingService>();

using(var responseSocket = new ResponseSocket("@tcp://*:5555") )
{
	while (true) 
	{
		var message = responseSocket.ReceiveFrameString();
		Console.WriteLine($"Message Received : {message}");
		var response = optionService.PriceAndPersist(message, registration);

		responseSocket.SendFrame(response);
	}
}