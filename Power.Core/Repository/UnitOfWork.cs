using Power.Data;
using Power.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            //Authors = new BaseRepository<Author, int>(_context);
            //Books= new BookRepository<Book, int>(_context);

        }

        //when need to load all repositories in unit of work ...
        //public IBaseRepository<Author, int> Authors { get; private set; }

        //Note: when need to make specific repository of type like Book...
        //public IBookRepository<Book, Guid> Books { get; private set; }


        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
        }
    }
}
