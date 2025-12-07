using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Books.Queries
{
    public class GetBookByIdQuery : IRequest<GetBookQueryResult>
    {
        public int Id { get; set; }
        public GetBookByIdQuery(int id) => Id = id;
    }

}
