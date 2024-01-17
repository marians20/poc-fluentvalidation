using Contracts.Dtos;
using FluentValidation;

namespace Services.Validators;

public class PersonDtoValidator : AbstractValidator<PersonDto>
{
    public PersonDtoValidator()
    {
        RuleFor(c => c.Id).NotEmpty().WithMessage("Id must not be empty");
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name must not be empty");
        RuleFor(c => c.Name).SetValidator(new FullNameValidator()!);
    }
}