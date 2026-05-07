using Codespirals.Base;

namespace Eliterate.WebAssembly
{
    public interface IPostMetadata : IIdentifiable, IDescribable, IHasCreateAndEditDate
    {
        string? Group { get; }
        string Title { get; }
        string[] Tags { get; }
        string? ContentUrl { get; }
        bool IsActive { get; }
        bool ShowInList { get; }
        string StickerEmoji { get; }
        int? EstimatedReadTimeInMinutes { get; }
    }
}