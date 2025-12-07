using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Tags.Commands
{
    public class CreateTagCommand : IRequest<TagCommandResult>
    {
        public string TagName { get; set; }
    }

}
