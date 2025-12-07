using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Authors.Commands
{
    public class RemoveAuthorCommand : IRequest<AuthorCommandResult>
    {
        public int Id { get; set; }
        public RemoveAuthorCommand(int id) => Id = id;
    }

}
