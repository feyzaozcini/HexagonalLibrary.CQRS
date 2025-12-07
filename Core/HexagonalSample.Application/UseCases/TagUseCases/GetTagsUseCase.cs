using AutoMapper;
using HexagonalSample.Application.DtoClasses.Tags.Queries;
using HexagonalSample.Application.PrimaryPorts.TagPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.TagUseCases
{
    public class GetTagsUseCase : IGetTagsUseCase
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public GetTagsUseCase(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetTagQueryResult>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<List<GetTagQueryResult>> ExecuteAsync(GetTagsQuery query)
        {
            var tags = await _repository.GetAllAsync();
            return _mapper.Map<List<GetTagQueryResult>>(tags);
        }
    }

}
