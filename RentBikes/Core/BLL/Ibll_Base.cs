using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RentBikes.Core.BLL
{
    public interface IBll_Base<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Create(T entity);

        void Edit(T entity);

        IEnumerable<T> Details(Expression<Func<T, bool>> predicate);

        void Delete(int id);
    }
}