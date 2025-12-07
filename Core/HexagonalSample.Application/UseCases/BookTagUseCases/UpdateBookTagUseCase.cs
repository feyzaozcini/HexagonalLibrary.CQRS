using AutoMapper;
using HexagonalSample.Application.DtoClasses.BookTags.Commands;
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
    public class UpdateBookTagUseCase : IUpdateBookTagUseCase
    {
        private readonly IBookTagRepository _repository;
        private readonly IMapper _mapper;

        public UpdateBookTagUseCase(IBookTagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookTagCommandResult> Handle(UpdateBookTagCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<BookTagCommandResult> ExecuteAsync(UpdateBookTagCommand command)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null)
                throw new NotFoundException("BookTag not found");

            _mapper.Map(command, entity);
            entity.UpdatedDate = DateTime.Now;
            entity.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(entity);

            return new BookTagCommandResult
            {
                Id = entity.Id,
                Message = "BookTag updated successfully"
            };
        }
    }

}
