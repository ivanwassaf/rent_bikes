using RentBikes.Core.Domain;
using RentBikes.Core.Repositories;
using RentBikes.Persistence.Repositories;
using System.Collections.Generic;

namespace RentBikes.Core.BLL
{
    public class Bll_Client : Bll_Base<Client>, IBll_Client
    {
        IRepositoryClient repo = null;

        private IRepositoryClient Repo
        {
            get
            {
                if (repo == null) repo = new RepositoryClient(Db);
                return repo;
            }
        }

        public IEnumerable<Client> GetAllFull()
        {
            return Repo.GetAllFull();
        }
    }
}