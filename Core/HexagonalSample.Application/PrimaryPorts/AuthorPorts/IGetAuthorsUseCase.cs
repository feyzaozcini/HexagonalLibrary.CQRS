using HexagonalSample.Application.DtoClasses.Authors.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.AuthorPorts
{
    public interface IGetAuthorsUseCase: IRequestHandler<GetAuthorsQuery, List<GetAuthorQueryResult>>
    {
        Task<List<GetAuthorQueryResult>> ExecuteAsync(GetAuthorsQuery query);
    }
}
