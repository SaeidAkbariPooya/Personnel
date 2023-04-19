using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniPerson.Application.Features.Person.Requests.Queries;

namespace MiniPerson.Controllers.Person
{
    public class PersonQueriesController : BaseController
    {
        private readonly IMediator _mediator;
        public PersonQueriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetPersonRequest { };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("FullName/Data")]
        public async Task<IActionResult> GetById([FromQuery] GetPersonByIdRequest query)
        {
            //_logger.LogInformation(stateKey.ToLower());
            return Ok(await _mediator.Send(query));
        }

    }
}
