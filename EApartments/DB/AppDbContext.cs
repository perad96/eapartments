using EApartments.Forms.Admin;
using EApartments.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApartments.DB
{
    public class AppDbContext : DbContext
    {

        public DbSet<Customer> Customer { get; set; }

    }
}
