using Power.Core.DTOs;
using Power.Core.Repository;
using Power.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IBaseRepository<Author, int> _author;
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IBaseRepository<Author, int> author,
             IUnitOfWork unitOfWork)
        {
            _author = author;
            _unitOfWork = unitOfWork;
        }
        public Author AddAuthor(Author author)
        {
            var entity = _author.Add(author);
            _unitOfWork.Commit();
            return entity;
        }

        public IEnumerable<Author> GetAll()
        {
            return _author.GetWhere(x => x.Age > 10).Select(x => new Author
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age,
                Books = x.Books
            }).ToList();
        }

        public Author GetById(int id)
        {
            return _author.GetById(id);
        }
    }
}
