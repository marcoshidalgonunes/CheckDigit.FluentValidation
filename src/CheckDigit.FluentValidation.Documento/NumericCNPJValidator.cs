using CheckDigit.Documento;
using FluentValidation;
using FluentValidation.Validators;

namespace CheckDigit.FluentValidation.Documento;

public class NumericCNPJValidator<T> : PropertyValidator<T, long>
{
    private static readonly CNPJCompute _CNPJCompute = new();

    #region PropertyValidator members

    public override string Name => "NumericCNPJValidator";

    public override bool IsValid(ValidationContext<T> context, long value) => _CNPJCompute.Validate(value);

    #endregion
}