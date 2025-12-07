using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.BookTags.Commands
{
    public class CreateBookTagCommand : IRequest<BookTagCommandResult>
    {
        public int BookId { get; set; }
        public int TagId { get; set; }
    }

}
