// See https://aka.ms/new-console-template for more information
using NetMQ;
using NetMQ.Sockets;
using OptionPricing.Domain;
using OptionPricing.Infrastructure;
using System.ServiceModel;

Console.WriteLine("Hello, World!");

var Serialiser = new OptionPricingSerialiser();

using(var requestSocket = new RequestSocket(">tcp://localhost:5555"))
{
    Desk desk = new Desk("Delta One");
    Trader trader = new Trader("Floflo", "PLotplo", desk);

    InitialStockPrice initialStockPrice = new InitialStockPrice(250f);
    ImpliedVolatility implied_volatility = new ImpliedVolatility(0.4f);
    Maturity maturity = new Maturity(new DateTime(2024, 1, 1) );
    Strike strike_ = new Strike(255f);
    PricingDate pricingDate = new PricingDate(DateTime.Now );
    RiskFreeRate riskFreeRate = new RiskFreeRate(0.02f);


    Premium premium = new Premium(0.29f);
    UnderlyingType underlyingType = UnderlyingType.Commodity;
    PricingModel model = PricingModel.Heston;
    Underlying underlying = new Underlying(initialStockPrice, implied_volatility, riskFreeRate, underlyingType);

    OptionType optionType = OptionType.Call;
    Option option = new Option(trader, strike_, maturity, optionType, underlying);
    Pricing pricing = new Pricing(option, model, pricingDate);

    var request = Serialiser.Serialise(pricing);

    Console.WriteLine($"Client sending : {request}");
    requestSocket.SendFrame(request);
    var message = requestSocket.ReceiveFrameString();
    Console.WriteLine($"Message received : {message}");
    Console.ReadLine();
}

