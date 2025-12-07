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
    public class RemoveTagUseCase : IRemoveTagUseCase
    {
        private readonly ITagRepository _repository;

        public RemoveTagUseCase(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<TagCommandResult> Handle(RemoveTagCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<TagCommandResult> ExecuteAsync(RemoveTagCommand command)
        {
            var tag = await _repository.GetByIdAsync(command.Id);
            if (tag == null)
                throw new NotFoundException("Tag not found");

            await _repository.RemoveAsync(tag);

            return new TagCommandResult
            {
                Id = tag.Id,
                Message = "Tag deleted successfully"
            };
        }
    }

}
