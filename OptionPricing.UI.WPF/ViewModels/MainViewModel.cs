using OptionPricing.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.UI.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string AppName { get; private set; }

        private double _stockPrice;

        public event PropertyChangedEventHandler? PropertyChanged;

        public double StockPrice {
            get => _stockPrice;
            set => SetProperty(ref _stockPrice, value);
        }

        private string _pricingModel;
        public enum EnumPricingModel { Black_Scholes, HJM, Heston}
        public string PricingModel
        {
            get => _pricingModel;
            set => SetProperty(ref _pricingModel, value);
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
