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
            this.DialogResult = DialogResult.OK;
            this.Close();
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
