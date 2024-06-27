using FluentValidation;
using FluentValidation.Validators;

namespace CheckDigit.FluentValidation;

public class NumericModulus10Validator<T> : PropertyValidator<T, long>
{
    private static readonly Modulus10Compute _modulus10Compute = new();

    #region PropertyValidator members

    public override string Name => "NumericModulus10Validator";

    public override bool IsValid(ValidationContext<T> context, long value) => _modulus10Compute.Validate(value);

    #endregion
}
