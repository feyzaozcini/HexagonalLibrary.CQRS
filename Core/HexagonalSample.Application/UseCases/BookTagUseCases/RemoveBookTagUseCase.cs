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
    public class RemoveBookTagUseCase : IRemoveBookTagUseCase
    {
        private readonly IBookTagRepository _repository;

        public RemoveBookTagUseCase(IBookTagRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookTagCommandResult> Handle(RemoveBookTagCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<BookTagCommandResult> ExecuteAsync(RemoveBookTagCommand command)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null)
                throw new NotFoundException("BookTag not found");

            await _repository.RemoveAsync(entity);

            return new BookTagCommandResult
            {
                Id = entity.Id,
                Message = "BookTag deleted successfully"
            };
        }
    }

}
