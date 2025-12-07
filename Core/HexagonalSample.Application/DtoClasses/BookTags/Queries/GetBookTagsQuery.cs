using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.BookTags.Queries
{
    public class GetBookTagsQuery : IRequest<List<GetBookTagQueryResult>>
    {
    }

}
