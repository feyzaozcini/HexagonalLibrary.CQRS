using AutoMapper;
using HexagonalSample.Application.DtoClasses.Authors.Queries;
using HexagonalSample.Application.PrimaryPorts.AuthorPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.AuthorUseCases
{
    public class GetAuthorsUseCase : IGetAuthorsUseCase
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public GetAuthorsUseCase(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<List<GetAuthorQueryResult>> ExecuteAsync(GetAuthorsQuery query)
        {
            var authors = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAuthorQueryResult>>(authors);
        }
    }

}
