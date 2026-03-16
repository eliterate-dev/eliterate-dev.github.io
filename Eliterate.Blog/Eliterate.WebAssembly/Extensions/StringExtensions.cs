using Codespirals.Base.Extensions;

namespace Eliterate.WebAssembly;

public static class StringExtensions
{
    public static string ToUrlSafeString(this string value)
        => value.MakeUrlSafe('_').Trim('_').ToLowerInvariant();
}
