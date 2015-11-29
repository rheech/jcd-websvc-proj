using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libordermgmt;

namespace ServiceConsumerTest
{
    public partial class frmMain : Form
    {
        AdvertisingService.PurchasingServiceSoapClient client;

        public frmMain()
        {
            InitializeComponent();
            client = new AdvertisingService.PurchasingServiceSoapClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            //MessageBox.Show(client.createOrderDetails());
            //MessageBox.Show(client.CreateOrderDetails());
            MessageBox.Show(client.CreateDatabase("TestDB.mdb").ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DatabaseIO dbio = new DatabaseIO("test.mdb");
        }
    }
}
