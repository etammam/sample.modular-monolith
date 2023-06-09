using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Samples.ModularMonolith.Plugins.Validators;

public static class LanguageValidators
{
    private const string SpecialCharacters = "!@#$%^&*()_+'.\\-";
    private const string SpecialArabicLetters = $"\u0621-\u064A-{SpecialCharacters}";
    private const string SpecialEnglishLetters = $"a-zA-Z-{SpecialCharacters}";
    private const string NumbersRegex = "0-9";

    public static IRuleBuilderOptions<T, string> IsEnglish<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        bool allowSpaces = true,
        bool allowNumbers = true)
    {
        var numbers = allowNumbers ? NumbersRegex : "";

        var regex = allowSpaces ? $"^[{SpecialEnglishLetters}{numbers} ]*$" : $"^[{SpecialEnglishLetters}{numbers}]*$";
        var message = allowNumbers ? "'{PropertyName}' must contains English letters and numbers" : "'{PropertyName}' must contains English letters only";

        if (allowSpaces)
            message += " and could contain spaces";

        message += ".";

        return ruleBuilder.Matches(regex).WithMessage(message);
    }

    public static IRuleBuilderOptions<T, string> IsArabic<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        bool allowSpaces = true,
        bool allowNumbers = true)
    {
        var numbers = allowNumbers ? NumbersRegex : "";

        var regex = allowSpaces ? $"^[{SpecialArabicLetters}{numbers} ]*$" : $"^[{SpecialArabicLetters}{numbers}]*$";
        var message = allowNumbers ? "'{PropertyName}' must contains Arabic letters and numbers only" : "'{PropertyName}' must contains Arabic letters only";

        if (allowSpaces)
            message += " and could contain spaces";

        message += ".";

        return ruleBuilder.Matches(regex).WithMessage(message);
    }

    public static IRuleBuilderOptions<T, string> IsNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        const string regex = $"^[{NumbersRegex}]*$";
        const string message = "'{PropertyName}' must be numbers only.";

        return ruleBuilder.Matches(regex).WithMessage(message);
    }

    public static IRuleBuilderOptions<T, string> IsNumber<T>(this IRuleBuilder<T, string> ruleBuilder, bool allowPlus)
    {
        var regex = $"^[{NumbersRegex}]*$";
        const string message = "'{PropertyName}' must be numbers only.";

        if (allowPlus)
            regex = $"^[+{NumbersRegex}]*$";

        return ruleBuilder.Matches(regex).WithMessage(message);
    }

    public static IRuleBuilderOptions<T, string> NoSpecialCharactersOrNumbers<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        const string pattern = "[0123456789~`!@#$%^&()_={}[\\]:;,.<>+\\/?-]";
        var regex = new Regex(pattern);
        return ruleBuilder.Must((_, text) => !regex.IsMatch(text));
    }

    public static IRuleBuilderOptions<T, ICollection<int>> NotMissingNumber<T>(this IRuleBuilder<T, ICollection<int>> ruleBuilder)
    {
        return ruleBuilder.Must(value =>
        {
            var maxNumber = value.Max();

            var sum = 0;

            for (var i = maxNumber; i >= 1; i -= 1)
            {
                sum += i;
            }

            return sum == value.Sum();
        });
    }

    public static IRuleBuilderOptions<T, string> NoSpecialCharacters<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        const string pattern = "[~`!@#$%^&()_={}[\\]:;,.<>+\\/?-]";
        var regex = new Regex(pattern);
        return ruleBuilder.Must((_, text) => !regex.IsMatch(text));
    }

    public static IRuleBuilderOptions<T, string> NoSpaces<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must((_, text) => !text.Contains(" "));
    }
}