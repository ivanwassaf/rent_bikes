using RentBikes.Core.Domain;
using RentBikes.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RentBikes.Persistence.Repositories
{
    public class RepositoryRental : Repository<Rental>, IRepository<Rental>
    {
        //protected new readonly DbContext Context;

        public RepositoryRental(DbContext context) : base(context)
        {
            Context = context;
        }

        public new IEnumerable<Rental> GetAll()
        {
            return Context.Set<Rental>().Include(r => r.Client).Include(r => r.RentalType).Include(r => r.State).Include(r => r.Station).ToList();
        }


    }
}