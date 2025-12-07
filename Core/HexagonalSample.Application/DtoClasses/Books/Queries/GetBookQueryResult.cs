using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Books.Queries
{
    public class GetBookQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageSize { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
    }

}
