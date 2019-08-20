using RentBikes.Core.Repositories;
using System;

namespace RentBikes.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //ICourseRepository Courses { get; }
        //IAuthorRepository Authors { get; }
        int Complete();
    }
}