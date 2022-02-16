using Power.Core.DTOs;
using Power.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.Services
{
    public interface IAuthorService
    {
        Author AddAuthor(Author author);
        Author GetById(int id);
        IEnumerable<Author> GetAll();
    }
}
