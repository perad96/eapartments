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
    public partial class ApartmentRequestUpdate : Form
    {
        PaymentService _paymentService = new PaymentService();
        Lease lease;
        Occupant occupant;
        Apartment apartment;

        public ApartmentRequestUpdate(Lease lease, Occupant occupant, Apartment apartment)
        {
            this.lease = lease;
            this.occupant = occupant;
            this.apartment = apartment;
            InitializeComponent();
        }

        private void ApartmentRequestUpdate_Load(object sender, EventArgs e)
        {
            txtCode.Text = apartment.Code;
            txtDeposite.Text = apartment.Deposit+"";
            txtRentPrice.Text = apartment.RentPrice+"";
            txtCustomer.Text = occupant.FirstName+" "+occupant.LastName;
        }

        protected bool IsVaidForm()
        {
            try
            {
                if (txtPaidAmount.Text == "" || !Regex.IsMatch(txtPaidAmount.Text, @"^\d+$"))
                {
                    MessageBox.Show("Please enter valid amount!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Lease lease = new Lease();
                    lease.Id = this.lease.Id;
                    lease.ApartmentId = this.apartment.Id;
                    lease.OccupantId = this.occupant.Id;

                    LeasePayment payment = new LeasePayment();
                    payment.LeaseId = lease.Id;
                    payment.Amount = decimal.Parse(txtPaidAmount.Text);
                    payment.PaidAt = DateTime.Today;

                    var result = this._paymentService.ConfirmApartmentRequest(lease, payment);

                    if (result)
                    {
                        MessageBox.Show("Appartment assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnReject_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show(
                "Do you really want to reject?",
                "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (DialogResult == DialogResult.Yes)
            {
                this.Hide();
            }
        }
    }
}
