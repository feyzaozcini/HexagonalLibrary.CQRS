using AutoMapper;
using HexagonalSample.Application.DtoClasses.Authors.Queries;
using HexagonalSample.Application.Exceptions;
using HexagonalSample.Application.PrimaryPorts.AuthorPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.AuthorUseCases
{
    public class GetAuthorByIdUseCase : IGetAuthorByIdUseCase
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public GetAuthorByIdUseCase(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAuthorQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<GetAuthorQueryResult> ExecuteAsync(GetAuthorByIdQuery query)
        {
            var author = await _repository.GetByIdAsync(query.Id);
            if (author == null)
                throw new NotFoundException("Author not found");

            return _mapper.Map<GetAuthorQueryResult>(author);
        }
    }

}
