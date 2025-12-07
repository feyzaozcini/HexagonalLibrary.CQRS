using HexagonalSample.Application.DtoClasses.Books.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.BookPorts
{
    public interface IGetBooksUseCase: IRequestHandler<GetBooksQuery, List<GetBookQueryResult>>
    {
        Task<List<GetBookQueryResult>> ExecuteAsync(GetBooksQuery query);
    }
}
