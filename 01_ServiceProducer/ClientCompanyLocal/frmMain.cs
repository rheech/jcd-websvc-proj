using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientCompanyLocal
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            frmCreateOrder orderForm = new frmCreateOrder();
            orderForm.ShowDialog();
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            frmViewOrders viewOrdersForm = new frmViewOrders();
            viewOrdersForm.ShowDialog();
        }
    }
}
