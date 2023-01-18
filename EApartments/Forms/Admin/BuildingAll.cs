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
using System.Xml.Linq;

namespace EApartments.Forms.Admin
{
    public partial class BuildingAll : Form
    {
        private ApartmentService _apartmentService = new ApartmentService();
        private Building building;

        public BuildingAll()
        {
            InitializeComponent();
            loadTblData();
        }
        
        public void loadTblData()
        {
            try
            {
                TblAll.DataSource = this._apartmentService.GetAllBuildings();
                TblAll.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TblBuildingAll_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TblAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = TblAll.Rows[e.RowIndex];

            this.building = new Building();
            this.building.Id = (int)row.Cells["Id"].Value;
            this.building.Title = row.Cells["Title"].Value.ToString();
            this.building.Address = row.Cells["Address"].Value.ToString();
            this.building.Description = (row.Cells["Description"].Value != null) ? row.Cells["Description"].Value.ToString() : null;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            BuildingAdd add = new BuildingAdd();
            add.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.building == null)
                {
                    MessageBox.Show(
                        "Please select a row!",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    Building building = new Building();
                    building.Id = (int)this.building.Id;
                    var result = this._apartmentService.DeleteBuilding(building);
                    
                    if (result)
                    {
                        MessageBox.Show("Data deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateView_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.building == null)
                {
                    MessageBox.Show(
                        "Please select a row!",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    BuildingUpdate update = new BuildingUpdate(this.building);
                    update.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
