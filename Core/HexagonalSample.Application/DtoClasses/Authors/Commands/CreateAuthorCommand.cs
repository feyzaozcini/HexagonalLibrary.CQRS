using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Authors.Commands
{
    public class CreateAuthorCommand : IRequest<AuthorCommandResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
