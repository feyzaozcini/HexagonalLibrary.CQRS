using HexagonalSample.Application.DtoClasses.Tags.Commands;
using HexagonalSample.Application.DtoClasses.Tags.Queries;
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
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AppTagList()
        {
            List<GetTagQueryResult> Tags = await _mediator.Send(new GetTagsQuery());
            return Ok(Tags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            GetTagQueryResult value = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int id)
        {
            return Ok(await _mediator.Send(new RemoveTagCommand(id)));
        }
    }
}
