using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientCompany.AdvertisingService;

namespace ClientCompany
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AdvertisingService.OrderInfo info;

            info = new OrderInfo();
            info.Customer = new CustomerInfo();

            AdvertisingService.PurchasingServiceSoapClient client = new PurchasingServiceSoapClient();
            info.Requirement = "ASDF";

            MessageBox.Show(client.RequestOrder(info));
        }
    }
}
