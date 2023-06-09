using FluentValidation;
using System;

namespace Samples.ModularMonolith.Plugins.Validators;

public static class DateValidators
{
    public static IRuleBuilderOptions<T, DateTime> NotInThePast<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
    {
        return ruleBuilder.Must((_, value) => DateTime.UtcNow <= value);
    }

    public static IRuleBuilderOptions<T, DateOnly> NotInThePast<T>(this IRuleBuilder<T, DateOnly> ruleBuilder)
    {
        return ruleBuilder.Must((_, value) => DateOnly.FromDateTime(DateTime.UtcNow) <= value);
    }

    public static IRuleBuilderOptions<T, TimeOnly> NotInThePast<T>(this IRuleBuilder<T, TimeOnly> ruleBuilder)
    {
        return ruleBuilder.Must((_, value) => TimeOnly.FromDateTime(DateTime.UtcNow) <= value);
    }

    public static IRuleBuilderOptions<T, DateTime> InFutureMonths<T>(this IRuleBuilder<T, DateTime> ruleBuilder, int months)
    {
        return ruleBuilder.Must((_, value) => DateOnly.FromDateTime(DateTime.Today).AddMonths(months) > DateOnly.FromDateTime(value));
    }

    public static IRuleBuilderOptions<T, DateOnly> InFutureMonths<T>(this IRuleBuilder<T, DateOnly> ruleBuilder, int months)
    {
        return ruleBuilder.Must((_, value) => DateOnly.FromDateTime(DateTime.Today).AddMonths(months) > value);
    }
}