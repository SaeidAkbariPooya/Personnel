using FluentValidation;
using MiniPerson.Application.Features.Person.Requests.Queries;
using MiniPerson.Infrastructure.DataBase.Context;

namespace MiniPerson.Application.Features.Persons.Handlers.Queries.GetPersonById
{
    public class GetPersonByIdRequestValidator : AbstractValidator<GetPersonByIdRequest>
    {
        private readonly PersonDbContext _dbContext;
        public GetPersonByIdRequestValidator(PersonDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.FullName)
                .Must(BeExist).WithMessage("The person dose not exist.");
        }
        private bool BeExist(string fullName)
        {
            var person = _dbContext.Persons
                .FirstOrDefault(x => x.FullName == fullName);

            return person != null;
        }
    }
}