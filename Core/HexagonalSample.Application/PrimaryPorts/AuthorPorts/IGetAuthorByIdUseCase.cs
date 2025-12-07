using HexagonalSample.Application.DtoClasses.Authors.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.AuthorPorts
{
    public interface IGetAuthorByIdUseCase : IRequestHandler<GetAuthorByIdQuery, GetAuthorQueryResult>
    {
        Task<GetAuthorQueryResult> ExecuteAsync(GetAuthorByIdQuery query);
    }
}
