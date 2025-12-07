using AutoMapper;
using HexagonalSample.Application.DtoClasses.BookTags.Queries;
using HexagonalSample.Application.Exceptions;
using HexagonalSample.Application.PrimaryPorts.BookTagPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.BookTagUseCases
{
    public class GetBookTagByIdUseCase : IGetBookTagByIdUseCase
    {
        private readonly IBookTagRepository _repository;
        private readonly IMapper _mapper;

        public GetBookTagByIdUseCase(IBookTagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetBookTagQueryResult> Handle(GetBookTagByIdQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<GetBookTagQueryResult> ExecuteAsync(GetBookTagByIdQuery query)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null)
                throw new NotFoundException("BookTag not found");

            return _mapper.Map<GetBookTagQueryResult>(entity);
        }
    }

}
