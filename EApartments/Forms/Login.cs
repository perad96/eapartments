using EApartments.Forms.Admin;
using EApartments.Forms.CustomerView;
using EApartments.Forms.ManagerView;
using EApartments.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EApartments.Forms
{
    public partial class Login : Form
    {
        AuthService _authService = new AuthService();

        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///    User Login function.
        ///    Redirect to deferent dashboards to according to user role.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var user = this._authService.LogIn(txtUsername.Text, txtPassword.Text);

                if (user != null)
                {
                    if(user.RoleId == 1)
                    {
                        AdminDashboard dashboard = new AdminDashboard();
                        dashboard.Show();
                    }
                    if(user.RoleId == 2)
                    {
                        ManagerDashboard dashboard = new ManagerDashboard();
                        dashboard.Show();
                    }
                    if(user.RoleId == 3)
                    {
                        CustomerDashboard dashboard = new CustomerDashboard(user);
                        dashboard.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show(
                "Do you really want to cancel?",
                "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (DialogResult == DialogResult.Yes)
            {
                this.Hide();
                GuestWelcome form = new GuestWelcome();
                form.Show();
            }
        }
    }
}
