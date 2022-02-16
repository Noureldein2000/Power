using Power.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Data.Entities
{
    public class Book : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public GenreType Genre { get; set; }
        public int AuthorId { get; set; }
        public double Price { get; set; }
        public virtual Author Author { get; set; }
    }
}
