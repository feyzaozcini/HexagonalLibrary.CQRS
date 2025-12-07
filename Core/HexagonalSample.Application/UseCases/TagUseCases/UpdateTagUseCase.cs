using AutoMapper;
using HexagonalSample.Application.DtoClasses.Tags.Commands;
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
    public class UpdateTagUseCase : IUpdateTagUseCase
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public UpdateTagUseCase(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TagCommandResult> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<TagCommandResult> ExecuteAsync(UpdateTagCommand command)
        {
            var tag = await _repository.GetByIdAsync(command.Id);
            if (tag == null)
                throw new NotFoundException("Tag not found");

            _mapper.Map(command, tag);
            tag.UpdatedDate = DateTime.Now;
            tag.Status = Domain.Enums.DataStatus.Updated;
            await _repository.UpdateAsync(tag);

            return new TagCommandResult
            {
                Id = tag.Id,
                Message = "Tag updated successfully"
            };
        }
    }

}
