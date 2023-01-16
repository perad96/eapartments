using EApartments.Models;
using EApartments.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApartments.Services
{
    public interface OccupantService
    {
        Occupant AddOccupant(Occupant obj);
    }
}
