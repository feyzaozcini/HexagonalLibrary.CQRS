using HexagonalSample.Application.DtoClasses.BookTags.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.BookTagPorts
{
    public interface IGetBookTagByIdUseCase: IRequestHandler<GetBookTagByIdQuery, GetBookTagQueryResult>
    {
        Task<GetBookTagQueryResult> ExecuteAsync(GetBookTagByIdQuery query);
    }
}
