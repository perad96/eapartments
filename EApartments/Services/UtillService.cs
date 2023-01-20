using EApartments.DB;
using EApartments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApartments.Services
{
    public class UtillService
    {
        AppDbContext appDbContext = new AppDbContext();

        /// <summary>
        ///    Get all user roles
        /// </summary>
        public List<Role> GetAllUserRoles()
        {
            return appDbContext.Role.ToList();
        }

        /// <summary>
        ///    Get all apartment classes (Categories)
        /// </summary>
        public List<ApartmentCategory> GetAllApartmentCategories()
        {
            return appDbContext.ApartmentCategory.ToList();
        }


        /// <summary>
        ///    Get all buildings
        /// </summary>
        public List<Building> GetAllBuildings()
        {
            return appDbContext.Building.ToList();
        }
    }
}
