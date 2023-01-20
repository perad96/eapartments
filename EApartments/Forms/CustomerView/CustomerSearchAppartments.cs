using EApartments.Forms.Admin;
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

namespace EApartments.Forms.CustomerView
{
    public partial class CustomerSearchAppartments : Form
    {
        private ApartmentService _apartmentService = new ApartmentService();
        private UtillService _utillService = new UtillService();
        private Apartment apartment;
        User authUser = new User();

        public CustomerSearchAppartments(User authUser)
        {
            InitializeComponent();
            LoadBuildingsToCmb();
            LoadApartmentCategoriesToCmb();
            this.authUser = authUser;   
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Building building = (Building)cmbBuilding.SelectedItem;
                ApartmentCategory category = (ApartmentCategory)cmbClass.SelectedItem;

                TblAll.DataSource = this._apartmentService.GetAllAvailableApartmentsByBuildingAndClass(building.Id, category.Id);
                TblAll.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["RentPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Deposit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["BuildingTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["CategoryTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                TblAll.Columns["Status"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TblAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = TblAll.Rows[e.RowIndex];

            this.apartment = new Apartment();
            this.apartment.Id = (int)row.Cells["Id"].Value;
            this.apartment.Code = row.Cells["Code"].Value.ToString();
            this.apartment.RentPrice = (decimal)row.Cells["RentPrice"].Value;
            this.apartment.Deposit = (decimal)row.Cells["Deposit"].Value;
            Console.WriteLine("Clicked");
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.apartment == null)
                {
                    MessageBox.Show(
                        "Please select a apartment!",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    ApartmentAsign assign = new ApartmentAsign(this.apartment);
                    assign.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.apartment == null)
                {
                    MessageBox.Show(
                        "Please select a apartment!",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    RequestApartment assign = new RequestApartment(this.apartment, this.authUser);
                    assign.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerSearchAppartments_Load(object sender, EventArgs e)
        {

        }
    }
}
