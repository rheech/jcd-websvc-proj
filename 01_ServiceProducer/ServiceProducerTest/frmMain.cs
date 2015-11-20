using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libwebsvcprod;
using System.Diagnostics;
using System.Xml;
using System.IO;
using libordermgmt;

namespace ServiceProducerTest
{
    // Turned off BindingFailure & IO Exception
    public partial class frmMain : Form
    {
        WeatherService wSvc;

        public frmMain()
        {
            InitializeComponent();

            //wSvc = new WeatherService();
            //libwebsvcprod.Weather2.WeatherSoapClient client = new libwebsvcprod.Weather2.WeatherSoapClient();
            //client.GetCityWeatherByZIP("76543");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*try
            {
                StringBuilder sb = new StringBuilder();
                string[] result;

                result = wSvc.GetCitiesByCountry("Korea");

                WeatherInformation info = wSvc.GetWeather(result[2], "Korea");

                sb.AppendFormat("Location: {0}\n", info.Location);
                sb.AppendFormat("Temperature: {0}\n", info.Temperature);
                sb.AppendFormat("Dewpoint: {0}\n", info.DewPoint);
                sb.AppendFormat("SkyConditions: {0}\n", info.SkyConditions);

                MessageBox.Show(sb.ToString());

                //XmlReader reader = XmlReader.Create(sb.ToString());

            }
            catch (Exception ex)
            {
            }*/
            OrderManager om = new OrderManager();

            om.Reset();

            CustomerInfo info = new CustomerInfo();
            info.CompanyName = "White House";
            info.Address = "1600 Pennsylvania Ave NW, Washington, DC 20500";
            info.EMail = "sample@email.com";

            /*info.CompanyName = "KAIST";
            info.Address = "291 Daehak-ro, Yuseong-gu, Daejeon, South Korea";
            info.EMail = "kaist@emailsample.com";*/

            om.CreateCustomer(info);
            om.FindCustomer(info);
            
        }
    }
}
