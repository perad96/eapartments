using EApartments.Models;
using System.Data.Entity;

namespace EApartments.DB
{
    public class AppDbContext : DbContext
    {

        public DbSet<Apartment> Apartment { get; set; }
        public DbSet<ApartmentCategory> ApartmentCategory { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<Lease> Lease { get; set; }
        public DbSet<LeasePayment> LeasePayment { get; set; }
        public DbSet<Occupant> Occupant { get; set; }
        public DbSet<ParkingSpace> ParkingSpace { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<WaitingList> WaitingList { get; set; }

    }
}
