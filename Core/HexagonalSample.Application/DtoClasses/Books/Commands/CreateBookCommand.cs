using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Books.Commands
{
    public class CreateBookCommand : IRequest<BookCommandResult>
    {
        public string Name { get; set; }
        public int PageSize { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
    }

}
