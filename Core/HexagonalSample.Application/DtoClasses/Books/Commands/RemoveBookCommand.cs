using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Books.Commands
{
    public class RemoveBookCommand : IRequest<BookCommandResult>
    {
        public int Id { get; set; }
        public RemoveBookCommand(int id) => Id = id;
    }

}
