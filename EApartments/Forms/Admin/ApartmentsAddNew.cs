using EApartments.Migrations;
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

namespace EApartments.Forms.Admin
{
    public partial class ApartmentsAddNew : Form
    {
        private ApartmentService _apartmentService = new ApartmentService();
        private UtillService _utillService = new UtillService();


        public ApartmentsAddNew()
        {
            InitializeComponent();
            LoadBuildingsToCmb();
            LoadApartmentCategoriesToCmb();
        }


        private void LoadBuildingsToCmb()
        {
            List<Building> data = this._utillService.GetAllBuildings();
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            cmbBuilding.DataSource = bs;
            cmbBuilding.DisplayMember = "Title";
        }

        private void LoadApartmentCategoriesToCmb()
        {
            List<ApartmentCategory> data = this._utillService.GetAllApartmentCategories();
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            cmbClass.DataSource = bs;
            cmbClass.DisplayMember = "Title";
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
                if (txtCode.Text == "")
                {
                    MessageBox.Show("Please enter code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtFloor.Text == "" || !Regex.IsMatch(txtFloor.Text, @"^\d+$"))
                {
                    MessageBox.Show("Please enter valid floor!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtPrice.Text == "" || !Regex.IsMatch(txtPrice.Text, @"^\d+$"))
                {
                    MessageBox.Show("Please enter valid price!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtDeposite.Text == "" || !Regex.IsMatch(txtDeposite.Text, @"^\d+$"))
                {
                    MessageBox.Show("Please enter valid deposite amount!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Building building = (Building)cmbBuilding.SelectedItem;
                    ApartmentCategory category = (ApartmentCategory)cmbClass.SelectedItem;

                    Apartment apartment = new Apartment();
                    apartment.BuildingId = building.Id;
                    apartment.CategoryId = category.Id;
                    apartment.Code = txtCode.Text + "";
                    apartment.Floor = int.Parse(txtFloor.Text);
                    apartment.RentPrice = decimal.Parse(txtPrice.Text);
                    apartment.Deposit = decimal.Parse(txtDeposite.Text);
                    apartment.Status = "AVAILABLE";
                    var result = this._apartmentService.AddApartment(apartment);

                    if (result)
                    {
                        MessageBox.Show("Appartment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
