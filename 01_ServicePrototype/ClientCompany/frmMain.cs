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
    public partial class frmMain : Form
    {
        OrderManagerServiceSoapClient om;
        CustomerInfo Customer;

        public frmMain()
        {
            InitializeComponent();

            listView1.FullRowSelect = true;

            om = new OrderManagerServiceSoapClient();
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
                item.Tag = (object)p;
                item.SubItems.Add(p.Price.ToString());

                listView1.Items.Add(item);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateProductList();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Product product;
            ListViewItem item;

            item = listView1.SelectedItems[0];
            product = (Product)item.Tag;

            om.InsertOrder(Customer, product);
        }
    }
}
