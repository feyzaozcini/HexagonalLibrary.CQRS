using AutoMapper;
using HexagonalSample.Application.DtoClasses.Tags.Queries;
using HexagonalSample.Application.Exceptions;
using HexagonalSample.Application.PrimaryPorts.TagPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.TagUseCases
{
    public class GetTagByIdUseCase : IGetTagByIdUseCase
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public GetTagByIdUseCase(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetTagQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<GetTagQueryResult> ExecuteAsync(GetTagByIdQuery query)
        {
            var tag = await _repository.GetByIdAsync(query.Id);
            if (tag == null)
                throw new NotFoundException("Tag not found");

            return _mapper.Map<GetTagQueryResult>(tag);
        }
    }

}
