using EApartments.DB;
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

namespace EApartments.Forms.Admin
{
    public partial class BuildingAdd : Form
    {
        ApartmentService _apartmentService = new ApartmentService();

        public BuildingAdd()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
                if (txtTitle.Text == null || txtAddress.Text == null)
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
                    Building building = new Building();
                    building.Title = txtTitle.Text + "";
                    building.Address = txtAddress.Text + "";
                    building.Description = txtDescription.Text + "";
                    var result = this._apartmentService.AddBuilding(building);

                    if (result)
                    {
                        MessageBox.Show("Data added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong! Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
