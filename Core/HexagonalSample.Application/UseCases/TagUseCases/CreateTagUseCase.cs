using AutoMapper;
using HexagonalSample.Application.DtoClasses.Tags.Commands;
using HexagonalSample.Application.PrimaryPorts.TagPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.TagUseCases
{
    public class CreateTagUseCase : ICreateTagUseCase
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public CreateTagUseCase(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TagCommandResult> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<TagCommandResult> ExecuteAsync(CreateTagCommand command)
        {
            var tag = _mapper.Map<Tag>(command);
            tag.CreatedDate = DateTime.Now;
            tag.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(tag);

            return new TagCommandResult
            {
                Id = tag.Id,
                Message = "Tag created successfully"
            };
        }
    }

}
