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
    public class RemoveBookUseCase : IRemoveBookUseCase
    {
        private readonly IBookRepository _repository;

        public RemoveBookUseCase(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookCommandResult> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<BookCommandResult> ExecuteAsync(RemoveBookCommand command)
        {
            var book = await _repository.GetByIdAsync(command.Id);
            if (book == null)
                throw new NotFoundException("Book not found");

            await _repository.RemoveAsync(book);

            return new BookCommandResult
            {
                Id = book.Id,
                Message = "Book deleted successfully"
            };
        }
    }

}
