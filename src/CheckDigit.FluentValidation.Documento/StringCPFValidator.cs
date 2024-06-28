using CheckDigit.Documento;
using FluentValidation;
using FluentValidation.Validators;

namespace CheckDigit.FluentValidation.Documento;

public class StringCPFValidator<T> : PropertyValidator<T, string>
{
    private static readonly CPFCompute _CPFCompute = new();

    #region PropertyValidator members

    public override string Name => "StringCPFValidator";

    public override bool IsValid(ValidationContext<T> context, string value) => _CPFCompute.Validate(value);

    #endregion
}
