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
    public partial class frmViewDetails : Form
    {
        private OrderInfo _order;
        private Product _product;

        public frmViewDetails(OrderInfo order, Product product)
        {
            InitializeComponent();

            _order = order;
            _product = product;
        }

        private void frmViewDetails_Load(object sender, EventArgs e)
        {
            DisplayInformation();
        }

        private void DisplayInformation()
        {
            lblCustAddressDisplay.Text = _order.Customer.Address;
            lblCustCompanyName.Text = String.Format(lblCustCompanyName.Tag.ToString(), _order.Customer.CompanyName);
            lblCustEmail.Text = String.Format(lblCustEmail.Tag.ToString(), _order.Customer.EMail);
            lblCustPhoneNumber.Text = String.Format(lblCustPhoneNumber.Tag.ToString(), _order.Customer.PhoneNumber);

            lblOrderDate.Text = String.Format(lblOrderDate.Tag.ToString(), _order.OrderDate);
            lblServiceType.Text = String.Format(lblServiceType.Tag.ToString(), _order.Service.ServiceName);
            lblServicePrice.Text = String.Format(lblServicePrice.Tag.ToString(), _order.Service.Price);

            txtTags.Text = _product.TagList;
            txtDescription.Text = _product.Description;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
