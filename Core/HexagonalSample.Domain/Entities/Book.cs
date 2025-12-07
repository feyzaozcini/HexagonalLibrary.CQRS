using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public int PageSize { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<BookTag> BookTags { get; set; }

    }
}
