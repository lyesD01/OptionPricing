using OptionPricing.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.UI.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string AppName { get; private set; }
        public event PropertyChangedEventHandler? PropertyChanged;

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
        private double _stockPrice;
        public double StockPrice {
            get => _stockPrice;
            set => SetProperty(ref _stockPrice, value);
        }

        //Strike : 
        private double _strike;
        public double Strike
        {
            get => _strike;
            set => SetProperty(ref _strike, value);
        }

        //Volatility : 
        private double _volatility;
        public double Volatility
        {
            get => _volatility;
            set => SetProperty(ref _volatility, value);
        }

        //Risk Free Rate :
        private double _riskFreeRate;
        public double RiskFreeRate
        {
            get => _riskFreeRate;
            set => SetProperty(ref _riskFreeRate, value);
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
        private string _pricingModel;
        public string PricingModel
        {
            get => _pricingModel;
            set => SetProperty(ref _pricingModel, value);
        }

        private string _underlyingType;
        public string UnderlyingType
        {
            get => _underlyingType;
            set => SetProperty(ref _underlyingType, value);
        }

        private string _optionType;
        public string OptionType
        {
            get => _optionType;
            set => SetProperty(ref _optionType, value);
        }

        
        public MainViewModel()
        {
            AppName = "Option Pricer";
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



    }
}
