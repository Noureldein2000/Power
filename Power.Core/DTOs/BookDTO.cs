using Power.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.DTOs
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public GenreType Genre { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public double Price { get; set; }
        public bool IsFree { get; set; }
    }

    public class AddBookDTO
    {
        public string Name { get; set; }
        public GenreType Genre { get; set; }
        public int AuthorId { get; set; }
        public double Price { get; set; }
        public bool IsFree { get; set; }
    }
}
