using Power.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        //IBaseRepository<Author, int> Authors { get; }
        //IBookRepository<Book, Guid> Books { get; }
        int Commit();
    }
}
