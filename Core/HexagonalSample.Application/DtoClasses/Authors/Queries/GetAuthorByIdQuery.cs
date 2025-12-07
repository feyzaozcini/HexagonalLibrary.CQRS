using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Authors.Queries
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorQueryResult>
    {
        public int Id { get; set; }
        public GetAuthorByIdQuery(int id) => Id = id;
    }

}
