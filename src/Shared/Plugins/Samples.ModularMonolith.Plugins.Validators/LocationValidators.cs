using FluentValidation;

namespace Samples.ModularMonolith.Plugins.Validators;

public static class LocationValidators
{
    public static IRuleBuilderOptions<T, decimal> IsLatitude<T>(
        this IRuleBuilder<T, decimal> ruleBuilder)
    {
        return ruleBuilder.Must(c => c is <= 90 and >= -90);
    }

    public static IRuleBuilderOptions<T, decimal> IsLongitude<T>(
        this IRuleBuilder<T, decimal> ruleBuilder)
    {
        return ruleBuilder.Must(c => c is <= 180 and >= -180);
    }
}