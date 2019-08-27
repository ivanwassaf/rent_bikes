using RentBikes.Core.Domain;
using RentBikes.Core.Repositories;
using RentBikes.Persistence.Repositories;
using System.Collections.Generic;

namespace RentBikes.Core.BLL
{
    public class Bll_Rental : Bll_Base<Rental>, IBll_Rental
    {
        IRepository<Rental> repo = null;

        private IRepository<Rental> Repo
        {
            get
            {
                if (repo == null) repo = new RepositoryRental(Db);
                return repo;
            }
        }

        public override IEnumerable<Rental> GetAll()
        {
            return Repo.GetAll();
        }
    }
}