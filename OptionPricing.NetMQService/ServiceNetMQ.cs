
﻿//using NetMQ;
//using NetMQ.Sockets;

//public class Program
//{
=======
﻿using NetMQ;
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
registration.Register<IPrice, BSMonteCarloService>(PricingModel.Monte_Carlo);
//registration.Register<IPrice, HJM_PricingService>(PricingModel.Heston);

//    private static void Main(string[] args)
//    {
//        using(var responseSocket = new ResponseSocket("@tcp://*:5555") )
//        {
//            var message = responseSocket.ReceiveFrameString();  // J'attend de recevoir tes requettes.
//            Console.WriteLine($"Message Received : {message}");
//            responseSocket.SendFrame("Hello Back From Servers...Test234 Commit");
//            Console.ReadLine();
//        }
//    }
//}

