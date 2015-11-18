using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace libwebsvcprod
{
    public class WeatherService
    {
        GlobalWeather.GlobalWeatherSoapClient client;
        
        public WeatherService()
        {
            client = new GlobalWeather.GlobalWeatherSoapClient();
        }

        public string[] GetCitiesByCountry(string CountryName)
        {
            List<string> sList;
            string result;
            XmlTextReader reader;

            result = client.GetCitiesByCountry(CountryName);
            reader = new XmlTextReader(new StringReader(result));
            sList = new List<string>();


            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "City")
                {
                    reader.Read();
                    sList.Add(reader.Value);
                }
            }

            return sList.ToArray();
        }

        public string GetWeather(string CityName, string CountryName)
        {
            return client.GetWeather(CityName, CountryName);
        }
    }
}
