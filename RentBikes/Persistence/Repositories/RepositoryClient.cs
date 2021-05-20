using RentBikes.Core.Domain;
using RentBikes.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RentBikes.Persistence.Repositories
{
    public class RepositoryClient : Repository<Client>, IRepositoryClient, IRepository<Client>
    {
        //protected new readonly DbContext Context;

        public RepositoryClient(DbContext context) : base(context)
        {
            Context = context;
        }

        //public new IEnumerable<Client> GetAllFull()
        //{
        //    return Context.Set<Client>().Include(x => x.State).Include(x => x.Rental).ToList();
        //}

        IEnumerable<Client> IRepositoryClient.GetAllFull()
        {
            return Context.Set<Client>().Include(x => x.State).Include(x => x.Rental).ToList();
        }
    }
}