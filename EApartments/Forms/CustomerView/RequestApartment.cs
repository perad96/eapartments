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

namespace EApartments.Forms.CustomerView
{
    public partial class RequestApartment : Form
    {

        Apartment apartment;
        PaymentService _paymentService = new PaymentService();
        OccupantService _occupantService = new OccupantService();
        User authUser = new User();

        public RequestApartment(Apartment apartment, User authUser)
        {
            InitializeComponent();
            this.apartment = apartment;
            this.authUser = authUser;
        }

        protected bool IsVaidForm()
        {
            try
            {
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
                    Lease lease = new Lease();
                    lease.ApartmentId = this.apartment.Id;
                    lease.OccupantId = this.authUser.Id;
                    lease.StartDate = DateTime.Parse(datePickerFrom.Text);
                    lease.EndDate = DateTime.Parse(datePickerTo.Text);

                    var result = this._paymentService.AddApartmentRequest(lease);

                    if (result)
                    {
                        MessageBox.Show("Appartment requested successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void RequestApartment_Load(object sender, EventArgs e)
        {
            txtCode.Text = this.apartment.Code;
            txtDeposite.Text = this.apartment.Deposit + "";
            txtFloor.Text = this.apartment.Floor + "";
            txtRentPrice.Text = this.apartment.RentPrice + "";
        }
    }
}
