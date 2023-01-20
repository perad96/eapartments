using EApartments.DB;
using EApartments.Models;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EApartments.Services
{
    public class PaymentService
    {
        AppDbContext appDbContext = new AppDbContext();

        /// <summary>
        ///    Get all leases
        /// </summary>
        public List<Lease> GetAllLease()
        {
            return this.appDbContext.Lease.ToList();
        }


        /// <summary>
        ///    Add new lease, Assign appartment to a occupant, Make initial payment.
        /// </summary>
        /// <param name="lease"></param>
        /// <param name="payment"></param>
        public bool AddLease(Lease lease, LeasePayment payment)
        {
            var transaction = this.appDbContext.Database.BeginTransaction();
            try
            {
                var result = this.appDbContext.Lease.Add(lease);
                this.appDbContext.SaveChanges();

                if (result != null)
                {
                    payment.LeaseId = result.Id;
                    var resultpayment = this.appDbContext.LeasePayment.Add(payment);
                    this.appDbContext.SaveChanges();

                    if (resultpayment != null)
                    {    
                        transaction.Commit();
                        return true;
                    }
                }

                transaction.Rollback();
                MessageBox.Show("Something went wrong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception e)
            {
                transaction.Rollback(); 
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        
        /// <summary>
        ///    Request new appartment to a occupant.
        /// </summary>
        /// <param name="lease"></param>
        public bool AddApartmentRequest(Lease lease)
        {
            try
            {
                var result = this.appDbContext.Lease.Add(lease);
                this.appDbContext.SaveChanges();

                if (result != null)
                {
                    return true;
                }

                MessageBox.Show("Something went wrong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        ///    Add new appartment
        /// </summary>
        /// <param name="apartment"></param>
        public bool AddApartment(Apartment apartment)
        {
            try
            {
                var result = this.appDbContext.Apartment.Add(apartment);
                this.appDbContext.SaveChanges();

                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /// <summary>
        ///    Update building info
        /// </summary>
        /// <param name="building"></param>
        public bool UpdateBuilding(Building building)
        {
            try
            {
                Building updateObj = this.appDbContext.Building.Where(obj => obj.Id == building.Id).FirstOrDefault();
                updateObj.Title = building.Title;
                updateObj.Address = building.Address;
                updateObj.Description = building.Description;

                this.appDbContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        ///    Update appartment info
        /// </summary>
        /// <param name="apartment"></param>
        public bool UpdateApartment(Apartment apartment)
        {
            try
            {
                Apartment updateObj = this.appDbContext.Apartment.Where(obj => obj.Id == apartment.Id).FirstOrDefault();
                updateObj.CategoryId = apartment.CategoryId;
                updateObj.Code = apartment.Code;
                updateObj.Floor = apartment.Floor;
                updateObj.RentPrice = apartment.RentPrice;
                updateObj.Deposit = apartment.Deposit;
                updateObj.Status = apartment.Status;

                this.appDbContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        ///    Delete building
        /// </summary>
        /// <param name="building"></param>
        public bool DeleteBuilding(Building building)
        {
            try
            {
                this.appDbContext.Building.Attach(building);
                var result = this.appDbContext.Building.Remove(building);
                this.appDbContext.SaveChanges();

                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
