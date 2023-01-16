using EApartments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApartments.Services
{
    public interface UtillService
    {
        List<Role> GetAllUserRoles();
        List<ApartmentCategory> GetAllApartmentCategories();
        List<Building> GetAllBuildings();
    }
}
