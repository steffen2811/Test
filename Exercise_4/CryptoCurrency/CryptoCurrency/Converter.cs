using System;
using System.Collections;

namespace CryptoCurrency
{
    public class Converter
    {

        private Hashtable currencies = new Hashtable();

        /// <summary>
        /// Angiver prisen for en enhed af en kryptovaluta. Prisen angives i dollars.
        /// Hvis der tidligere er angivet en værdi for samme kryptovaluta, 
        /// bliver den gamle værdi overskrevet af den nye værdi
        /// </summary>
        /// <param name="currencyName">Navnet på den kryptovaluta der angives</param>
        /// <param name="price">Prisen på en enhed af valutaen målt i dollars. Prisen kan ikke være negativ</param>
        public void SetPricePerUnit(String currencyName, double price)
        {
            if (price < 0)
                throw new ArgumentException("It is not possible to set a negative price");
            if (currencies.ContainsKey(currencyName))
                currencies[currencyName] = price;
            else
                currencies.Add(currencyName, price);

        }

        /// <summary>
        /// Konverterer fra en kryptovaluta til en anden. 
        /// Hvis en af de angivne valutaer ikke findes, kaster funktionen en ArgumentException
        /// 
        /// </summary>
        /// <param name="fromCurrencyName">Navnet på den valuta, der konverterers fra</param>
        /// <param name="toCurrencyName">Navnet på den valuta, der konverteres til</param>
        /// <param name="amount">Beløbet angivet i valutaen angivet i fromCurrencyName</param>
        /// <returns>Værdien af beløbet i toCurrencyName</returns>
        public double Convert(String fromCurrencyName, String toCurrencyName, double amount)
        {
            double valueInDollars = 0;

            if (amount < 0)
                throw new ArgumentException("It is not possible to set a negative amount");
            if (!currencies.ContainsKey(fromCurrencyName))
                throw new ArgumentException(fromCurrencyName + " is not a known currency");
            else if (!currencies.ContainsKey(toCurrencyName))
                throw new ArgumentException(toCurrencyName + " is not a known currency");
            else
            {
                valueInDollars = double.Parse(currencies[fromCurrencyName].ToString()) * amount;

                if (double.Parse(currencies[toCurrencyName].ToString()) != 0) // Avoid devided by 0
                    return valueInDollars / double.Parse(currencies[toCurrencyName].ToString());
                else
                    return double.MaxValue;
            }
        }
    }
}