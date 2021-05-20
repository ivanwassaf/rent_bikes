using RentBikes.Core.Domain;
using System.Collections.Generic;

namespace RentBikes.Core.Repositories
{
    public interface IRepositoryClient : IRepository<Client>
    {
        IEnumerable<Client> GetAllFull();
    }
}
