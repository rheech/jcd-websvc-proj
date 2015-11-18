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

namespace ServiceProducerTest
{
    // Turned off BindingFailure & IO Exception
    public partial class frmMain : Form
    {
        WeatherService wSvc;

        public frmMain()
        {
            InitializeComponent();

            wSvc = new WeatherService();
            //libwebsvcprod.Weather2.WeatherSoapClient client = new libwebsvcprod.Weather2.WeatherSoapClient();
            //client.GetCityWeatherByZIP("76543");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string[] result;

                result = wSvc.GetCitiesByCountry("Korea");
                MessageBox.Show(result[8]);

                MessageBox.Show(wSvc.GetWeather(result[8], "Korea"));

                //XmlReader reader = XmlReader.Create(sb.ToString());

            }
            catch (Exception ex)
            {
            }
        }
    }
}
