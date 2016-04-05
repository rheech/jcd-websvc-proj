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
    public partial class frmAdvertise : Form
    {
        OrderManager _om;
        OrderInfo _info;
        Product _product;

        public frmAdvertise(OrderManager om, OrderInfo info, Product product)
        {
            InitializeComponent();

            _om = om;
            _info = info;
            _product = product;
        }

        private void frmAdvertise_Load(object sender, EventArgs e)
        {
            string[] tags;
            tags = _product.TagList.Split(';');

            foreach (string s in tags)
            {
                lstTags.Items.Add(s);
            }

            Image img = Image.FromFile("Resources\\dell_xps_jbl.jpg");
            img = ImageProcess.ResizeWithRatio(img, pictureBox.Width, pictureBox.Height);

            pictureBox.Image = img;
        }

        private void lstTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            TagInfo[] info;
            ListViewItem item;

            info = _om.RetriveTags(lstTags.SelectedItem.ToString());
            lvBusStop.Items.Clear();

            foreach (TagInfo t in info)
            {
                item = new ListViewItem(t.BusStopID);
                item.SubItems.Add(t.NameKor);
                item.SubItems.Add(t.NameEng);
                item.SubItems.Add(t.TagName);

                lvBusStop.Items.Add(item);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdvertise_Click(object sender, EventArgs e)
        {
            string stopName;

            if (lvBusStop.SelectedItems.Count > 0)
            {
                stopName = lvBusStop.SelectedItems[0].SubItems[1].Text;

                if (MessageBox.Show(
                    String.Format("Are you sure you want to display this advertisment to {0}?", stopName),
                    "Advertisement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show(String.Format("Advertisement applied to {0}.", stopName),
                        "Advertisement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select a bus stop.", "Advertisement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
