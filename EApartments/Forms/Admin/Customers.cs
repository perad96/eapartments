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
    public partial class Customers : Form
    {
        private OccupantService _occupantService = new OccupantService();

        public Customers()
        {
            InitializeComponent();
            loadTblData();
        }

        public void loadTblData()
        {
            try
            {
                TblAll.DataSource = this._occupantService.GetAllOccupants();
                TblAll.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["FirstName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["LastName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Nic"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                TblAll.Columns["UserId"].Visible = false;
                TblAll.Columns["ChiefOccupantId"].Visible = false;
                TblAll.Columns["RelationshipToChiefOccupant"].Visible = false;
                TblAll.Columns["EmergencyContact"].Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            CustomerAddNew add = new CustomerAddNew();
            add.Show();
        }
    }
}
