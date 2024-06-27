using FluentValidation;
using FluentValidation.Validators;

namespace CheckDigit.FluentValidation;

public class StringModulus10Validator<T> : PropertyValidator<T, string>
{
    private static readonly Modulus10Compute _modulus10Compute = new();

    #region PropertyValidator members

    public override string Name => "StringModulus10Validator";

    public override bool IsValid(ValidationContext<T> context, string value) => _modulus10Compute.Validate(value);

    #endregion
}
