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

        public List<Building> GetAllBuildings()
        {
            return this.appDbContext.Building.ToList();
        }

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
