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

namespace EApartments.Forms.Admin
{
    public partial class CustomerAddNew : Form
    {
        private OccupantService _occupantService = new OccupantService();


        public CustomerAddNew()
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
                if (txtEmail.Text == "")
                {
                    MessageBox.Show("Please enter valid email!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtPhone.Text == "")
                {
                    MessageBox.Show("Please enter valid phone number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.IsVaidForm())
                {
                    Occupant occupant = new Occupant();
                    occupant.FirstName = txtFirstName.Text+"";
                    occupant.LastName = txtLastName.Text+"";
                    occupant.Address = txtAddress.Text+"";
                    occupant.Nic = txtNic.Text+"";
                    occupant.Email = txtEmail.Text+"";
                    occupant.Phone = txtPhone.Text+"";
                    var result = this._occupantService.AddOccupant(occupant);

                    if (result)
                    {
                        MessageBox.Show("Occupant added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
