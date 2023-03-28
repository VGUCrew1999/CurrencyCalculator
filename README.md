# CurrencyCalculator
A console app for converting between currencies.

Instructions for the main menu:
Enter a number to choose between the converter menu, printing the log file, the help menu, or exiting the program.

Instructions for the converter menu:
Each currency will be listed along with its currency code, followed by a prompt asking for a selection. Entering a currency's code will select it. Then a prompt asking for the amount you would like to convert will appear. Then a prompt asking for a second currency will appear. Entering another currency code will select it. The program will then display the approximate value of currency 2, relative to currency 1.

Notes:
The conversion rates are from March 21, 2023.
The conversion process changes currency 1 to US Dollars, then to currency 2 for simplicity.
The default location for the log file is under bin/debug/net6.0 folder, but it can be changed under the GetFilePath method.
If an invalid input is entered on the main or converter menu, it will display a message and ask for a new input.
