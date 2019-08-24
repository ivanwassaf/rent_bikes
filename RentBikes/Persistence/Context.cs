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

        //public virtual DbSet<Author> Authors { get; set; }
        //public virtual DbSet<Course> Courses { get; set; }
        //public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new CourseConfiguration());
        }

        public System.Data.Entity.DbSet<RentBikes.Core.Domain.Price> Prices { get; set; }

        public System.Data.Entity.DbSet<RentBikes.Core.Domain.Station> Stations { get; set; }

        public System.Data.Entity.DbSet<RentBikes.Core.Domain.State> States { get; set; }

        public System.Data.Entity.DbSet<RentBikes.Core.Domain.Client> Clients { get; set; }
    }
}
