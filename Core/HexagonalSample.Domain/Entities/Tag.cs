using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }

        public virtual ICollection<BookTag> BookTags { get; set; }

    }
}
