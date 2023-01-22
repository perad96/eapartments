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
    public partial class PaymentInfo : Form
    {
        PaymentService _paymentService = new PaymentService();
        Lease lease;

        public PaymentInfo(Lease lease)
        {
            this.lease = lease;
            InitializeComponent();
        }

        private void PaymentInfo_Load(object sender, EventArgs e)
        {
            TblAll.DataSource = this._paymentService.GetAllPaymentInfoByLeaseId(this.lease.Id);

            TblAll.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            TblAll.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            TblAll.Columns["PaidAt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
