using HexagonalSample.Application.DtoClasses.Books.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.BookPorts
{
    public interface IRemoveBookUseCase: IRequestHandler<RemoveBookCommand, BookCommandResult>
    {
        Task<BookCommandResult> ExecuteAsync(RemoveBookCommand command);
    }
}
