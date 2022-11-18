using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionPricing.Infrastructure;
using OptionPricing.Transport;

namespace OptionPricing.UI.WPF.ViewModels
{
    public class ViewModelLocator
    {
        public MainViewModel Main => Ioc.Default.GetService<MainViewModel>();
        public ViewModelLocator()
        {
            Ioc.Default.ConfigureServices(
                (IServiceProvider)new ServiceCollection()
                
                // Dependancies : 
                .AddSingleton<IOptionPricingSerialiser, OptionPricingSerialiser>()
                .AddSingleton<ITransport, OptionPricingTransport>()

                // View Models : 
                .AddTransient<MainViewModel>()

                // building Servicer : 
                .BuildServiceProvider()

                );

        }
    }
}
