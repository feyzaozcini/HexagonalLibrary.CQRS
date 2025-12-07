using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Tags.Commands
{
    public class UpdateTagCommand : IRequest<TagCommandResult>
    {
        public int Id { get; set; }
        public string TagName { get; set; }
    }

}
