namespace EApartments.Forms.Admin
{
    partial class BuildingAll
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
            this.TblBuildingAll = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // TblBuildingAll
            // 
            this.TblBuildingAll.HideSelection = false;
            this.TblBuildingAll.Location = new System.Drawing.Point(22, 28);
            this.TblBuildingAll.Name = "TblBuildingAll";
            this.TblBuildingAll.Size = new System.Drawing.Size(755, 269);
            this.TblBuildingAll.TabIndex = 1;
            this.TblBuildingAll.UseCompatibleStateImageBehavior = false;
            this.TblBuildingAll.SelectedIndexChanged += new System.EventHandler(this.TblBuildingAll_SelectedIndexChanged);
            // 
            // BuildingAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TblBuildingAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BuildingAll";
            this.Text = "BuildingAll";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView TblBuildingAll;
    }
}