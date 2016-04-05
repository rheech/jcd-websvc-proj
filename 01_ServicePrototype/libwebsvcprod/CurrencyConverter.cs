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
        decimal _rateUSD2KRW;
        decimal _rateEUR2KRW;

        public CurrencyConverter()
        {
            _client = new ConverterSoapClient();
            _rateUSD2KRW = _client.GetConversionRate("USD", "KRW", DateTime.Now);
            _rateEUR2KRW = _client.GetConversionRate("EUR", "KRW", DateTime.Now);
        }

        public decimal DollarToWon(decimal money)
        {
            return money * _rateUSD2KRW;
        }

        public decimal EuroToWon(decimal money)
        {
            return money * _rateEUR2KRW;
        }
    }
}
