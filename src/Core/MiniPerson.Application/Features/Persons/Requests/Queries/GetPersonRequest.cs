using MediatR;
using MiniPerson.Domain.DTO;

namespace MiniPerson.Application.Features.Person.Requests.Queries
{
    public class GetPersonRequest : IRequest<List<PersonAllDto>>
    {

    }
}
