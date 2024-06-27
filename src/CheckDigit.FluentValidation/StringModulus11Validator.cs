using FluentValidation;
using FluentValidation.Validators;

namespace CheckDigit.FluentValidation;

public class StringModulus11Validator<T> : PropertyValidator<T, string>
{
    private static readonly Modulus11Compute _modulus11Compute = new();

    #region PropertyValidator members

    public override string Name => "StringModulus11Validator";

    public override bool IsValid(ValidationContext<T> context, string value) => _modulus11Compute.Validate(value);

    #endregion
}