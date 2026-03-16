using Codespirals.Base;

namespace Eliterate.WebAssembly
{
    public interface IPostMetadata : IIdentifiable, IDescribable, IHasCreateAndEditDate
    {
        string ContentUrl { get; }
        bool IsActive { get; }
        bool ShowInList { get; }
        string[] Tags { get; }
        string Title { get; }
    }
}