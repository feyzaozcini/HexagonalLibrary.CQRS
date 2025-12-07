using HexagonalSample.Application.DtoClasses.Tags.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.TagPorts
{
    public interface IGetTagByIdUseCase: IRequestHandler<GetTagByIdQuery, GetTagQueryResult>
    {
        Task<GetTagQueryResult> ExecuteAsync(GetTagByIdQuery query);
    }
}
