using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvertisingCompany.AdvertisingService;

namespace AdvertisingCompany
{
    public partial class frmMain : Form
    {
        OrderManagerServiceSoapClient om;

        public frmMain()
        {
            InitializeComponent();
            listView1.FullRowSelect = true;
            om = new OrderManagerServiceSoapClient();
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            OrderInfo[] orders;
            ListViewItem item;

            listView1.Items.Clear();
            orders = om.RetrieveOrder();

            foreach (OrderInfo o in orders)
            {
                item = new ListViewItem(o.Customer.CompanyName);
                item.SubItems.Add(o.Product.ProductName);
                item.SubItems.Add(o.Product.Price.ToString());
                item.SubItems.Add(o.OrderStatus);

                listView1.Items.Add(item);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
