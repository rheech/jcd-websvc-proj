using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace libwebsvcprod
{
    public class WeatherInformation
    {
        /*
            Location
            Time
            Wind
            Visibility
            SkyConditions
            Temperature
            DewPoint
            RelativeHumidity
            Pressure
            Status
         */
        private string _location;
        private string _time;
        private string _wind;
        private string _visibility;
        private string _skyConditions;
        private string _temperature;
        private string _dewPoint;
        private string _relativeHumidity;
        private string _pressure;
        private string _status;
        private string _xml;

        public WeatherInformation(string xml)
        {
            List<string> sList;
            XmlTextReader reader;

            _xml = xml;

            reader = new XmlTextReader(new StringReader(xml));
            sList = new List<string>();


            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "Location":
                            reader.Read();
                            _location = reader.Value;
                            break;
                        case "Time":
                            reader.Read();
                            _time = reader.Value;
                            break;
                        case "Wind":
                            reader.Read();
                            _wind = reader.Value;
                            break;
                        case "Visibility":
                            reader.Read();
                            _visibility = reader.Value;
                            break;
                        case "SkyConditions":
                            reader.Read();
                            _skyConditions = reader.Value;
                            break;
                        case "Temperature":
                            reader.Read();
                            _temperature = reader.Value;
                            break;
                        case "DewPoint":
                            reader.Read();
                            _dewPoint = reader.Value;
                            break;
                        case "RealtiveHumidity":
                            reader.Read();
                            _relativeHumidity = reader.Value;
                            break;
                        case "Pressure":
                            reader.Read();
                            _pressure = reader.Value;
                            break;
                        case "Status":
                            reader.Read();
                            _status = reader.Value;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public string GetXML()
        {
            return _xml;
        }

        public string Location
        {
            get
            {
                return _location;
            }
        }

        public string Time
        {
            get
            {
                return _time;
            }
        }

        public string Wind
        {
            get { return _wind; }
            set { _wind = value; }
        }

        public string Visibility
        {
            get { return _visibility; }
            set { _visibility = value; }
        }

        public string SkyConditions
        {
            get { return _skyConditions; }
            set { _skyConditions = value; }
        }

        public string Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        public string DewPoint
        {
            get { return _dewPoint; }
            set { _dewPoint = value; }
        }

        public string RelativeHumidity
        {
            get { return _relativeHumidity; }
            set { _relativeHumidity = value; }
        }

        public string Pressure
        {
            get { return _pressure; }
            set { _pressure = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }

    public class WeatherService
    {
        GlobalWeatherSvc.GlobalWeatherSoapClient client;
        
        public WeatherService()
        {
            client = new GlobalWeatherSvc.GlobalWeatherSoapClient();
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

        public WeatherInformation GetWeather(string CityName, string CountryName)
        {
            string result;
            result = client.GetWeather(CityName, CountryName);

            return new WeatherInformation(result);
        }
    }
}
