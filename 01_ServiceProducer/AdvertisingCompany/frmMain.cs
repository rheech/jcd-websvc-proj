using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libordermgmt;

namespace AdvertisingCompany
{
    public partial class frmMain : Form
    {
        OrderManager om;

        public frmMain()
        {
            InitializeComponent();
            om = new OrderManagerSampleData();
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            OrderInfo[] orders = om.RetrieveOrder();

            foreach (OrderInfo o in orders)
            {
                
            }
        }
    }
}
