using EApartments.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EApartments.Forms.Admin
{
    public partial class UsersAddNew : Form
    {
        UserService _userService = new UserService();
        UtillService _utillService = new UtillService();

        public UsersAddNew()
        {
            InitializeComponent();
            LoadUserRolesToCmb();
        }


        private void LoadUserRolesToCmb()
        {
            List<Role> data = this._utillService.GetAllUserRoles();
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            cmbRole.DataSource = bs;
            cmbRole.DisplayMember = "Name";
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
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFirstName.Text == null || txtLastName.Text == null || txtPassword.Text == null || txtUsername.Text == null)
                {
                    MessageBox.Show(
                        "Please fill form correctly!",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    Role role = (Role)cmbRole.SelectedItem;

                    User user = new User();
                    user.RoleId = role.Id;
                    user.FirstName = txtFirstName.Text + "";
                    user.LastName = txtLastName.Text + "";
                    user.Username = txtUsername.Text + "";
                    user.Password = txtPassword.Text + "";
                    var result = this._userService.Add(user);

                    if (result)
                    {
                        MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
