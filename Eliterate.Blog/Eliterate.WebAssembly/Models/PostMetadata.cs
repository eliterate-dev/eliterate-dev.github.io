namespace Eliterate.WebAssembly;

public class PostMetadata
{
    public int Id { get; set; }
    public int PostNumber { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string[] Tags { get; set; } = [];
    public DateTime Posted { get; set; }
    public DateTime LastEdited { get; set; }
    public string ContentUrl { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public bool ShowInList { get; set; } = true;
}
