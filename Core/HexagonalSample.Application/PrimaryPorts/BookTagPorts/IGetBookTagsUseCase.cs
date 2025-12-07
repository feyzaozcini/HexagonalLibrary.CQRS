using HexagonalSample.Application.DtoClasses.BookTags.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.BookTagPorts
{
    public interface IGetBookTagsUseCase: IRequestHandler<GetBookTagsQuery, List<GetBookTagQueryResult>>
    {
        Task<List<GetBookTagQueryResult>> ExecuteAsync(GetBookTagsQuery query);
    }
}
