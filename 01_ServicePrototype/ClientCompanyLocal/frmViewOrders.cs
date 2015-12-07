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
    public partial class frmViewOrders : Form
    {
        CustomerInfo _customer;
        OrderManager _om;

        public frmViewOrders(OrderManager om, CustomerInfo customer)
        {
            InitializeComponent();

            _om = om;
            _customer = customer;
        }

        private void frmViewOrders_Load(object sender, EventArgs e)
        {
            UpdateOrderList();
            tmrUpdateList.Enabled = true;
        }

        private void UpdateOrderList()
        {
            OrderInfo[] orders = _om.RetrieveOrder(_customer);
            OrderInfo tmpOrder;
            Func<OrderInfo, ListViewItem> funcGetListView;


            // *******************
            // Get List View Items
            // *******************
            funcGetListView = new Func<OrderInfo, ListViewItem>(
                (o) =>
                {
                    ListViewItem i;

                    i = new ListViewItem(o.OrderDate.ToString("yyyy-MM-dd"));
                    i.SubItems.Add(o.Customer.CompanyName);
                    i.SubItems.Add(o.Service.ServiceName);
                    i.SubItems.Add(o.Service.Price.ToString());
                    i.SubItems.Add(o.OrderStatus.ToString());
                    i.Tag = (object)o;

                    return i;
                });
            // *******************
            // End Function 
            // *******************

            if (lvOrders.Items.Count == 0 ||
                    orders.Length != lvOrders.Items.Count)
            {
                lvOrders.Items.Clear();

                foreach (OrderInfo o in orders)
                {
                    lvOrders.Items.Add(funcGetListView(o));
                }
            }
            else
            {
                for (int i = 0; i < orders.Length; i++)
                {
                    tmpOrder = (OrderInfo)lvOrders.Items[i].Tag;

                    if (!orders[i].Equals(tmpOrder))
                    {
                        lvOrders.Items[i] = funcGetListView(orders[i]);
                    }
                }
            }
        }

        private void tmrUpdateList_Tick(object sender, EventArgs e)
        {
            UpdateOrderList();
        }

        private void btnViewDesign_Click(object sender, EventArgs e)
        {
            frmViewDesign frmDesign = new frmViewDesign();

            if (lvOrders.SelectedItems.Count > 0)
            {
                if (frmDesign.ShowDialog() == DialogResult.OK)
                {
                    OrderInfo info;

                    info = (OrderInfo)lvOrders.SelectedItems[0].Tag;

                    info.OrderStatus = ORDERSTATUS.CustomerOK;

                    _om.UpdateOrder(info);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool GetSelectedOrder(ref OrderInfo order, ref Product product)
        {
            if (lvOrders.SelectedItems.Count > 0)
            {
                order = (OrderInfo)lvOrders.SelectedItems[0].Tag;
                product = new Product();

                if (_om.FindProduct(order.OrderID, ref product))
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Please select an order.", "Order", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return false;
        }

        private void btnAdvertise_Click(object sender, EventArgs e)
        {
            OrderInfo info;
            Product product;

            info = new OrderInfo();
            product = new Product();

            if (GetSelectedOrder(ref info, ref product))
            {
                frmAdvertise fAdvertise = new frmAdvertise(_om, info, product);

                if (fAdvertise.ShowDialog() == DialogResult.OK)
                {
                    info.OrderStatus = ORDERSTATUS.Advertising;
                    _om.UpdateOrder(info);
                }

                UpdateOrderList();
            }
        }
    }
}
