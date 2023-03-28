using System;
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
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Currency Converter");
                Console.WriteLine("2. Print Log File");
                Console.WriteLine("3. Help");
                Console.WriteLine("4. Exit");
                string logMessage = "";
                

                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid Input. Please try again.");
                    Console.WriteLine();
                    logMessage = DateTime.Now + ": Entered an invalid input on the main menu.";
                    WriteToLog(logMessage);
                    continue;
                }

                //check inputs
                switch (input)
                {
                    case 1:
                        Console.WriteLine();
                        logMessage = DateTime.Now + ": Entered the converter menu.";
                        WriteToLog(logMessage);
                        RunConverterMenu(currencies);

                        break;
                    case 2:
                        Console.WriteLine();
                        logMessage = DateTime.Now + ": Printed the log file.";
                        WriteToLog(logMessage);
                        PrintLogFile();
                        break;
                    case 3:
                        Console.WriteLine();
                        logMessage = DateTime.Now + ": Entered the help menu.";
                        WriteToLog(logMessage);
                        ShowHelpMenu();
                        break;
                    case 4:
                        Console.WriteLine("Exiting Program.");
                        logMessage = DateTime.Now + ": Exited the program.";
                        WriteToLog(logMessage);
                        break;
                    default:
                        Console.WriteLine("Invalid Selection. Please try again.");
                        Console.WriteLine();
                        logMessage = DateTime.Now + ": Entered an invalid selection on the main menu.";
                        WriteToLog(logMessage);
                        break;
                }
                
            }
            while (input != 4);
        }

        static void RunConverterMenu(List<Currency> currencies)
        {

            //converter menu
            bool continueRunning = true;
            do
            {
                Console.WriteLine("Currency Converter:");
                string logMessage = "";
                
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
                logMessage = DateTime.Now + ": Selected " + currency1.Code + " as first currency.";
                WriteToLog(logMessage);

                //capture the value to convert between
                double amount = GetValidCurrencyAmount();
                logMessage = DateTime.Now + ": Entered " + amount + " to convert.";
                WriteToLog(logMessage);

                //capture second selected currency
                Console.WriteLine("Please select a second currency by its code: ");
                input = Console.ReadLine().ToUpper();
                Currency currency2 = SelectValidCurrency(currencies, input);
                Console.WriteLine();
                logMessage = DateTime.Now + ": Selected " + currency2.Code + " as second currency.";
                WriteToLog(logMessage);

                //convert between currencies
                double result = ConvertCurrencies(currency1, currency2, amount);
                logMessage = DateTime.Now + ": Converted " + amount + " " + currency1.Code + " to " + result + " " + currency2.Code + ".";
                WriteToLog(logMessage);

                //print results
                Console.WriteLine(amount + " " + currency1.Code + " is approximately " + result + " " + currency2.Code + ".");
                Console.WriteLine();
                
                //determine if use wants to continue
                Console.WriteLine("Do you want to convert another currency (y/n)?");
                input = Console.ReadLine().ToLower();

                //validate their selection
                while(!input.StartsWith("y") && !input.StartsWith('n'))
                {
                    logMessage = DateTime.Now + ": Entered invalid input for converting another currency.";
                    WriteToLog(logMessage);
                    Console.WriteLine("Invalid Input. Please try again.");
                    Console.WriteLine("Do you want to convert another currency (y/n)?");
                    input = Console.ReadLine().ToLower();
                    Console.WriteLine();
                }

                if (input.StartsWith('n'))
                {
                    logMessage = DateTime.Now + ": Exited the converter menu.";
                    WriteToLog(logMessage);
                    continueRunning = false;
                    Console.WriteLine("Exiting Converter.");
                    Console.WriteLine();
                }
                logMessage = DateTime.Now + ": Started converting another currency.";
                WriteToLog(logMessage);
            } while (continueRunning);
        }

        //converts to US Dollars before converting to the target currency, for simplicity
        static double ConvertCurrencies(Currency currency1, Currency currency2, double amount)
        {
            return (amount * currency2.ConversionRate) / currency1.ConversionRate;
        }

        //make sure the user's selection is a currency in the list
        static Currency SelectValidCurrency(List<Currency> currencies, string selection)
        {
            string logMessage = "";
            var currQuery = from currency in currencies
                            where currency.Code == selection
                            select currency;
            Currency selectedCurrency = currQuery.FirstOrDefault();

            if(selectedCurrency == null)
            {
                //validate selected currency
                while(selectedCurrency == null)
                {
                    logMessage = DateTime.Now + ": Entered an invalid input during currency selection.";
                    WriteToLog(logMessage);
                    Console.WriteLine();
                    Console.WriteLine("Invalid Selection. Please try again.");
                    Console.WriteLine();
                    foreach (Currency currency in currencies)
                    {
                        Console.WriteLine(currency.Name + "-" + currency.Code);

                    }
                    Console.WriteLine();
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

        //make sure the amount is valid and not a letter by mistake
        static double GetValidCurrencyAmount()
        {
            double validAmount = 0;
            string logMessage = "";
            while(validAmount <= 0)
            {
                Console.WriteLine("How much money do you want to convert?");
                String input = Console.ReadLine();
                try
                {
                    validAmount = Double.Parse(input);
                }
                catch(FormatException e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid Amount. Please try again.");
                    Console.WriteLine();
                    logMessage = DateTime.Now + ": Entered an invalid input for the currency amount.";
                    WriteToLog(logMessage);
                    continue;
                }
                if (validAmount <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("The amount must be greater than 0");
                    Console.WriteLine();
                    logMessage = DateTime.Now + ": Entered an invalid value for the currency amount.";
                    WriteToLog(logMessage);
                }

            }
            Console.WriteLine();
            return validAmount;
        }

        //universal for sending data to the log file from all methods
        static void WriteToLog(string message)
        {
            string filePath = GetFilePath();
            if(!File.Exists(filePath))
            {
                File.CreateText(filePath).Close();
            }
            StreamWriter writer = File.AppendText(filePath);
            writer.WriteLine(message);
            writer.Close();
        }

        static void PrintLogFile()
        {
            string filePath = GetFilePath();
            if (!File.Exists(filePath))
            {
                File.CreateText(filePath);
            }
            StreamReader reader = File.OpenText(filePath);
            string logText = "";
            Console.WriteLine("Beginning of Log File.");
            Console.WriteLine("----------------------");
            while((logText = reader.ReadLine()) != null)
            {
                Console.WriteLine(logText);
            }
            reader.Close();
            Console.WriteLine("----------------------");
            Console.WriteLine("End of Log File.");
            Console.WriteLine();
        }

        static void ShowHelpMenu()
        {
            
            Console.WriteLine("Help Menu:");
            Console.WriteLine("This program converts between a list of currencies based on their conversion rates from March 21, 2023.");
            Console.WriteLine("It uses each currency's code for the selection process.");
            Console.WriteLine("The conversion process converts every currency to a common unit. For simplicity, it uses US Dollars.");
            Console.WriteLine("By default the log file prints to the debug folder.");
            Console.WriteLine("You can change this by updating GetFilePath().");
            Console.WriteLine("Press enter to leave this menu.");
            Console.ReadLine();
            Console.WriteLine();
            string logMessage = DateTime.Now + ": Exited the help menu.";
            WriteToLog(logMessage);
        }

        //create the list of currencies in the program
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

        //change this if you want to print the log file to other locations
        static string GetFilePath()
        {
            return @"LogFile.txt";
        }
    }
}