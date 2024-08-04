using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Localization
{
    public class AppLocalization<T> where T : class
    {
        public IStringLocalizer<T> Localizer { get; }

        public AppLocalization(IStringLocalizer<T> localizer)
        {
            Localizer = localizer;
        }
    }
    
}
