using HexagonalSample.Application.DtoClasses.Authors.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.AuthorPorts
{
    public interface IRemoveAuthorUseCase: IRequestHandler<RemoveAuthorCommand, AuthorCommandResult>
    {
        Task<AuthorCommandResult> ExecuteAsync(RemoveAuthorCommand command);
    }
}
