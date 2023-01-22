using EApartments.Forms.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EApartments.Forms.ManagerView
{
    public partial class ManagerDashboard : Form
    {
        public ManagerDashboard()
        {
            InitializeComponent();
        }

        /// <summary>
        ///    Common method for load forms.
        /// </summary>
        /// <param name="Form"></param>
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

        private void btnApartments_Click(object sender, EventArgs e)
        {
            this.loadForm(new ApartmentRequests());
        }
    }
}
