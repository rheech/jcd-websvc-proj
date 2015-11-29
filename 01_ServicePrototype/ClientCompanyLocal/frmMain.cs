using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libwebsvcprod;

namespace ClientCompanyLocal
{
    public partial class frmMain : Form
    {
        CurrencyConverter _converter;

        public frmMain()
        {
            InitializeComponent();
            btnCreateOrder.Enabled = false;
            bw1.RunWorkerAsync();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            frmCreateOrder orderForm = new frmCreateOrder(_converter);
            orderForm.ShowDialog();
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            frmViewOrders viewOrdersForm = new frmViewOrders();
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
