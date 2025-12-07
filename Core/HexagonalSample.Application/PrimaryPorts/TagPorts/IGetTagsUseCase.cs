using HexagonalSample.Application.DtoClasses.Tags.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.TagPorts
{
    public interface IGetTagsUseCase: IRequestHandler<GetTagsQuery, List<GetTagQueryResult>>
    {
        Task<List<GetTagQueryResult>> ExecuteAsync(GetTagsQuery query);
    }
}
