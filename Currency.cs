using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    internal class Currency
    {
        public string Name { get; set; }
        public double ConversionRate { get; set; }

        //used for easy selection in the conversion menu
        public string Code { get; set; }



    }
}
