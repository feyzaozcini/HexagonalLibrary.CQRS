using AutoMapper;
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
    public class UpdateAuthorUseCase : IUpdateAuthorUseCase
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public UpdateAuthorUseCase(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthorCommandResult> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<AuthorCommandResult> ExecuteAsync(UpdateAuthorCommand command)
        {
            var author = await _repository.GetByIdAsync(command.Id);
            if (author == null)
                throw new NotFoundException("Author not found");

            _mapper.Map(command, author);
            author.UpdatedDate = DateTime.Now;
            author.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(author);

            return new AuthorCommandResult
            {
                Id = author.Id,
                Message = "Author updated successfully"
            };
        }
    }

}
