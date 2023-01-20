using EApartments.Forms.Admin;
using EApartments.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EApartments.Forms.CustomerView
{
    public partial class CustomerDashboard : Form
    {
        User authUser = new User();

        public CustomerDashboard(User authUser)
        {
            InitializeComponent();
            this.authUser = authUser;
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.loadForm(new CustomerSearchAppartments(this.authUser));
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            this.loadForm(new CustomerSearchAppartments(this.authUser));
        }
    }
}
