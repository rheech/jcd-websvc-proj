using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libwebsvcprod.CurrencyConverterSvc;

namespace libwebsvcprod
{
    public class CurrencyConverter
    {
        CurrencyConverterSvc.ConverterSoapClient _client;
        decimal _conversionRate;

        public CurrencyConverter()
        {
            _client = new ConverterSoapClient();
            _conversionRate = _client.GetConversionRate("USD", "KRW", DateTime.Now);
        }

        public decimal DollarToWon(decimal money)
        {
            return money * _conversionRate;
        }
    }
}
