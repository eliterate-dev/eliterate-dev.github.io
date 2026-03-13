using Codespirals.Base.Extensions;
namespace Eliterate.WebAssembly;

public class PostTag
{
    public string Id => Name.ToLowerInvariant().MakeUrlSafe('_').Trim('_');
    public required string Name { get; set; }
}
