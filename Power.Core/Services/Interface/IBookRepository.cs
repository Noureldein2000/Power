using Power.Core.Repository;
using Power.Data.Entities;
using Power.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.Services.Interface
{
    public interface IBookRepository : IBaseRepository<Book, Guid>
    {
        IEnumerable<Book> GetBooks();
        public Book AddSpecialBooks(Book book);
    }
}
