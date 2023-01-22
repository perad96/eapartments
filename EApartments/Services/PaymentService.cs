using EApartments.DB;
using EApartments.Forms.Admin;
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
        ///    Get all by occupant
        /// </summary>
        /// <param name="occupantId"></param>
        public IList GetAllByOccupant(int occupantId)
        {
            var result = this.appDbContext.Lease
                .Join(appDbContext.Apartment,
                lease => lease.ApartmentId,
                apartment => apartment.Id,
                (lease, apartment) => new {
                    apartment.Id,
                    apartment.Code,
                    apartment.RentPrice,
                    apartment.Deposit,
                    apartment.Status,
                    apartment.BuildingId,
                    apartment.CategoryId,
                    LeaseId = lease.Id,
                    OccupantId = lease.OccupantId,
                    LeaseStatus = lease.Status
                }).Join(appDbContext.Building,
                apartment => apartment.BuildingId,
                building => building.Id,
                (apartment, building) => new {
                    apartment.Id,
                    apartment.Code,
                    apartment.RentPrice,
                    apartment.Deposit,
                    apartment.Status,
                    apartment.BuildingId,
                    apartment.CategoryId,
                    apartment.LeaseId,
                    apartment.LeaseStatus,
                    apartment.OccupantId,
                    BuildingTitle = building.Title
                }).Join(appDbContext.ApartmentCategory,
                apartment => apartment.CategoryId,
                category => category.Id,
                (apartment, category) => new
                {
                    apartment.Id,
                    apartment.Code,
                    apartment.RentPrice,
                    apartment.Deposit,
                    apartment.Status,
                    apartment.BuildingId,
                    apartment.CategoryId,
                    apartment.LeaseId,
                    apartment.LeaseStatus,
                    apartment.OccupantId,
                    apartment.BuildingTitle,
                    CategoryTitle = category.Title
                }).Join(appDbContext.Occupant,
                apartment => apartment.OccupantId,
                occupant => occupant.Id,
                (apartment, occupant) => new
                {
                    apartment.Id,
                    apartment.Code,
                    apartment.RentPrice,
                    apartment.Deposit,
                    apartment.Status,
                    apartment.BuildingId,
                    apartment.CategoryId,
                    apartment.LeaseId,
                    apartment.BuildingTitle,
                    apartment.CategoryTitle,
                    apartment.LeaseStatus,
                    apartment.OccupantId,
                    FirstName = occupant.FirstName,
                    LastName = occupant.LastName,
                    Nic = occupant.Nic,
                    Email = occupant.Email,
                    Address = occupant.Address,
                })
                .Where(r => r.OccupantId == occupantId)
                .Select(r => new
                {
                    r.Id,
                    r.Code,
                    r.LeaseId,
                    r.LeaseStatus,
                    r.BuildingTitle,
                    r.CategoryTitle,
                    r.OccupantId,
                    r.FirstName,
                    r.LastName,
                    r.Nic,
                    r.Email,
                    r.Address,
                }).ToList();

            return result;
        }
        
        /// <summary>
        ///    Get all payment info by lease
        /// </summary>
        /// <param name="leaseId"></param>
        public List<LeasePayment> GetAllPaymentInfoByLeaseId(int leaseId)
        {
            return this.appDbContext.LeasePayment.Where(obj => obj.LeaseId == leaseId).ToList();

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
        ///    Confirm appartment request and add make initial payment.
        /// </summary>
        /// <param name="lease"></param>
        /// <param name="payment"></param>
        public bool ConfirmApartmentRequest(Lease lease, LeasePayment payment)
        {
            var transaction = this.appDbContext.Database.BeginTransaction();
            try
            {
                Lease searchedDataLease = this.appDbContext.Lease.Where(obj => obj.Id == lease.Id).FirstOrDefault();
                searchedDataLease.Status = "CONFIRMED";
                this.appDbContext.SaveChanges();

                Apartment apartmentUpdate = this.appDbContext.Apartment.Where(obj => obj.Id == searchedDataLease.ApartmentId).FirstOrDefault();
                apartmentUpdate.Status = "OCCUPIED";
                this.appDbContext.SaveChanges();

                payment.LeaseId = lease.Id;
                var resultpayment = this.appDbContext.LeasePayment.Add(payment);
                this.appDbContext.SaveChanges();
                    
                if (resultpayment != null)
                {    
                    transaction.Commit();
                    return true;
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
                Occupant occupant = this.appDbContext.Occupant.Where(obj => obj.UserId == lease.OccupantId).FirstOrDefault();
                if(occupant == null) {
                    MessageBox.Show("Invalid occupant!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                lease.OccupantId = occupant.Id;
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
        ///    Add payment
        /// </summary>
        /// <param name="payment"></param>
        public bool AddPayment(LeasePayment payment)
        {
            try
            {
                var result = this.appDbContext.LeasePayment.Add(payment);
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
