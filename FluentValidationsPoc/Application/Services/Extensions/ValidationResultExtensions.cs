using FluentValidation.Results;

namespace Services.Extensions;
public static class ValidationResultExtensions
{
    public static string Messages(this ValidationResult validationResult) =>
        string.Join(Environment.NewLine, validationResult.Errors.Select(x => x.ErrorMessage));
}
