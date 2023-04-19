using AutoMapper;
using FluentValidation;
using MediatR;
using MiniPerson.Application.Features.Person.Requests.Queries;
using MiniPerson.Contract.Person.Queries;
using MiniPerson.Domain.DTO;

namespace MiniPerson.Application.Features.Persons.Handlers.Queries.GetPersonById
{
    public class GetPersonByIdRequestHandler : IRequestHandler<GetPersonByIdRequest, PersonDto>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private IValidator<GetPersonByIdRequest> _validator;

        public GetPersonByIdRequestHandler(IPersonRepository personRepository,
            IMapper mapper,
            IValidator<GetPersonByIdRequest> validator)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<PersonDto> Handle(GetPersonByIdRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new Exception(String.Join(",", validationResult.Errors.Select(q => q.ErrorMessage).ToArray()));
            }

            var person = await _personRepository.GetByPersonAsync(request.FullName,request.Date);
            return _mapper.Map<PersonDto>(person);
        }
    }
}
