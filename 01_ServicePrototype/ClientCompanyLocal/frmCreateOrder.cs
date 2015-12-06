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

            lvServices.FullRowSelect = true;

#if RESET_DB
            om = new OrderManagerSampleData();
#else
            om = new OrderManager();
#endif
            Customer = new CustomerInfo();

            _converter = converter;
            om.FindCustomer("sample@email.com", ref Customer);
        }

        private void UpdateAdServiceList()
        {
            AdService[] services = om.RetrieveAdService();
            ListViewItem item;

            lvServices.Items.Clear();

            foreach (AdService p in services)
            {
                item = new ListViewItem(p.ServiceName);
                item.Tag = (object)p;
                item.SubItems.Add(p.Price.ToString());

                lvServices.Items.Add(item);
            }
        }

        private void SubmitOrder()
        {
            AdService service;
            Product product;
            OrderInfo order;
            ListViewItem item;
            int orderID;

            item = lvServices.SelectedItems[0];
            service = (AdService)item.Tag;

            order = new OrderInfo();
            order.OrderDate = DateTime.Now;
            order.OrderStatus = ORDERSTATUS.Placed;

            order.Service = service;
            order.Customer = Customer;

            orderID = om.InsertOrder(order);

            //orderID = om.InsertOrder(Customer, service);

            // insert product
            product = new Product();
            product.ProductName = txtProductName.Text;
            product.Description = txtDescription.Text;
            product.TagList = txtTags.Text;

            om.InsertProduct(orderID, product);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateAdServiceList();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitOrder();
            MessageBox.Show("Order complete.", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void lvServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item;
            AdService service;

            if (lvServices.SelectedItems.Count > 0)
            {
                item = lvServices.SelectedItems[0];
                service = (AdService)item.Tag;

                if (_converter != null)
                {
                    lblAmount.Text = String.Format("Amount Due: ${0:#,##0.00} ({1:N0} Won)",
                            service.Price, (int)_converter.DollarToWon((decimal)service.Price));
                }
            }
        }
    }
}