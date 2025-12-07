using HexagonalSample.Application.DtoClasses.Authors.Commands;
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
    public class RemoveAuthorUseCase : IRemoveAuthorUseCase
    {
        private readonly IAuthorRepository _repository;

        public RemoveAuthorUseCase(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<AuthorCommandResult> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<AuthorCommandResult> ExecuteAsync(RemoveAuthorCommand command)
        {
            var author = await _repository.GetByIdAsync(command.Id);
            if (author == null)
                throw new NotFoundException("Author not found");

            await _repository.RemoveAsync(author);

            return new AuthorCommandResult
            {
                Id = author.Id,
                Message = "Author deleted successfully"
            };
        }
    }

}
