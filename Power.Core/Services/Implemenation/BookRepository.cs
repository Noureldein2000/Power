using Microsoft.EntityFrameworkCore;
using Power.Core.Repository;
using Power.Core.Services.Interface;
using Power.Data;
using Power.Data.Entities;
using Power.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.Services.Implemenation
{
    public class BookRepository : BaseRepository<Book, Guid>, IBookRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Book> GetBooks()
        {
            var books = GetAll().Select(s => new Book
            {
                Id = s.Id,
                Name = s.Name,
                Genre = s.Genre,
                Price = s.Price,
                AuthorId = s.AuthorId,
                CreationDate = s.CreationDate,
                Author = s.Author
            }).ToList();

            return books;
        }

        public Book AddSpecialBooks(Book book)
        {
            var entity = Add(book);
            _unitOfWork.Commit();
            return entity;
        }
    }
}
