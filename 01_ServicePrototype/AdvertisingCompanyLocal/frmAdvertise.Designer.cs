namespace AdvertisingCompanyLocal
{
    partial class frmAdvertise
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
            this.lstTags = new System.Windows.Forms.ListBox();
            this.lvBusStop = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdvertise = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Bus Stop Advertisement";
            // 
            // lstTags
            // 
            this.lstTags.FormattingEnabled = true;
            this.lstTags.Location = new System.Drawing.Point(307, 64);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(183, 173);
            this.lstTags.TabIndex = 21;
            this.lstTags.SelectedIndexChanged += new System.EventHandler(this.lstTags_SelectedIndexChanged);
            // 
            // lvBusStop
            // 
            this.lvBusStop.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvBusStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBusStop.FullRowSelect = true;
            this.lvBusStop.Location = new System.Drawing.Point(3, 16);
            this.lvBusStop.Name = "lvBusStop";
            this.lvBusStop.Size = new System.Drawing.Size(478, 209);
            this.lvBusStop.TabIndex = 22;
            this.lvBusStop.UseCompatibleStateImageBehavior = false;
            this.lvBusStop.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Bus Stop (Kor)";
            this.columnHeader1.Width = 126;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Bus Stop (Eng)";
            this.columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tag";
            this.columnHeader3.Width = 166;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Bus Stop ID";
            this.columnHeader4.Width = 71;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvBusStop);
            this.groupBox1.Location = new System.Drawing.Point(9, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 228);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recommended Bus Stops";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 64);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(289, 173);
            this.pictureBox.TabIndex = 24;
            this.pictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Advertisement:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tags";
            // 
            // btnAdvertise
            // 
            this.btnAdvertise.Location = new System.Drawing.Point(299, 478);
            this.btnAdvertise.Name = "btnAdvertise";
            this.btnAdvertise.Size = new System.Drawing.Size(94, 36);
            this.btnAdvertise.TabIndex = 27;
            this.btnAdvertise.Text = "Advertise";
            this.btnAdvertise.UseVisualStyleBackColor = true;
            this.btnAdvertise.Click += new System.EventHandler(this.btnAdvertise_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(399, 478);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 36);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAdvertise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 526);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdvertise);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAdvertise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAdvertise";
            this.Load += new System.EventHandler(this.frmAdvertise_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.ListView lvBusStop;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdvertise;
        private System.Windows.Forms.Button btnClose;
    }
}