using HexagonalSample.Application.DtoClasses.BookTags.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.BookTagPorts
{
    public interface IRemoveBookTagUseCase : IRequestHandler<RemoveBookTagCommand, BookTagCommandResult>
    {
        Task<BookTagCommandResult> ExecuteAsync(RemoveBookTagCommand command);
    }
}
