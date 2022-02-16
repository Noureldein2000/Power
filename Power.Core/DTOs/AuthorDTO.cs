using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.DTOs
{
    [Serializable]
    public class AuthorDTO
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public IEnumerable<BookDTO> Books { get; set; }
    }
}
