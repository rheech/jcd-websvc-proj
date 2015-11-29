//#define RESET_DB

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libordermgmt;
using libwebsvcprod;

namespace ClientCompanyLocal
{
    public partial class frmCreateOrder : Form
    {
        OrderManager om;
        CustomerInfo Customer;
        CurrencyConverter _converter;

        public frmCreateOrder(CurrencyConverter converter)
        {
            InitializeComponent();

            lvProduct.FullRowSelect = true;

#if RESET_DB
            om = new OrderManagerSampleData();
#else
            om = new OrderManager();
#endif
            Customer = new CustomerInfo();

            _converter = converter;
            om.FindCustomer("sample@email.com", ref Customer);
        }

        private void UpdateProductList()
        {
            Product[] product = om.RetrieveProduct();
            ListViewItem item;

            lvProduct.Items.Clear();

            foreach (Product p in product)
            {
                item = new ListViewItem(p.ProductName);
                item.Tag = (object)p;
                item.SubItems.Add(p.Price.ToString());

                lvProduct.Items.Add(item);
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

            item = lvProduct.SelectedItems[0];
            product = (Product)item.Tag;

            om.InsertOrder(Customer, product);
        }

        private void lstProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item;
            Product product;

            if (lvProduct.SelectedItems.Count > 0)
            {
                item = lvProduct.SelectedItems[0];
                product = (Product)item.Tag;

                if (_converter != null)
                {
                    lblAmount.Text = String.Format("Amount Due: ${0:#,##0.00} ({1:N0} Won)",
                            product.Price, (int)_converter.DollarToWon((decimal)product.Price));
                }
            }
        }
    }
}