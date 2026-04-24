using Codespirals.Base.Extensions;

namespace Eliterate.WebAssembly;

public static class StringExtensions
{
    public static string ToUrlSafeString(this string value)
        => value.MakeUrlSafe('_').Trim('_').ToLowerInvariant();

    public static decimal GetRandomValueFromString(this string? value, int limit)
        => value is not null ? (value.Sum(c => c) / limit * 1.7m % limit) - (limit / 2m) : Random.Shared.Next(limit);
    public static int GetIntFromString(this string? value, int limit)
        => value is not null ? value.Sum(c => c) % limit : Random.Shared.Next(limit);
}
