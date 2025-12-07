using AutoMapper;
using HexagonalSample.Application.DtoClasses.Books.Commands;
using HexagonalSample.Application.Exceptions;
using HexagonalSample.Application.PrimaryPorts.BookPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.BookUseCases
{
    public class UpdateBookUseCase : IUpdateBookUseCase
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public UpdateBookUseCase(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookCommandResult> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<BookCommandResult> ExecuteAsync(UpdateBookCommand command)
        {
            var book = await _repository.GetByIdAsync(command.Id);
            if (book == null)
                throw new NotFoundException("Book not found");

            _mapper.Map(command, book);
            book.UpdatedDate = DateTime.Now;
            book.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(book);

            return new BookCommandResult
            {
                Id = book.Id,
                Message = "Book updated successfully"
            };
        }
    }

}
