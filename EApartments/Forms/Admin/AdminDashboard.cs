using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EApartments.Forms.Admin
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        public void loadForm(object Form)
        {
            if (this.pnlMain.Controls.Count > 0)
                this.pnlMain.Controls.RemoveAt(0);

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.Show();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            this.loadForm(new Payments());
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            this.loadForm(new Welcome());
        }

        private void btnApartments_Click(object sender, EventArgs e)
        {
            this.loadForm(new Apartments());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.loadForm(new Welcome());
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            this.loadForm(new Customers());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            this.loadForm(new Reports());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            this.loadForm(new Users());
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            this.loadForm(new Settings());
        }
    }
}
