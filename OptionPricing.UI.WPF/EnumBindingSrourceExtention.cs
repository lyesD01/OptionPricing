using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace OptionPricing.UI.WPF
{
    public class EnumBindingSrourceExtention : MarkupExtension
    {

        public Type EnumType { get; private set; }

        public EnumBindingSrourceExtention(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
                throw new Exception("Enum Type must be non null");
            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
