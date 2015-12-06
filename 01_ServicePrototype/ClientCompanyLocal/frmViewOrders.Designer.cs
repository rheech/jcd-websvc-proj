namespace ClientCompanyLocal
{
    partial class frmViewOrders
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvOrders = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmrUpdateList = new System.Windows.Forms.Timer(this.components);
            this.btnModifyOrder = new System.Windows.Forms.Button();
            this.btnViewDesign = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "My Orders";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvOrders);
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 267);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orders";
            // 
            // lvOrders
            // 
            this.lvOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOrders.FullRowSelect = true;
            this.lvOrders.HideSelection = false;
            this.lvOrders.Location = new System.Drawing.Point(3, 16);
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(443, 248);
            this.lvOrders.TabIndex = 2;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            this.lvOrders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Order Date";
            this.columnHeader5.Width = 81;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Company Name";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Service Type";
            this.columnHeader2.Width = 113;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Order Status";
            this.columnHeader4.Width = 86;
            // 
            // tmrUpdateList
            // 
            this.tmrUpdateList.Interval = 1000;
            this.tmrUpdateList.Tick += new System.EventHandler(this.tmrUpdateList_Tick);
            // 
            // btnModifyOrder
            // 
            this.btnModifyOrder.Location = new System.Drawing.Point(15, 320);
            this.btnModifyOrder.Name = "btnModifyOrder";
            this.btnModifyOrder.Size = new System.Drawing.Size(92, 36);
            this.btnModifyOrder.TabIndex = 21;
            this.btnModifyOrder.Text = "&Modify Order";
            this.btnModifyOrder.UseVisualStyleBackColor = true;
            // 
            // btnViewDesign
            // 
            this.btnViewDesign.Location = new System.Drawing.Point(193, 320);
            this.btnViewDesign.Name = "btnViewDesign";
            this.btnViewDesign.Size = new System.Drawing.Size(92, 36);
            this.btnViewDesign.TabIndex = 22;
            this.btnViewDesign.Text = "&View Design";
            this.btnViewDesign.UseVisualStyleBackColor = true;
            this.btnViewDesign.Click += new System.EventHandler(this.btnViewDesign_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(369, 320);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 36);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmViewOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 366);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnViewDesign);
            this.Controls.Add(this.btnModifyOrder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmViewOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Status";
            this.Load += new System.EventHandler(this.frmViewOrders_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvOrders;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Timer tmrUpdateList;
        protected System.Windows.Forms.Button btnModifyOrder;
        protected System.Windows.Forms.Button btnViewDesign;
        protected System.Windows.Forms.Button btnClose;
    }
}