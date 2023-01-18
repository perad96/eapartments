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
    public partial class Apartments : Form
    {
        public Apartments()
        {
            InitializeComponent();
        }

        public void loadForm(object Form)
        {
            if (this.pnlMain.Controls.Count > 0)
                this.pnlMain.Controls.RemoveAt(0);

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.Show();
        }

        private void btnAllApartments_Click(object sender, EventArgs e)
        {
            this.loadForm(new ApartmentsAll());
        }

        private void btnAddNewApartment_Click(object sender, EventArgs e)
        {
            this.loadForm(new ApartmentsAddNew());
        }

        private void btnAllBuildings_Click(object sender, EventArgs e)
        {
            this.loadForm(new BuildingAll());
        }

        private void btnAddNewBuilding_Click(object sender, EventArgs e)
        {
            // this.loadForm(new )
        }
    }
}
