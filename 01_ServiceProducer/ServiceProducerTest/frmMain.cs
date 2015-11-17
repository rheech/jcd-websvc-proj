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

namespace ServiceProducerTest
{
    // Install Nuget Package
    public partial class frmMain : Form
    {
        WeatherService wSvc;

        public frmMain()
        {
            InitializeComponent();

            //wSvc = new WeatherService();
            libwebsvcprod.Weather2.WeatherSoapClient client = new libwebsvcprod.Weather2.WeatherSoapClient();
            client.GetCityWeatherByZIP("76543");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(wSvc.GetCitiesByCountry("Korea"));
            }
            catch (Exception ex)
            {
            }
        }
    }
}
