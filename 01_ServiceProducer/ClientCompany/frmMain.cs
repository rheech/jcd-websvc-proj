using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libordermgmt;

namespace ClientCompany
{
    public partial class frmMain : Form
    {
        OrderManager om;
        CustomerInfo Customer;

        public frmMain()
        {
            InitializeComponent();

            om = new OrderManagerSampleData();
            Customer = new CustomerInfo();

            om.FindCustomer("sample@email.com", ref Customer);
        }

        private void UpdateProductList()
        {
            Product[] product = om.RetrieveProduct();
            ListViewItem item;

            listView1.Items.Clear();

            foreach (Product p in product)
            {
                item = new ListViewItem(p.ProductName);
                item.SubItems.Add(p.Price.ToString());

                listView1.Items.Add(item);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateProductList();
        }
    }
}
