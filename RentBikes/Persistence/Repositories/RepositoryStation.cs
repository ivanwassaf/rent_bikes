using RentBikes.Core.Domain;
using RentBikes.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RentBikes.Persistence.Repositories
{
    public class RepositoryStation : Repository<Station>, IRepository<Station>
    {
        //protected new readonly DbContext Context;

        public RepositoryStation(DbContext context) : base(context)
        {
            Context = context;
        }

        public new IEnumerable<Station> GetAll()
        {
            return Context.Set<Station>().Include(x => x.State).ToList();
        }

        
    }
}