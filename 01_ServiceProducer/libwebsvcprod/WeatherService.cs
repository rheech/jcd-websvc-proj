using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libwebsvcprod
{
    public class WeatherService
    {
        GlobalWeather.GlobalWeatherSoapClient client;

        public WeatherService()
        {
            client = new GlobalWeather.GlobalWeatherSoapClient();
        }

        public string GetCitiesByCountry(string CountryName)
        {
            return client.GetCitiesByCountry(CountryName);
        }
    }
}
