using EApartments.Models;
using EApartments.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace EApartments.Forms
{
    public partial class CustomerRegister : Form
    {
        AuthService _authService = new AuthService();

        public CustomerRegister()
        {
            InitializeComponent();
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.IsVaidForm())
                {
                    Occupant occupant = new Occupant(); 
                    occupant.FirstName = txtFirstName.Text + "";
                    occupant.LastName = txtLastName.Text + "";
                    occupant.Address = txtAddress.Text + "";
                    occupant.Nic = txtNic.Text + "";
                    occupant.Email = txtEmail.Text + "";
                    occupant.Phone = txtPhone.Text + "";

                    User user = new User();
                    user.FirstName = txtFirstName.Text + "";
                    user.LastName = txtLastName.Text + "";
                    user.Username = txtUsername.Text + "";
                    user.Password = txtPassword.Text + "";


                    var result = this._authService.Register(occupant, user);

                    if (result != null)
                    {
                        MessageBox.Show("Registration success, Plase log into system!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Login login = new Login();
                        this.Hide();
                        login.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        protected bool IsVaidForm()
        {
            try
            {
                if (txtFirstName.Text == "")
                {
                    MessageBox.Show("Please enter first name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtLastName.Text == "")
                {
                    MessageBox.Show("Please enter last name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter address!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtNic.Text == "")
                {
                    MessageBox.Show("Please enter valid NIC!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtEmail.Text == "" || !Regex.IsMatch(txtEmail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
                {
                    MessageBox.Show("Please enter valid email!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtPhone.Text == "")
                {
                    MessageBox.Show("Please enter valid phone number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Please enter username", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Please enter password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtPassword.Text != txtPasswordReEnter.Text)
                {
                    MessageBox.Show("Password confirmation invalid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
