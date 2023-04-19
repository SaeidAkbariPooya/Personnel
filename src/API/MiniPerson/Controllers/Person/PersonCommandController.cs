using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniPerson.Application.Features.LeaveTypes.Requests.Commands;

namespace MiniPerson.Controllers.Person
{
    public class PersonCommandController : BaseController
    {
        private readonly IMediator _mediator;
        public PersonCommandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreatePersonCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
