using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using WindowsFormsApplication5.AdvertisingService;

// XmlSerializer File Not Found Exception
// Tools > Options > Debugging > Enable Just My Code
// Debug > Exceptions > Uncheck Managed Debugging Assistants

// http://websky.kma.go.kr/services/ForecastService?wsdl
// http://blog.naver.com/humy2833/140199879232
// http://www.webservicex.net/globalweather.asmx?WSDL
// http://www.webservicex.net/globalweather.asmx?op=GetWeather


namespace WindowsFormsApplication5
{
    [XmlRoot(Namespace = "http://www.webservicex.net/")]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            //XmlSerializer s = XmlSerializer.FromTypes(new[] { typeof(CustomXMLSerializeObject) })[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AdvertisingService.AdvertisingServiceSoapClient client2 = new AdvertisingServiceSoapClient();

            MessageBox.Show(client2.HelloWorld());

            string s = "";
            GlobalWeather2.GlobalWeatherSoapClient client = new GlobalWeather2.GlobalWeatherSoapClient();

            try
            {
                s = client.GetWeather("Taejon", "Korea");
            }
            catch (Exception)
            {
            }

            MessageBox.Show(s);
        }
    }
}
