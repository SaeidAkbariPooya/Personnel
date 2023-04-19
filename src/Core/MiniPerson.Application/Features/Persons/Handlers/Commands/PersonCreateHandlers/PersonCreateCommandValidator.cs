using FluentValidation;
using MiniPerson.Application.Common.Validation;
using MiniPerson.Application.Features.LeaveTypes.Requests.Commands;

namespace MiniPerson.Application.Features.Persons.Handlers.Commands.PersonCreateHandlers
{
    public class PersonCreateCommandValidator : CustomValidator<CreatePersonCommand>
    {
        public PersonCreateCommandValidator()
        {
            RuleFor(p => p.PersonCreateDto.FullName).NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MinimumLength(3).WithMessage("{PropertyName} must not exceed 50")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50");
        }
    }
}