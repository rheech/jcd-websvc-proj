using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libordermgmt;

namespace AdvertisingCompanyLocal
{
    public partial class frmMain : Form
    {
        OrderManager om;

        public frmMain()
        {
            InitializeComponent();
            lvOrders.FullRowSelect = true;
            om = new OrderManager();
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            RefreshOrderList();
        }

        private void RefreshOrderList()
        {
            OrderInfo[] orders = om.RetrieveOrder();
            ListViewItem item;

            lvOrders.Items.Clear();

            foreach (OrderInfo o in orders)
            {
                item = new ListViewItem(o.Customer.CompanyName);
                item.SubItems.Add(o.Product.ProductName);
                item.SubItems.Add(o.Product.Price.ToString());
                item.SubItems.Add(o.OrderStatus);

                lvOrders.Items.Add(item);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            RefreshOrderList();
        }
    }
}
