using EApartments.DB;
using EApartments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApartments.Services.Impl
{
    public class OccupantServiceImpl : OccupantService
    {
        AppDbContext appDbContext;

        public OccupantServiceImpl(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public Occupant AddOccupant(Occupant obj)
        {
            var result = appDbContext.Occupant.Add(obj);
            appDbContext.SaveChanges();

            return result;
        }


    }
}
