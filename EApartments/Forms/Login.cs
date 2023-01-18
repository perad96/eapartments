using EApartments.Forms.Admin;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var user = this._authService.LogIn(txtUsername.Text, txtPassword.Text);

                if (user != null)
                {
                    if(user.RoleId == 0)
                    {
                        AdminDashboard dashboard = new AdminDashboard();
                        dashboard.Show();
                    }
                    if(user.RoleId == 1)
                    {

                    }
                    if(user.RoleId == 2)
                    {

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
    }
}
