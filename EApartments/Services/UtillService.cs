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

        public List<Role> GetAllUserRoles()
        {
            return appDbContext.Role.ToList();
        }

        public List<ApartmentCategory> GetAllApartmentCategories()
        {
            return appDbContext.ApartmentCategory.ToList();
        }

        public List<Building> GetAllBuildings()
        {
            return appDbContext.Building.ToList();
        }
    }
}
