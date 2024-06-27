using FluentValidation;

namespace CheckDigit.FluentValidation;

public static class Modulus10ValidatorExtensions
{
    private static readonly Modulus10Compute _compute = new();

    public static IRuleBuilderOptions<T, long> HasValidModulus10<T>(this IRuleBuilder<T, long> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new NumericModulus10Validator<T>());
    }

    public static IRuleBuilderOptions<T, string> HasValidModulus10<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new StringModulus10Validator<T>());
    }
}
