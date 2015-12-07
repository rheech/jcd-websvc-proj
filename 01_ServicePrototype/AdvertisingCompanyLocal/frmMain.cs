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
    public partial class frmMain : Form
    {
        OrderManager _om;

        public frmMain()
        {
            InitializeComponent();
            _om = new OrderManager();
        }

        private void UpdateOrderList()
        {
            OrderInfo[] orders = _om.RetrieveOrder();
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateOrderList();
            tmrUpdateList.Enabled = true;
        }

        private void tmrUpdateList_Tick(object sender, EventArgs e)
        {
            UpdateOrderList();
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

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            OrderInfo order;
            Product product;

            order = new OrderInfo();
            product = new Product();

            if (GetSelectedOrder(ref order, ref product))
            {
                frmViewDetails frmDetails = new frmViewDetails(order, product);

                if (order.OrderStatus >= ORDERSTATUS.Designed)
                {
                    frmDetails.EnablePicture = true;
                }

                frmDetails.ShowDialog();
            }
            else
            {
                if (order.OrderID != 0)
                {
                    MessageBox.Show("Error occurred while reading the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRequestDesign_Click(object sender, EventArgs e)
        {
            OrderInfo info;
            Product product;

            info = new OrderInfo();
            product = new Product();

            if (GetSelectedOrder(ref info, ref product))
            {
                if (MessageBox.Show("Are you sure you want to process the design request?", "Design Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    info.OrderStatus = ORDERSTATUS.Processing;

                    _om.UpdateOrder(info);

                    MessageBox.Show("Request complete", "Design Request", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UpdateOrderList();
                }
            }
        }

        private void lvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*ListViewItem item;
            OrderInfo info;
            bool bViewDetails = false, bRequestDesign = false, bAdvertise = false;

            if (lvOrders.SelectedItems.Count > 0)
            {
                item = lvOrders.SelectedItems[0];
                info = (OrderInfo)item.Tag;

                bViewDetails = true;

                if (info.OrderStatus == ORDERSTATUS.Placed)
                {
                    bRequestDesign = true;
                }
                else if (info.OrderStatus == ORDERSTATUS.Processing)
                {
                    bRequestDesign = true;
                }
                else if (info.OrderStatus == ORDERSTATUS.Designed)
                {
                    bAdvertise = true;
                }
            }

            btnViewDetails.Enabled = bViewDetails;
            btnRequestDesign.Enabled = bRequestDesign;
            btnAdvertise.Enabled = bAdvertise;*/
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
