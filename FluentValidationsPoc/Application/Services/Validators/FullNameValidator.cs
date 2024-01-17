using FluentValidation;

namespace Services.Validators;

public interface IFullNameValidator : IValidator<string> { }
public class FullNameValidator : AbstractValidator<string>, IFullNameValidator
{
    public FullNameValidator()
    {
        RuleFor(c => c)
            .Must(c => c.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length > 1)
            .WithMessage("Full name should contain at least two words.");
    }
}
