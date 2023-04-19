using MediatR;
using AutoMapper;
using MiniPerson.Application.Features.Person.Requests.Queries;
using MiniPerson.Domain.DTO;
using MiniPerson.Contract.Person.Queries;

namespace MiniPerson.Application.Features.Persons.Handlers.Queries.GetAllPerson
{
    public class GetAllPersonRequestHandler :
        IRequestHandler<GetPersonRequest, List<PersonAllDto>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetAllPersonRequestHandler(IPersonRepository personRepository,
            IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<List<PersonAllDto>> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetAllAsync();
            return person;
            //return _mapper.Map<List<PersonDto>>(person);
        }
    }
}
