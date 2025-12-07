using HexagonalSample.Application.DtoClasses.Tags.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.TagPorts
{
    public interface IRemoveTagUseCase: IRequestHandler<RemoveTagCommand, TagCommandResult>
    {
        Task<TagCommandResult> ExecuteAsync(RemoveTagCommand command);
    }
}
