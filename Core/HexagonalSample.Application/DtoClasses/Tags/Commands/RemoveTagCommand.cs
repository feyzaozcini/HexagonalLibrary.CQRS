using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Tags.Commands
{
    public class RemoveTagCommand : IRequest<TagCommandResult>
    {
        public int Id { get; set; }
        public RemoveTagCommand(int id) => Id = id;
    }

}
