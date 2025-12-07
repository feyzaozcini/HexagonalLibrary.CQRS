using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.BookTags.Commands
{
    public class RemoveBookTagCommand : IRequest<BookTagCommandResult>
    {
        public int Id { get; set; }
        public RemoveBookTagCommand(int id) => Id = id;
    }

}
