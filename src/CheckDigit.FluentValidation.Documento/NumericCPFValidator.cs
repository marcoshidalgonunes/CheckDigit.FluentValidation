using CheckDigit.Documento;
using FluentValidation;
using FluentValidation.Validators;

namespace CheckDigit.FluentValidation.Documento;

public class NumericCPFValidator<T> : PropertyValidator<T, long>
{
    private static readonly CPFCompute _CPFCompute = new();

    #region PropertyValidator members

    public override string Name => "NumericCPFValidator";

    public override bool IsValid(ValidationContext<T> context, long value) => _CPFCompute.Validate(value);

    #endregion
}
