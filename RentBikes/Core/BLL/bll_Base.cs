using RentBikes.Core.Repositories;
using RentBikes.Persistence;
using RentBikes.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RentBikes.Core.BLL
{
    public class bll_Base<T> : Ibll_Base<T> where T : class 
    {
        private static Context db
        {
            get { return new Context(); }
        }

        //UnitOfWork uofw = new UnitOfWork(new Context());

        private IRepository<T> Repo
        {
            get { return new Repository<T>(db); }
        }

        public IEnumerable<T> GetAll()
        {
            return Repo.GetAll();
        }

        public T Get(int id)
        {
            return Repo.Get(id);
        }

        public void Create(T entity)
        {
            Repo.Add(entity);
        }

        public void Edit(T entity)
        {
            Repo.Edit(entity);
        }

        public IEnumerable<T> Details(Expression<Func<T, bool>> predicate)
        {
            return Repo.Find(predicate);
        }

        public void Delete(int id)
        {
            Repo.Remove(id);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        //db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}