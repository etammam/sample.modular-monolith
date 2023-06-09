using FluentValidation;
using FTTLib;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Samples.ModularMonolith.Plugins.Validators;

public static class FileValidators
{
    public static IRuleBuilderOptions<T, IFormFile> FileSmallerThan<T>(this IRuleBuilder<T, IFormFile> ruleBuilder, uint max)
    {
        return ruleBuilder.Must(file => MatchFileSize(file, max));
    }

    public static IRuleBuilderOptions<T, IFormFile> IsInCategory<T>(this IRuleBuilder<T, IFormFile> ruleBuilder,
        params FileCategory[] categories)
    {
        return ruleBuilder.Must(file => IsInCategory(categories, file));
    }

    private static bool IsInCategory(IEnumerable<FileCategory> categories, IFormFile value)
    {
        var mimeType = FTT.GetFileCategory(value.FileName);
        return categories.Contains(mimeType);
    }

    private static bool MatchFileSize(IFormFile value, uint maxFileSizeInBytes)
    {
        return value.Length <= maxFileSizeInBytes;
    }
}