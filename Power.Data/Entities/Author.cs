using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Data.Entities
{
    [Serializable]
    public class Author : BaseEntity<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
