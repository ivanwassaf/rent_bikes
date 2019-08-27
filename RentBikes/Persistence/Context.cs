using RentBikes.Core.Domain;
//using RentBikes.Persistence.EntityConfigurations;
using System.Data.Entity;

namespace RentBikes.Persistence
{
    public class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new CourseConfiguration());
        }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<RentalType> RentalTypes { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Rental> Rentals { get; set; }
    }
}
