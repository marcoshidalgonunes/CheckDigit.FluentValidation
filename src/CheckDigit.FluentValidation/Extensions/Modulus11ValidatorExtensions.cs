using FluentValidation;

namespace CheckDigit.FluentValidation;

public static class Modulus11ValidatorExtensions
{
    public static IRuleBuilderOptions<T, long> HasValidModulus11<T>(this IRuleBuilder<T, long> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new NumericModulus11Validator<T>());
    }

    public static IRuleBuilderOptions<T, string> HasValidModulus11<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new StringModulus11Validator<T>());
    }
}
