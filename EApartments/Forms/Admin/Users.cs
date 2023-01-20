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
    public partial class Users : Form
    {
        UserService _userService = new UserService();

        public Users()
        {
            InitializeComponent();
            loadTblData();
        }


        public void loadTblData()
        {
            try
            {
                TblAll.DataSource = this._userService.All();
                TblAll.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["FirstName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["LastName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TblAll.Columns["RoleName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //TblAll.Columns["Username"].Visible = false;
                //TblAll.Columns["Password"].Visible = false;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            UsersAddNew add = new UsersAddNew();
            add.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show(
                "Do you really want to delete?",
                "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (DialogResult == DialogResult.Yes)
            {

                
            }
        }

        private void btnUpdateView_Click(object sender, EventArgs e)
        {

        }

        private void TblAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
