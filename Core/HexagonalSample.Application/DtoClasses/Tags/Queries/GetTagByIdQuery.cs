using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Tags.Queries
{
    public class GetTagByIdQuery : IRequest<GetTagQueryResult>
    {
        public int Id { get; set; }
        public GetTagByIdQuery(int id) => Id = id;
    }

}
