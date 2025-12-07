using AutoMapper;
using HexagonalSample.Application.DtoClasses.Books.Queries;
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
    public class GetBookByIdUseCase : IGetBookByIdUseCase
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetBookByIdUseCase(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetBookQueryResult> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<GetBookQueryResult> ExecuteAsync(GetBookByIdQuery query)
        {
            var book = await _repository.GetByIdAsync(query.Id);
            if (book == null)
                throw new NotFoundException("Book not found");

            return _mapper.Map<GetBookQueryResult>(book);
        }
    }

}
