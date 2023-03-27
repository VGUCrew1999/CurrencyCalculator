using System.Runtime.CompilerServices;

namespace CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create and add to currency list
            List<Currency> currencies = new List<Currency>();
            currencies = AddCurrencies(currencies);


            foreach (Currency currency in currencies)
            {
                Console.WriteLine(currency.Name + " " + currency.ConversionRate);
            }

            //start menu




        }

        static void RunMenu(List<Currency> currencies)
        {

            
            //calculator menu

        }

        static List<Currency> AddCurrencies(List<Currency> currencies)
        {
            //conversion rates as of March 21, 2023
            Currency USD = new Currency();
            USD.Name = "US Dollar";
            USD.ConversionRate = 1.00;
            currencies.Add(USD);

            Currency CanadianDollar = new Currency();
            CanadianDollar.Name = "Canadian Dollar";
            CanadianDollar.ConversionRate = 1.37;
            currencies.Add(CanadianDollar);

            Currency AustralianDollar = new Currency();
            AustralianDollar.Name = "Australian Dollar";
            AustralianDollar.ConversionRate = 1.50;
            currencies.Add(AustralianDollar);

            Currency Euro = new Currency();
            Euro.Name = "Euro";
            Euro.ConversionRate = 0.93;
            currencies.Add(Euro);

            Currency NZD = new Currency();
            NZD.Name = "New Zealand Dollar";
            NZD.ConversionRate = 1.61;
            currencies.Add(NZD);

            Currency MPeso = new Currency();
            MPeso.Name = "Mexican Peso";
            MPeso.ConversionRate = 18.61;
            currencies.Add(MPeso);

            Currency RRuble = new Currency();
            RRuble.Name = "Russian Ruble";
            RRuble.ConversionRate = 77.25;
            currencies.Add(RRuble);

            Currency won = new Currency();
            won.Name = "South Korean won";
            won.ConversionRate = 1303.58;
            currencies.Add(won);

            Currency Yen = new Currency();
            Yen.Name = "Japanese Yen";
            Yen.ConversionRate = 132.37;
            currencies.Add(Yen);

            Currency Shekel = new Currency();
            Shekel.Name = "Israeli New Shekel";
            Shekel.ConversionRate = 3.66;
            currencies.Add(Shekel);

            Currency PPeso = new Currency();
            PPeso.Name = "Philippine Peso";
            PPeso.ConversionRate = 54.23;
            currencies.Add(PPeso);

            Currency NKrone = new Currency();
            NKrone.Name = "Norwegian Krone";
            NKrone.ConversionRate = 10.55;
            currencies.Add(NKrone);

            Currency DKrone = new Currency();
            DKrone.Name = "Danish Krone";
            DKrone.ConversionRate = 6.91;
            currencies.Add(DKrone);
            
            Currency CPeso = new Currency();
            CPeso.Name = "Cuban Peso";
            CPeso.ConversionRate = 24.00;
            currencies.Add(CPeso);

            Currency Krona = new Currency();
            Krona.Name = "Swedish Krona";
            Krona.ConversionRate = 10.35;
            currencies.Add(Krona);

            Currency BRuble = new Currency();
            BRuble.Name = "Belarusian Ruble";
            BRuble.ConversionRate = 2.52;
            currencies.Add(BRuble);

            Currency Zloty = new Currency();
            Zloty.Name = "Polish Zloty";
            Zloty.ConversionRate = 1.61;
            currencies.Add(Zloty);

            Currency Koruna = new Currency();
            Koruna.Name = "Czech Koruna";
            Koruna.ConversionRate = 22.12;
            currencies.Add(Koruna);

            return currencies;
        }
    }
}