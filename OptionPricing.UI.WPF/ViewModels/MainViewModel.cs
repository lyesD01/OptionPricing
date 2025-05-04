using CommunityToolkit.Mvvm.Input;
using OptionPricing.Domain;
using OptionPricing.Transport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Xml.Schema;

namespace OptionPricing.UI.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ITransport _myTransporter;


        public string AppName { get; private set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Binded-Properties
        //Trader Name : 
        private string _famillyName;
        public string FamillyName
        {
            get => _famillyName;
            set => SetProperty(ref _famillyName, value);
        }

        //Trader First name : 
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        //Desk Name : 
        private string _deskName;
        public string DeskName
        {
            get => _deskName;
            set => SetProperty(ref _deskName, value);
        }

        //Stock Price : 
        private float _stockPrice;
        public float StockPrice
        {
            get => _stockPrice;
            set => SetProperty(ref _stockPrice, value);
        }

        //Strike : 
        private float _strike;
        public float Strike
        {
            get => _strike;
            set => SetProperty(ref _strike, value);
        }

        //Volatility : 
        private float _volatility;
        public float Volatility
        {
            get => _volatility;
            set => SetProperty(ref _volatility, value);
        }

        //Risk Free Rate :
        private float _riskFreeRate;
        public float RiskFreeRate
        {
            get => _riskFreeRate;
            set => SetProperty(ref _riskFreeRate, value);
        }

        private float _premium;
        public float Premium
        {
            get => _premium;
            set => SetProperty(ref _premium, value);
        }

        //Maturity : 
        private DateTime _maturity = DateTime.Today;
        public DateTime Maturity
        {
            get => _maturity;
            set => SetProperty(ref _maturity, value);
        }

        //Pricing Date :
        private DateTime _pricingDate = DateTime.Today;
        public DateTime PricingDate
        {
            get => _pricingDate;
            set => SetProperty(ref _pricingDate, value);
        }


        //Pricing model:
        private PricingModel _pricingModel;
        public PricingModel PricingModel
        {
            get => _pricingModel;
            set => SetProperty(ref _pricingModel, value);
        }
        
        // Underlying Type :
        private UnderlyingType _underlyingType;
        public UnderlyingType UnderlyingType
        {
            get => _underlyingType;
            set => SetProperty(ref _underlyingType, value);
        }

        //Option Type :
        private OptionType _optionType;
        public OptionType OptionType
        {
            get => _optionType;
            set => SetProperty(ref _optionType, value);
        } 

        //Number Of Simulations : 
        private int _numberOfSimulations = 1;
        public int Number_OfSimulations
        {
            get => _numberOfSimulations;
            set => SetProperty(ref _numberOfSimulations, value);
        }

        #endregion


        public MainViewModel(ITransport transporter)
        {
            AppName = "Option Pricer";
            _myTransporter = transporter;
            PriceButton = new RelayCommand(OnClickButton);
        }
         
        private void OnClickButton()
        {
            Desk desk = new Desk(DeskName);
            Trader trader = new Trader(FirstName, FamillyName, desk);

            InitialStockPrice initialStockPrice = new InitialStockPrice(StockPrice);
            ImpliedVolatility implied_volatility = new ImpliedVolatility(Volatility);
            Maturity maturity = new Maturity(Maturity);
            Strike strike_ = new Strike(Strike);
            PricingDate pricingDate = new PricingDate(PricingDate);
            RiskFreeRate riskFreeRate = new RiskFreeRate(RiskFreeRate);


            UnderlyingType underlyingType = UnderlyingType;
            PricingModel model = PricingModel;


            Underlying underlying = new Underlying(initialStockPrice, implied_volatility, riskFreeRate, underlyingType);

            OptionType optionType = OptionType;
            Option option = new Option(trader, strike_, maturity, optionType, underlying);

            NumberOfSimulations numberOfSimulations = new NumberOfSimulations(Number_OfSimulations);
 
            Pricing pricing = new Pricing(option, model, pricingDate, numberOfSimulations);
            pricing = _myTransporter.Connect("localhost", 5555, pricing);
            Premium = pricing.premium.premium;

        }

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue) )
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        public ICommand PriceButton { get; set; }



    }
}
