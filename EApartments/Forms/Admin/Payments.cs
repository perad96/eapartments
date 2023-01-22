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
    public partial class Payments : Form
    {
        PaymentService _paymentService = new PaymentService();
        OccupantService _occupantService = new OccupantService();
        Lease lease;

        public Payments()
        {
            InitializeComponent();
            LoadOccupantsToCmb();
        }

        private void LoadOccupantsToCmb()
        {
            List<Occupant> data = this._occupantService.GetAllOccupants();
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            cmbBuilding.DataSource = bs;
            cmbBuilding.DisplayMember = "FirstName";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Occupant occupant = (Occupant)cmbBuilding.SelectedItem;

                TblAll.DataSource = this._paymentService.GetAllByOccupant(occupant.Id);
                
                TblAll.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["BuildingTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["CategoryTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["FirstName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                    PaymentInfo update = new PaymentInfo(this.lease);
                    update.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
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
                    PaymentAdd update = new PaymentAdd(this.lease);
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
