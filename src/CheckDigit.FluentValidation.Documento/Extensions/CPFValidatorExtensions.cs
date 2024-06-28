using FluentValidation;

namespace CheckDigit.FluentValidation.Documento;

public static class CPFValidatorExtensions
{
    public static IRuleBuilderOptions<T, long> IsValidCPF<T>(this IRuleBuilder<T, long> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new NumericCPFValidator<T>());
    }

    public static IRuleBuilderOptions<T, string> IsValidCPF<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new StringCPFValidator<T>());
    }
}
