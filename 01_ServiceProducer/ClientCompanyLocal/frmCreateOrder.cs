﻿//#define RESET_DB

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libordermgmt;

namespace ClientCompanyLocal
{
    public partial class frmCreateOrder : Form
    {
        OrderManager om;
        CustomerInfo Customer;

        public frmCreateOrder()
        {
            InitializeComponent();

            lstProduct.FullRowSelect = true;

#if RESET_DB
            om = new OrderManagerSampleData();
#else
            om = new OrderManager();
#endif
            Customer = new CustomerInfo();

            om.FindCustomer("sample@email.com", ref Customer);
        }

        private void UpdateProductList()
        {
            Product[] product = om.RetrieveProduct();
            ListViewItem item;

            lstProduct.Items.Clear();

            foreach (Product p in product)
            {
                item = new ListViewItem(p.ProductName);
                item.Tag = (object)p;
                item.SubItems.Add(p.Price.ToString());

                lstProduct.Items.Add(item);
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

            item = lstProduct.SelectedItems[0];
            product = (Product)item.Tag;

            om.InsertOrder(Customer, product);
        }
    }
}