using EApartments.DB;
using EApartments.Models;
using Google.Protobuf.WellKnownTypes;
using System;
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
