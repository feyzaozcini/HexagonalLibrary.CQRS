using AutoMapper;
using HexagonalSample.Application.DtoClasses.Books.Queries;
using HexagonalSample.Application.PrimaryPorts.BookPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.BookUseCases
{
    public class GetBooksUseCase : IGetBooksUseCase
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetBooksUseCase(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetBookQueryResult>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<List<GetBookQueryResult>> ExecuteAsync(GetBooksQuery query)
        {
            var books = await _repository.GetAllAsync();
            return _mapper.Map<List<GetBookQueryResult>>(books);
        }
    }

}
