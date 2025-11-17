namespace Eliterate.WebAssembly.Components
{
    public partial class Post(string title, string text)
    {
        public string Title { get; set; } = title;
        public string Text { get; set; } = text;
    }
}
