using AutoMapper;
using HexagonalSample.Application.DtoClasses.Books.Commands;
using HexagonalSample.Application.PrimaryPorts.BookPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.BookUseCases
{
    public class CreateBookUseCase : ICreateBookUseCase
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public CreateBookUseCase(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookCommandResult> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<BookCommandResult> ExecuteAsync(CreateBookCommand command)
        {
            var book = _mapper.Map<Book>(command);
            book.CreatedDate = DateTime.Now;
            book.Status = Domain.Enums.DataStatus.Inserted;
            await _repository.AddAsync(book);

            return new BookCommandResult
            {
                Id = book.Id,
                Message = "Book created successfully"
            };
        }
    }

}
