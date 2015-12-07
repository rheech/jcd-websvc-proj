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
    public partial class frmViewDesign : Form
    {
        public frmViewDesign()
        {
            InitializeComponent();
        }

        private void LoadImage()
        {
            Image img = Image.FromFile("Resources\\dell_xps_jbl.jpg");

            img = ImageProcess.ResizeWithRatio(img, pictureBox.Width, pictureBox.Height);

            pictureBox.Image = img;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string question_msg;

            question_msg = "By accepting this, JCDecaux will advertise your product with the poster. Are you sure you want to continue?";

            if (MessageBox.Show(question_msg, "Design", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Order complete. Thank you.", "Design", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void frmViewDesign_Load(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
