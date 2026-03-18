using Codespirals.Base.Extensions;

namespace Eliterate.WebAssembly;

public static class StringExtensions
{
    public static string ToUrlSafeString(this string value)
        => value.MakeUrlSafe('_').Trim('_').ToLowerInvariant();

    public static decimal GetRotationFromString(this string? value, int limit)
        => value is not null ? (value.Sum(c => c) / limit * 2.5m % limit) - (limit >> 1) : Random.Shared.Next(limit);
    public static int GetIntFromString(this string? value, int limit)
        => value is not null ? value.Sum(c => c) % limit : Random.Shared.Next(limit);
}
