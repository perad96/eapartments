using EApartments.DB;
using EApartments.Forms.Admin;
using EApartments.Models;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EApartments.Services
{
    public class ApartmentService
    {
        AppDbContext appDbContext = new AppDbContext();


        /// <summary>
        ///    Get all buildings
        /// </summary>
        public List<Building> GetAllBuildings()
        {
            return this.appDbContext.Building.ToList();
        }


        /// <summary>
        ///    Get all appartments according to building and class (Category)
        /// </summary>
        /// <param name="buildingId"></param>
        /// <param name="categoryId"></param>
        public IList GetAllApartmentsByBuildingAndClass(int buildingId, int categoryId)
        {
            var result = this.appDbContext.Apartment.Join(appDbContext.Building,
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
                    BuildingTitle = building.Title
                })
                .Join(appDbContext.ApartmentCategory,
                apartment => apartment.CategoryId,
                category => category.Id,
                (apartment, category) => new {
                    apartment.Id,
                    apartment.Code,
                    apartment.RentPrice,
                    apartment.Deposit,
                    apartment.Status,
                    apartment.BuildingId,
                    apartment.CategoryId,
                    BuildingTitle = apartment.BuildingTitle,
                    CategoryTitle = category.Title
                })
                .Where(r => r.BuildingId == buildingId)
                .Where(r => r.CategoryId == categoryId)
                .Select(r => new
                {
                    r.Id,
                    r.Code,
                    r.RentPrice,
                    r.Deposit,
                    r.BuildingTitle,
                    r.CategoryTitle,
                    r.Status
                }).ToList();

            return result;
        }


        /// <summary>
        ///    Get all available appartments according to building and class (Category) for customer view
        /// </summary>
        /// <param name="buildingId"></param>
        /// <param name="categoryId"></param>
        public IList GetAllAvailableApartmentsByBuildingAndClass(int buildingId, int categoryId)
        {
            var result = this.appDbContext.Apartment.Join(appDbContext.Building,
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
                    BuildingTitle = building.Title
                })
                .Join(appDbContext.ApartmentCategory,
                apartment => apartment.CategoryId,
                category => category.Id,
                (apartment, category) => new {
                    apartment.Id,
                    apartment.Code,
                    apartment.RentPrice,
                    apartment.Deposit,
                    apartment.Status,
                    apartment.BuildingId,
                    apartment.CategoryId,
                    BuildingTitle = apartment.BuildingTitle,
                    CategoryTitle = category.Title
                })
                .Where(r => r.BuildingId == buildingId)
                .Where(r => r.CategoryId == categoryId)
                .Where(r => r.Status == "AVAILABLE")
                .Select(r => new
                {
                    r.Id,
                    r.Code,
                    r.RentPrice,
                    r.Deposit,
                    r.BuildingTitle,
                    r.CategoryTitle,
                    r.Status
                }).ToList();

            return result;
        }
        
        /// <summary>
        ///    Get all requested appartments
        /// </summary>
        public IList GetAllRequestedApartments()
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
                .Where(r => r.LeaseStatus == "REQUESTED")
                .Select(r => new
                {
                    r.Id,
                    r.Code,
                    r.RentPrice,
                    r.Deposit,
                    r.Status,
                    r.BuildingId,
                    r.CategoryId,
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
        ///    Add building
        /// </summary>
        /// <param name="building"></param>
        public bool AddBuilding(Building building)
        {
            try
            {
                var result = this.appDbContext.Building.Add(building);
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
        ///    Add appartment
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
        ///    Update building data
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
