namespace EApartments.Forms.Admin
{
    partial class Apartments
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAllApartments = new System.Windows.Forms.Button();
            this.btnAddNewApartment = new System.Windows.Forms.Button();
            this.btnAllBuildings = new System.Windows.Forms.Button();
            this.btnAddNewBuilding = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 27);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Apartments";
            // 
            // btnAllApartments
            // 
            this.btnAllApartments.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAllApartments.Location = new System.Drawing.Point(5, 6);
            this.btnAllApartments.Name = "btnAllApartments";
            this.btnAllApartments.Size = new System.Drawing.Size(160, 31);
            this.btnAllApartments.TabIndex = 2;
            this.btnAllApartments.Text = "All Apartments";
            this.btnAllApartments.UseVisualStyleBackColor = true;
            this.btnAllApartments.Click += new System.EventHandler(this.btnAllApartments_Click);
            // 
            // btnAddNewApartment
            // 
            this.btnAddNewApartment.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAddNewApartment.Location = new System.Drawing.Point(171, 6);
            this.btnAddNewApartment.Name = "btnAddNewApartment";
            this.btnAddNewApartment.Size = new System.Drawing.Size(160, 31);
            this.btnAddNewApartment.TabIndex = 3;
            this.btnAddNewApartment.Text = "Add New Apartment";
            this.btnAddNewApartment.UseVisualStyleBackColor = true;
            this.btnAddNewApartment.Click += new System.EventHandler(this.btnAddNewApartment_Click);
            // 
            // btnAllBuildings
            // 
            this.btnAllBuildings.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAllBuildings.Location = new System.Drawing.Point(337, 6);
            this.btnAllBuildings.Name = "btnAllBuildings";
            this.btnAllBuildings.Size = new System.Drawing.Size(160, 31);
            this.btnAllBuildings.TabIndex = 4;
            this.btnAllBuildings.Text = "All Buildings";
            this.btnAllBuildings.UseVisualStyleBackColor = true;
            this.btnAllBuildings.Click += new System.EventHandler(this.btnAllBuildings_Click);
            // 
            // btnAddNewBuilding
            // 
            this.btnAddNewBuilding.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAddNewBuilding.Location = new System.Drawing.Point(504, 6);
            this.btnAddNewBuilding.Name = "btnAddNewBuilding";
            this.btnAddNewBuilding.Size = new System.Drawing.Size(160, 31);
            this.btnAddNewBuilding.TabIndex = 5;
            this.btnAddNewBuilding.Text = "Add New Building";
            this.btnAddNewBuilding.UseVisualStyleBackColor = true;
            this.btnAddNewBuilding.Click += new System.EventHandler(this.btnAddNewBuilding_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.btnAllApartments);
            this.panel2.Controls.Add(this.btnAddNewBuilding);
            this.panel2.Controls.Add(this.btnAddNewApartment);
            this.panel2.Controls.Add(this.btnAllBuildings);
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 43);
            this.panel2.TabIndex = 6;
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(1, 87);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(670, 398);
            this.pnlMain.TabIndex = 7;
            // 
            // Apartments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(672, 486);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Apartments";
            this.Text = "Apartments";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAllApartments;
        private System.Windows.Forms.Button btnAddNewApartment;
        private System.Windows.Forms.Button btnAllBuildings;
        private System.Windows.Forms.Button btnAddNewBuilding;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlMain;
    }
}