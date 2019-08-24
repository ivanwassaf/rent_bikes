﻿using RentBikes.Core;
using RentBikes.Core.Repositories;
using RentBikes.Persistence;
using RentBikes.Persistence.Repositories;

namespace RentBikes.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
            //Courses = new CourseRepository(_context);
            //Authors = new AuthorRepository(_context);
        }

        //public ICourseRepository Courses { get; private set; }
        //public IAuthorRepository Authors { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}