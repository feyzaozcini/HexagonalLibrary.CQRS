using AutoMapper;
using HexagonalSample.Application.DtoClasses.BookTags.Commands;
using HexagonalSample.Application.PrimaryPorts.BookTagPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.BookTagUseCases
{
    public class CreateBookTagUseCase : ICreateBookTagUseCase
    {
        private readonly IBookTagRepository _repository;
        private readonly IMapper _mapper;

        public CreateBookTagUseCase(IBookTagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookTagCommandResult> Handle(CreateBookTagCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<BookTagCommandResult> ExecuteAsync(CreateBookTagCommand command)
        {
            var entity = _mapper.Map<BookTag>(command);
            entity.CreatedDate = DateTime.Now;
            entity.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(entity);

            return new BookTagCommandResult
            {
                Id = entity.Id,
                Message = "BookTag created successfully"
            };
        }
    }

}
