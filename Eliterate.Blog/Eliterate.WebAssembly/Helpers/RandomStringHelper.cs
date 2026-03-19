using System.Collections.Immutable;

namespace Eliterate.WebAssembly;

public static class RandomStringHelper
{
    private static readonly ImmutableArray<string> _emojis = ["⌨", "📱", "🖥", "📦", "⚖", "💣", "📜", "📺", "🎧", "🕶", "⚙", "🦋"];
    private static readonly ImmutableArray<string> _taglines = 
        [
        "Ramblings of a code monkey",
        "When you don't know where you're going, any road will take you there",
        "idk, I just work here",
        "Sometimes it seems we're just spinning our wheels and then suddenly... we move",
        "I'll start the engine, but I can't take this ride for you"
        ];
    public static string GetRandomEmojiBasedOnString(string? value)
        => _emojis[value is not null ? value.GetIntFromString(_emojis.Length) : Random.Shared.Next(_emojis.Length)];
    public static string GetRandomTagline()
        => _taglines[Random.Shared.Next(_taglines.Length)];
}
