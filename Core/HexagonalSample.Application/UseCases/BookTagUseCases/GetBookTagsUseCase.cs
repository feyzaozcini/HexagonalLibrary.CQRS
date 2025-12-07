using AutoMapper;
using HexagonalSample.Application.DtoClasses.BookTags.Queries;
using HexagonalSample.Application.PrimaryPorts.BookTagPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.BookTagUseCases
{
    public class GetBookTagsUseCase : IGetBookTagsUseCase
    {
        private readonly IBookTagRepository _repository;
        private readonly IMapper _mapper;

        public GetBookTagsUseCase(IBookTagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetBookTagQueryResult>> Handle(GetBookTagsQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<List<GetBookTagQueryResult>> ExecuteAsync(GetBookTagsQuery query)
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<GetBookTagQueryResult>>(list);
        }
    }

}
