using FluentValidation;
using FluentValidation.Validators;

namespace CheckDigit.FluentValidation;

public class NumericModulus11Validator<T> : PropertyValidator<T, long>
{
    private static readonly Modulus11Compute _modulus11Compute = new();

    #region PropertyValidator members

    public override string Name => "NumericModulus11Validator";

    public override bool IsValid(ValidationContext<T> context, long value) => _modulus11Compute.Validate(value);

    #endregion
}
