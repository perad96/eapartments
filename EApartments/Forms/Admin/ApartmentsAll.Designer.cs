namespace EApartments.Forms.Admin
{
    partial class ApartmentsAll
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
            this.TblAll = new System.Windows.Forms.DataGridView();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFloor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDeposite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TblAll)).BeginInit();
            this.SuspendLayout();
            // 
            // TblAll
            // 
            this.TblAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TblAll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColCode,
            this.ColFloor,
            this.ColRentPrice,
            this.ColDeposite,
            this.ColStatus});
            this.TblAll.Location = new System.Drawing.Point(12, 80);
            this.TblAll.Name = "TblAll";
            this.TblAll.Size = new System.Drawing.Size(662, 210);
            this.TblAll.TabIndex = 0;
            // 
            // ColId
            // 
            this.ColId.HeaderText = "ID";
            this.ColId.Name = "ColId";
            // 
            // ColCode
            // 
            this.ColCode.HeaderText = "Apartment Code";
            this.ColCode.Name = "ColCode";
            // 
            // ColFloor
            // 
            this.ColFloor.HeaderText = "Floor";
            this.ColFloor.Name = "ColFloor";
            // 
            // ColRentPrice
            // 
            this.ColRentPrice.HeaderText = "Rent Price";
            this.ColRentPrice.Name = "ColRentPrice";
            // 
            // ColDeposite
            // 
            this.ColDeposite.HeaderText = "Deposite";
            this.ColDeposite.Name = "ColDeposite";
            // 
            // ColStatus
            // 
            this.ColStatus.HeaderText = "Status";
            this.ColStatus.Name = "ColStatus";
            // 
            // ApartmentsAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.TblAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ApartmentsAll";
            this.Text = "ApartmentsAll";
            ((System.ComponentModel.ISupportInitialize)(this.TblAll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TblAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFloor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeposite;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStatus;
    }
}