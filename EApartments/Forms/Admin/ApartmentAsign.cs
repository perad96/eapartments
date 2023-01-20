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
    public partial class ApartmentAsign : Form
    {
        Apartment apartment;
        PaymentService _paymentService = new PaymentService();
        OccupantService _occupantService = new OccupantService();

        public ApartmentAsign(Apartment apartment)
        {
            this.apartment = apartment;
            InitializeComponent();
            LoadCustomersToCmb();
        }

        private void LoadCustomersToCmb()
        {
            List<Occupant> data = this._occupantService.GetAllOccupants();
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            cmbCustomer.DataSource = bs;
            cmbCustomer.DisplayMember = "FirstName";
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
                if (txtPaidAmount.Text == "" || !Regex.IsMatch(txtPaidAmount.Text, @"^\d+$"))
                {
                    MessageBox.Show("Please enter valid amount!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (datePickerFrom.Text == "")
                {
                    MessageBox.Show("Please select from date!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (datePickerTo.Text == "")
                {
                    MessageBox.Show("Please select to date!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Occupant occupant = (Occupant)cmbCustomer.SelectedItem;

                    Lease lease = new Lease();
                    lease.ApartmentId = this.apartment.Id;
                    lease.OccupantId = occupant.Id;
                    lease.StartDate = DateTime.Parse(datePickerFrom.Text);
                    lease.EndDate = DateTime.Parse(datePickerTo.Text);

                    LeasePayment payment = new LeasePayment();
                    payment.Amount = decimal.Parse(txtPaidAmount.Text);   
                    payment.PaidAt = DateTime.Today;   

                    var result = this._paymentService.AddLease(lease, payment);

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

        private void ApartmentAsign_Load(object sender, EventArgs e)
        {
            txtCode.Text = this.apartment.Code;
            txtDeposite.Text = this.apartment.Deposit+"";
            txtFloor.Text = this.apartment.Floor+"";
            txtRentPrice.Text = this.apartment.RentPrice+"";
        }
    }
}
