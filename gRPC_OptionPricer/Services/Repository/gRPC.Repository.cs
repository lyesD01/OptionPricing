using Google.Protobuf.WellKnownTypes;
using GRPC.OptionPricer.Protos;
using Grpc.Core;
using OptionPricingDAO;
using OptionPricing.Domain;
using OptionPricing.Repository;
using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;



namespace GRPC.OptionPricer.Services.Repository
{
    public class RepositoryService : rpcRepositoryCalls.rpcRepositoryCallsBase
    {
        //private readonly IList<PricingParameters> _pricingParameters = [];

        private readonly IPricingRepository? _pricingRepository;
        private IPricingDAO? _pricingDAO;
        private PricingDTO? _pricingDTO;
        public override Task<InsertPricingParametersResponse> InsertPricingParameters(InsertPricingParametersRequest InsertedtParameters, ServerCallContext context)
        {
            
            try
            {
                Desk deskName = new Desk(InsertedtParameters.DeskName);
                ImpliedVolatility impliedVolatility = new ImpliedVolatility(InsertedtParameters.ImpliedVolatility);
                InitialStockPrice stockPrice = new InitialStockPrice(InsertedtParameters.StockPrice);
                Premium premium = new Premium(InsertedtParameters.Premium);
                RiskFreeRate riskFreeRate = new RiskFreeRate(InsertedtParameters.RiskFreeRate);
                Maturity maturity = new Maturity(
                    DateTime.ParseExact(InsertedtParameters.MaturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    );
                PricingDate pricingDate = new PricingDate(
                    DateTime.ParseExact(InsertedtParameters.PricingDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    );
                Strike strike = new Strike(InsertedtParameters.Strike);

                OptionType optionType = System.Enum.TryParse<OptionType>(InsertedtParameters.OptionType, true, out var optionTypeValue) ? optionTypeValue : 
                    OptionType.Unkown;
                UnderlyingType underlyingType = System.Enum.TryParse<UnderlyingType>(InsertedtParameters.UnderlyingType, true, out var underlyingTypeValue) ? underlyingTypeValue :
                    UnderlyingType.Unknown;
                PricingModel pricingModel = System.Enum.TryParse<PricingModel>(InsertedtParameters.ModelType, true, out var pricingModelValue) ? pricingModelValue :
                    PricingModel.Unknown;

                Trader trader = new Trader(InsertedtParameters.FirstName, InsertedtParameters.SecondName, deskName);
                Underlying underlying = new Underlying(stockPrice, impliedVolatility, riskFreeRate, underlyingType);
                OptionPricing.Domain.Option option = new OptionPricing.Domain.Option(trader, strike, maturity, optionType, underlying); //Naming ambuigity between Domain.Option and google.Protobuff.WellKnownTypes.Option...
                Pricing pricingParameters = new Pricing(option, pricingModel, pricingDate, premium);

                int IdOfTrade = _pricingRepository.InsertPricing(pricingParameters);
                var response = new InsertPricingParametersResponse() { Id = IdOfTrade };
                return Task.FromResult(response);
            }
            catch (ArgumentException ex) {
                throw new RpcException(new Status(StatusCode.InvalidArgument, ex.Message));
            }
            catch (ValidationException ex)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, ex.Message));
            }
            catch (FormatException ex)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, ex.Message));
            }
            
        }

        
        public override Task<PricingParameters> GetPricingParameters(GetPricingParamRequest request, ServerCallContext context)
        {
            //_pricingParametersDTO = _pricingDAO.GetPricing_info(request.Id);

            Pricing pricingParameters = _pricingRepository.GetPricingById(request.Id);

            if (pricingParameters == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Requested Trade not Found"));
            }

            var response = new PricingParameters()
            {
                Id = request.Id,
                DeskName = pricingParameters.option.trader.deskName.value,
                FirstName = pricingParameters.option.trader.firstName, 
                SecondName = pricingParameters.option.trader.SecondName,
                StockPrice = pricingParameters.option.underlying.initialStockPrice.Value,
                RiskFreeRate = pricingParameters.option.underlying.riskFreeRate.Value,
                ImpliedVolatility = pricingParameters.option.underlying.impliedVolatility.Value,
                MaturityDate = pricingParameters.option.maturity.Value.ToString(),
                Strike = pricingParameters.option.strike.Value,
                PricingDate = pricingParameters.pricingDate.Value.ToString(),
                Premium = pricingParameters.premium.Value,
                ModelType = pricingParameters.model.ToString(),
                OptionType = pricingParameters.option.optionType.ToString(),
                UnderlyingType = pricingParameters.option.underlying.underlyingType.ToString(),

            };

            return Task.FromResult(response);
        }


    }
}
