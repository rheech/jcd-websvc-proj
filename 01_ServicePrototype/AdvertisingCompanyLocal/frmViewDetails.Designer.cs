namespace AdvertisingCompanyLocal
{
    partial class frmViewDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCustPhoneNumber = new System.Windows.Forms.Label();
            this.lblCustEmail = new System.Windows.Forms.Label();
            this.lblCustAddress = new System.Windows.Forms.Label();
            this.lblCustCompanyName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.lblTagList = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblServiceType = new System.Windows.Forms.Label();
            this.lblServicePrice = new System.Windows.Forms.Label();
            this.lblCustAddressDisplay = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Order Details";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCustAddressDisplay);
            this.groupBox1.Controls.Add(this.lblCustPhoneNumber);
            this.groupBox1.Controls.Add(this.lblCustEmail);
            this.groupBox1.Controls.Add(this.lblCustAddress);
            this.groupBox1.Controls.Add(this.lblCustCompanyName);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 82);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Information";
            // 
            // lblCustPhoneNumber
            // 
            this.lblCustPhoneNumber.AutoSize = true;
            this.lblCustPhoneNumber.Location = new System.Drawing.Point(190, 60);
            this.lblCustPhoneNumber.Name = "lblCustPhoneNumber";
            this.lblCustPhoneNumber.Size = new System.Drawing.Size(81, 13);
            this.lblCustPhoneNumber.TabIndex = 3;
            this.lblCustPhoneNumber.Tag = "Phone Number: {0}";
            this.lblCustPhoneNumber.Text = "Phone Number:";
            // 
            // lblCustEmail
            // 
            this.lblCustEmail.AutoSize = true;
            this.lblCustEmail.Location = new System.Drawing.Point(6, 60);
            this.lblCustEmail.Name = "lblCustEmail";
            this.lblCustEmail.Size = new System.Drawing.Size(39, 13);
            this.lblCustEmail.TabIndex = 2;
            this.lblCustEmail.Tag = "E-Mail: {0}";
            this.lblCustEmail.Text = "E-Mail:";
            // 
            // lblCustAddress
            // 
            this.lblCustAddress.AutoSize = true;
            this.lblCustAddress.Location = new System.Drawing.Point(190, 25);
            this.lblCustAddress.Name = "lblCustAddress";
            this.lblCustAddress.Size = new System.Drawing.Size(48, 13);
            this.lblCustAddress.TabIndex = 1;
            this.lblCustAddress.Tag = "Address: {0}";
            this.lblCustAddress.Text = "Address:";
            // 
            // lblCustCompanyName
            // 
            this.lblCustCompanyName.AutoSize = true;
            this.lblCustCompanyName.Location = new System.Drawing.Point(6, 25);
            this.lblCustCompanyName.Name = "lblCustCompanyName";
            this.lblCustCompanyName.Size = new System.Drawing.Size(85, 13);
            this.lblCustCompanyName.TabIndex = 0;
            this.lblCustCompanyName.Tag = "Company Name: {0}";
            this.lblCustCompanyName.Text = "Company Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblOrderDate);
            this.groupBox2.Controls.Add(this.lblServicePrice);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.txtTags);
            this.groupBox2.Controls.Add(this.lblTagList);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblServiceType);
            this.groupBox2.Location = new System.Drawing.Point(12, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 271);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order Information";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(9, 168);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(412, 93);
            this.txtDescription.TabIndex = 4;
            // 
            // txtTags
            // 
            this.txtTags.Location = new System.Drawing.Point(9, 103);
            this.txtTags.Multiline = true;
            this.txtTags.Name = "txtTags";
            this.txtTags.ReadOnly = true;
            this.txtTags.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTags.Size = new System.Drawing.Size(412, 46);
            this.txtTags.TabIndex = 3;
            // 
            // lblTagList
            // 
            this.lblTagList.AutoSize = true;
            this.lblTagList.Location = new System.Drawing.Point(6, 87);
            this.lblTagList.Name = "lblTagList";
            this.lblTagList.Size = new System.Drawing.Size(34, 13);
            this.lblTagList.TabIndex = 2;
            this.lblTagList.Text = "Tags:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 1;
            this.label5.Tag = "Description:";
            this.label5.Text = "Description:";
            // 
            // lblServiceType
            // 
            this.lblServiceType.AutoSize = true;
            this.lblServiceType.Location = new System.Drawing.Point(6, 44);
            this.lblServiceType.Name = "lblServiceType";
            this.lblServiceType.Size = new System.Drawing.Size(76, 13);
            this.lblServiceType.TabIndex = 0;
            this.lblServiceType.Tag = "Service Type: {0}";
            this.lblServiceType.Text = "Service Type: ";
            // 
            // lblServicePrice
            // 
            this.lblServicePrice.AutoSize = true;
            this.lblServicePrice.Location = new System.Drawing.Point(6, 66);
            this.lblServicePrice.Name = "lblServicePrice";
            this.lblServicePrice.Size = new System.Drawing.Size(34, 13);
            this.lblServicePrice.TabIndex = 5;
            this.lblServicePrice.Tag = "Price: {0}";
            this.lblServicePrice.Text = "Price:";
            // 
            // lblCustAddressDisplay
            // 
            this.lblCustAddressDisplay.Location = new System.Drawing.Point(235, 25);
            this.lblCustAddressDisplay.Name = "lblCustAddressDisplay";
            this.lblCustAddressDisplay.Size = new System.Drawing.Size(182, 35);
            this.lblCustAddressDisplay.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(345, 402);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(6, 22);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(62, 13);
            this.lblOrderDate.TabIndex = 6;
            this.lblOrderDate.Tag = "Order Date: {0:yyyy-MM-dd}";
            this.lblOrderDate.Text = "Order Date:";
            // 
            // frmViewDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 448);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmViewDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.frmViewDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCustPhoneNumber;
        private System.Windows.Forms.Label lblCustEmail;
        private System.Windows.Forms.Label lblCustAddress;
        private System.Windows.Forms.Label lblCustCompanyName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTagList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblServiceType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Label lblServicePrice;
        private System.Windows.Forms.Label lblCustAddressDisplay;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblOrderDate;
    }
}