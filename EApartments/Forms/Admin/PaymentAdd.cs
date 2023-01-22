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
    public partial class PaymentAdd : Form
    {
        PaymentService _paymentService = new PaymentService();
        Lease lease;

        public PaymentAdd(Lease lease)
        {
            this.lease = lease;
            InitializeComponent();
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
                    LeasePayment payment = new LeasePayment();
                    payment.LeaseId = lease.Id;
                    payment.Amount = decimal.Parse(txtPaidAmount.Text);
                    payment.PaidAt = DateTime.Today;

                    var result = this._paymentService.AddPayment(payment);

                    if (result)
                    {
                        MessageBox.Show("Payment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
