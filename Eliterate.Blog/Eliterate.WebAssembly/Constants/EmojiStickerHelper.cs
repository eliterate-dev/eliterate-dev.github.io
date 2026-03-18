using System.Collections.Immutable;

namespace Eliterate.WebAssembly;

public static class EmojiStickerHelper
{
    private static readonly ImmutableArray<string> _emojis = ["⌨", "📱", "🖥", "📦", "⚖", "💣", "📜", "📺", "🎧", "🕶", "⚙"];
    public static string GetRandomEmojiBasedOnString(string? value)
        => _emojis[value is not null ? value.GetIntFromString(_emojis.Length) : Random.Shared.Next(_emojis.Length)];
}
