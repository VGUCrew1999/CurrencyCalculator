using System.Runtime.CompilerServices;
using System.Text;

namespace CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create and add to currency list
            List<Currency> currencies = new List<Currency>();
            currencies = AddCurrencies(currencies);


            int input = 0;

            //start menu
            do
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Currency Converter");
                Console.WriteLine("2. Print Log File");
                Console.WriteLine("3. Help");
                Console.WriteLine("4. Exit");



                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid Input. Please try again");
                    input = 0;
                }

                switch (input)
                {
                    case 1:
                        RunConverterMenu(currencies);
                        break;
                    case 2:
                        PrintLogFile();
                        break;
                    case 3:
                        ShowHelpMenu();
                        break;
                    case 4:
                        Console.WriteLine("Exiting Program.");
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid Selection. Please try again.");
                        break;
                }
            }
            while (input != 4);


        }

        static void RunConverterMenu(List<Currency> currencies)
        {

            //calculator menu
            bool continueRunning = true;
            do
            {
                Console.WriteLine("Currency Converter");
                
                foreach (Currency currency in currencies)
                {
                    Console.WriteLine(currency.Name + "-" + currency.Code);
                }
                Console.WriteLine();

                //capture first selected currency
                Console.WriteLine("Please select a currency by its code:");
                string input = Console.ReadLine().ToUpper();
                Currency currency1 = SelectValidCurrency(currencies, input);
                Console.WriteLine();

                //capture second selected currency
                Console.WriteLine("Please select a second currency by its code: ");
                input = Console.ReadLine().ToUpper();
                Currency currency2 = SelectValidCurrency(currencies, input);
                Console.WriteLine();

                //convert between currencies

                //exit the converter
                Console.WriteLine("Do you want to convert another currency?");
                input = Console.ReadLine().ToLower();

                if (input.StartsWith('n'))
                {
                    continueRunning = false;
                    Console.WriteLine("Exiting Converter.");
                    Console.WriteLine();
                }
            } while (continueRunning);


        }

        static double ConvertCurrencies(Currency currency1, Currency currency2)
        {
            return 1;
        }

        static Currency SelectValidCurrency(List<Currency> currencies, string selection)
        {
            var currQuery = from currency in currencies
                            where currency.Code == selection
                            select currency;
            Currency selectedCurrency = currQuery.FirstOrDefault();

            if(selectedCurrency == null)
            {
                //validate selected currency
                while(selectedCurrency == null)
                {
                    Console.WriteLine("Invalid Selection. Please try again.");
                    Console.WriteLine();
                    foreach (Currency currency in currencies)
                    {
                        Console.WriteLine(currency.Name + "-" + currency.Code);

                    }
                    Console.WriteLine("Please select a currency by its code:");
                    selection = Console.ReadLine().ToUpper();
                    currQuery = from currency in currencies
                                    where currency.Code == selection
                                    select currency;
                    selectedCurrency = currQuery.FirstOrDefault();
                }
            }

            return selectedCurrency;
        }

        

        static void PrintLogFile()
        {
            Console.WriteLine("Printing Log File.");
        }

        static void ShowHelpMenu()
        {
            Console.WriteLine("Help.");
        }

        static List<Currency> AddCurrencies(List<Currency> currencies)
        {
            //conversion rates as of March 21, 2023
            Currency USD = new Currency();
            USD.Name = "US Dollar";
            USD.ConversionRate = 1.00;
            USD.Code = "USD";
            currencies.Add(USD);

            Currency CanadianDollar = new Currency();
            CanadianDollar.Name = "Canadian Dollar";
            CanadianDollar.ConversionRate = 1.37;
            CanadianDollar.Code = "CAD";
            currencies.Add(CanadianDollar);

            Currency AustralianDollar = new Currency();
            AustralianDollar.Name = "Australian Dollar";
            AustralianDollar.ConversionRate = 1.50;
            AustralianDollar.Code = "AUD";
            currencies.Add(AustralianDollar);

            Currency Euro = new Currency();
            Euro.Name = "Euro";
            Euro.ConversionRate = 0.93;
            Euro.Code = "EUR";
            currencies.Add(Euro);

            Currency NZD = new Currency();
            NZD.Name = "New Zealand Dollar";
            NZD.ConversionRate = 1.61;
            NZD.Code = "NZD";
            currencies.Add(NZD);

            Currency MPeso = new Currency();
            MPeso.Name = "Mexican Peso";
            MPeso.ConversionRate = 18.61;
            MPeso.Code = "MXN";
            currencies.Add(MPeso);

            Currency RRuble = new Currency();
            RRuble.Name = "Russian Ruble";
            RRuble.ConversionRate = 77.25;
            RRuble.Code = "RUB";
            currencies.Add(RRuble);

            Currency won = new Currency();
            won.Name = "South Korean won";
            won.ConversionRate = 1303.58;
            won.Code = "KRW";
            currencies.Add(won);

            Currency Yen = new Currency();
            Yen.Name = "Japanese Yen";
            Yen.ConversionRate = 132.37;
            Yen.Code = "JPY";
            currencies.Add(Yen);

            Currency Shekel = new Currency();
            Shekel.Name = "Israeli New Shekel";
            Shekel.ConversionRate = 3.66;
            Shekel.Code = "ILS";
            currencies.Add(Shekel);

            Currency PPeso = new Currency();
            PPeso.Name = "Philippine Peso";
            PPeso.ConversionRate = 54.23;
            PPeso.Code = "PHP";
            currencies.Add(PPeso);

            Currency NKrone = new Currency();
            NKrone.Name = "Norwegian Krone";
            NKrone.ConversionRate = 10.55;
            NKrone.Code = "NOK";
            currencies.Add(NKrone);

            Currency DKrone = new Currency();
            DKrone.Name = "Danish Krone";
            DKrone.ConversionRate = 6.91;
            DKrone.Code = "DKK";
            currencies.Add(DKrone);
            
            Currency CPeso = new Currency();
            CPeso.Name = "Cuban Peso";
            CPeso.ConversionRate = 24.00;
            CPeso.Code = "CUP";
            currencies.Add(CPeso);

            Currency Krona = new Currency();
            Krona.Name = "Swedish Krona";
            Krona.ConversionRate = 10.35;
            Krona.Code = "SEK";
            currencies.Add(Krona);

            Currency BRuble = new Currency();
            BRuble.Name = "Belarusian Ruble";
            BRuble.ConversionRate = 2.52;
            BRuble.Code = "BYN";
            currencies.Add(BRuble);

            Currency Zloty = new Currency();
            Zloty.Name = "Polish Zloty";
            Zloty.ConversionRate = 1.61;
            Zloty.Code = "PLN";
            currencies.Add(Zloty);

            Currency Koruna = new Currency();
            Koruna.Name = "Czech Koruna";
            Koruna.ConversionRate = 22.12;
            Koruna.Code = "CZK";
            currencies.Add(Koruna);

            return currencies;
        }
    }
}