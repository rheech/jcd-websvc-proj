using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libordermgmt;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace DesignCompanyLocal
{
    public partial class frmProcessOrder : Form
    {
        public frmProcessOrder()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            //ofd.InitialDirectory = "c:\\" ;
            ofd.Filter = "JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All files (*.*)|*.*" ;
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true ;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtFile.Text = ofd.FileName;
                    Image img = Image.FromFile(ofd.FileName);
                    img = ImageProcess.ResizeWithRatio(img, pictureBox.Width, pictureBox.Height);

                    pictureBox.Image = img;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnProcessOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
