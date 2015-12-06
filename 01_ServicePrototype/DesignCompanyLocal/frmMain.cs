using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libordermgmt;

namespace DesignCompanyLocal
{
    public partial class frmMain : Form
    {
        OrderManager om;

        public frmMain()
        {
            InitializeComponent();
            om = new OrderManager();
        }

        private void UpdateOrderList()
        {
            OrderInfo[] orders = om.RetrieveOrder(ORDERSTATUS.Processing);
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateOrderList();
            tmrUpdateList.Enabled = true;
        }

        private bool GetSelectedOrder(ref OrderInfo order, ref Product product)
        {
            if (lvOrders.SelectedItems.Count > 0)
            {
                order = (OrderInfo)lvOrders.SelectedItems[0].Tag;
                product = new Product();

                if (om.FindProduct(order.OrderID, ref product))
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

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            OrderInfo order;
            Product product;

            order = new OrderInfo();
            product = new Product();

            if (GetSelectedOrder(ref order, ref product))
            {
                frmProcessOrder frmDetails = new frmProcessOrder(order, product);
                frmDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error occurred while reading the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
