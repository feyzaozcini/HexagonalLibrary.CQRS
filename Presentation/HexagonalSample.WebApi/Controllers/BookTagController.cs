using HexagonalSample.Application.DtoClasses.BookTags.Commands;
using HexagonalSample.Application.DtoClasses.BookTags.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookTagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AppBookTagList()
        {
            List<GetBookTagQueryResult> bookTags = await _mediator.Send(new GetBookTagsQuery());
            return Ok(bookTags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookTag(int id)
        {
            GetBookTagQueryResult value = await _mediator.Send(new GetBookTagByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookTag(CreateBookTagCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookTag(int id)
        {
            return Ok(await _mediator.Send(new RemoveBookTagCommand(id)));
        }
    }
}
