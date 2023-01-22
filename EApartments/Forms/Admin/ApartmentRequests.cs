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
    public partial class ApartmentRequests : Form
    {
        ApartmentService _apartmentService = new ApartmentService();
        Lease lease;
        Occupant occupant;
        Apartment apartment;

        public ApartmentRequests()
        {
            InitializeComponent();
            loadTblData();
        }


        public void loadTblData()
        {
            try
            {
                TblAll.DataSource = this._apartmentService.GetAllRequestedApartments();
                TblAll.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["BuildingTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["CategoryTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["FirstName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                TblAll.Columns["RentPrice"].Visible = false;
                TblAll.Columns["Deposit"].Visible = false;
                TblAll.Columns["Status"].Visible = false;
                TblAll.Columns["BuildingId"].Visible = false;
                TblAll.Columns["CategoryId"].Visible = false;
                TblAll.Columns["LeaseId"].Visible = false;
                TblAll.Columns["LastName"].Visible = false;
                TblAll.Columns["Nic"].Visible = false;
                TblAll.Columns["LeaseStatus"].Visible = false;
                TblAll.Columns["OccupantId"].Visible = false;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ApartmentRequests_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdateView_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lease == null)
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
                    ApartmentRequestUpdate update = new ApartmentRequestUpdate(this.lease, this.occupant, this.apartment);
                    update.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TblAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = TblAll.Rows[e.RowIndex];

            this.lease = new Lease();
            this.lease.Id = (int)row.Cells["LeaseId"].Value;
            
            this.occupant = new Occupant();
            this.occupant.Id = (int)row.Cells["OccupantId"].Value;
            this.occupant.FirstName = row.Cells["FirstName"].Value.ToString();
            this.occupant.LastName = row.Cells["LastName"].Value.ToString();
            this.occupant.Nic = row.Cells["Nic"].Value.ToString();
            this.occupant.Email = row.Cells["Email"].Value.ToString();

            this.apartment = new Apartment();
            this.apartment.Code = row.Cells["Code"].Value.ToString();
            this.apartment.RentPrice = (decimal)row.Cells["RentPrice"].Value;
            this.apartment.Deposit = (decimal)row.Cells["Deposit"].Value;
        }
    }
}
