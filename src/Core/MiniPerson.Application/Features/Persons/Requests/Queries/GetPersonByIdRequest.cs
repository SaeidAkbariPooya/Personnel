using MediatR;
using MiniPerson.Domain.DTO;

namespace MiniPerson.Application.Features.Person.Requests.Queries
{
    public class GetPersonByIdRequest : IRequest<PersonDto>
    {
        //public long Id { get; set; }
        public string FullName { get; set; }
        public string Date { get; set; }
    }
}
