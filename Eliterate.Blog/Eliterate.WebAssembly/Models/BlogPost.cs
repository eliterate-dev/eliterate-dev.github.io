namespace Eliterate.WebAssembly;

public class BlogPost
{
    public string Title { get; set; } = "";
    public string[] Tags { get; set; } = [];
    public DateTime Posted { get; set; }
    public string Text { get; set; } = "";
}
