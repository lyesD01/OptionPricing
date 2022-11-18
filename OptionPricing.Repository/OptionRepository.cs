using OptionPricingDAO;
using OptionPricing.Domain;


namespace OptionPricing.Repository;
public interface IPricingRepository
{
    int InsertPricing(Pricing pricing);
    Pricing GetPricingById(int pricingId);
}

public class PricingRepository : IPricingRepository
{
    private readonly IPricingDAO _optionDAO;

    public PricingRepository(IPricingDAO optionDAO)
    {
        _optionDAO = optionDAO;

    }

    public int InsertPricing(Pricing pricing)
    {
        var pricingDTO = new PricingDTO();
        pricingDTO.DeskName = pricing.option.trader.deskName.deskName;
        pricingDTO.FirstName = pricing.option.trader.firstName;
        pricingDTO.SecondName = pricing.option.trader.familyName;
        pricingDTO.DatePricing = pricing.pricingDate.Value;
        pricingDTO.StockPrice = pricing.option.underlying.initialStockPrice.Value;
        pricingDTO.RiskFreeRate = pricing.option.underlying.riskFreeRate.Value;
        pricingDTO.ImpliedVolatility = pricing.option.underlying.impliedVolatility.Value;
        pricingDTO.Strike = pricing.option.strike.Value;
        pricingDTO.Maturity = pricing.option.maturity.Value;
        pricingDTO.Premium = pricing.premium.Value;
        pricingDTO.ModelType = pricing.model.ToString();
        pricingDTO.OptionType = pricing.option.optionType.ToString();
        pricingDTO.UnderlyingType = pricing.option.underlying.underlyingType.ToString();

        return _optionDAO.InsertPricing(pricingDTO);
    }


    public Pricing GetPricingById(int pricingId)
    {
        var pricingDTO = _optionDAO.GetPricing_info(pricingId);

        Desk desk = new Desk(pricingDTO.DeskName);
        Trader trader = new Trader(pricingDTO.FirstName, pricingDTO.SecondName, desk);

        InitialStockPrice initialStockPrice = new InitialStockPrice(pricingDTO.StockPrice);
        ImpliedVolatility implied_volatility = new ImpliedVolatility(pricingDTO.ImpliedVolatility);
        
        Maturity maturity = new Maturity(pricingDTO.Maturity);
        Strike strike_ = new Strike(pricingDTO.Strike) ;
        PricingDate pricingDate = new PricingDate(pricingDTO.DatePricing);
        RiskFreeRate riskFreeRate = new RiskFreeRate(pricingDTO.RiskFreeRate);
       
        
        Premium premium = new Premium(pricingDTO.Premium);
        UnderlyingType underlyingType = (UnderlyingType)Enum.Parse(typeof(UnderlyingType), pricingDTO.UnderlyingType);
        PricingModel model = (PricingModel)Enum.Parse(typeof(PricingModel), pricingDTO.ModelType);
        Underlying underlying = new Underlying(initialStockPrice, implied_volatility, riskFreeRate, underlyingType);

        OptionType optionType = (OptionType)Enum.Parse(typeof(OptionType), pricingDTO.OptionType);
        Option option = new Option(trader, strike_, maturity, optionType, underlying);
        Pricing pricing = new Pricing(option, model, pricingDate);

        return pricing;
    }

}