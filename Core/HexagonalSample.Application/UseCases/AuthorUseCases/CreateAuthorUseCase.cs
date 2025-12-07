using AutoMapper;
using HexagonalSample.Application.DtoClasses.Authors.Commands;
using HexagonalSample.Application.PrimaryPorts.AuthorPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.AuthorUseCases
{
    public class CreateAuthorUseCase : ICreateAuthorUseCase
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public CreateAuthorUseCase(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthorCommandResult> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<AuthorCommandResult> ExecuteAsync(CreateAuthorCommand command)
        {
            var author = _mapper.Map<Author>(command);
            author.CreatedDate = DateTime.Now;
            author.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(author);

            return new AuthorCommandResult
            {
                Id = author.Id,
                Message = "Author created successfully"
            };
        }
    }

}
