using Codespirals.Base;

namespace Eliterate.WebAssembly;

public class PostMetadata : ICreatable, IEditable, IPostMetadata
{
    public string Id => Title.ToUrlSafeString();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string[] Tags { get; set; } = [];
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Edited { get; set; }
    public string ContentUrl { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public bool ShowInList { get; set; } = true;
    public string StickerEmoji { get; set; } = "";
    public int EstimatedReadTimeInMinutes { get; set; } = 5;

    public decimal GetRotationFromTitle(int limit) => Title.GetRotationFromString(limit);
}
