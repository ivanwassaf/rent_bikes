using RentBikes.Core.Domain;
using RentBikes.Core.Repositories;
using RentBikes.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RentBikes.Core.BLL
{
    public class Bll_Station : Bll_Base<Station>, IBll_Station
    {
        IRepository<Station> repo = null;

        private IRepository<Station> Repo
        {
            get
            {
                if (repo == null) repo = new RepositoryStation(Db);
                return repo;
            }
        }

        public override IEnumerable<Station> GetAll()
        {
            return Repo.GetAll();
        }
    }
}