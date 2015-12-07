//#define RESET_DB

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libwebsvcprod;
using libordermgmt;

namespace ClientCompanyLocal
{
    public partial class frmMain : Form
    {
        OrderManager _om;
        CustomerInfo _customer;
        CurrencyConverter _converter;

        public frmMain()
        {
            InitializeComponent();

#if RESET_DB
            _om = new OrderManagerSampleData();
#else
            _om = new OrderManager();
#endif
            _customer = new CustomerInfo();

            _om.FindCustomer("email_kr@dell.com", ref _customer);

            btnCreateOrder.Enabled = false;
            bw1.RunWorkerAsync();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            frmCreateOrder orderForm = new frmCreateOrder(_converter, _om, _customer);
            orderForm.ShowDialog();
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            frmViewOrders viewOrdersForm = new frmViewOrders(_om, _customer);
            viewOrdersForm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void bw1_DoWork(object sender, DoWorkEventArgs e)
        {
            _converter = new CurrencyConverter();
        }

        private void bw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCreateOrder.Enabled = true;
        }
    }
}
