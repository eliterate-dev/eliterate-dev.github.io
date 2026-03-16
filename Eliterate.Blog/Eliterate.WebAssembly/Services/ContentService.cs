using Codespirals.Base.Extensions;
using System.Net.Http.Json;

namespace Eliterate.WebAssembly;

public interface IContentService
{
    Task<IEnumerable<PostMetadata>> GetMetadata();
    Task<IEnumerable<PostMetadata>> GetMetadataByTag(string tag);
    Task<BlogPost?> GetPost(string title);
}

public class ContentService(HttpClient client) : IContentService
{
    private readonly HttpClient _client = client;

    public async Task<IEnumerable<PostMetadata>> GetMetadata()
    {
        var metadata = await _client.GetFromJsonAsync<IEnumerable<PostMetadata>>($"post_metadata/posts.json");
        if (metadata is null)
            return [];
        var posts = new List<PostMetadata>();
        foreach (var item in metadata)
        {
            if (item is null || !item.IsActive || !item.ShowInList)
                continue;
            posts.Add(item);
        }
        return [.. posts.OrderByDescending(p => p.Edited is null ? p.Created : p.Edited)];
    }

    public async Task<IEnumerable<PostMetadata>> GetMetadataByTag(string tagId)
    {
        var metadata = await _client.GetFromJsonAsync<IEnumerable<PostMetadata>>($"post_metadata/posts.json");
        if (metadata is null)
            return [];
        var posts = new List<PostMetadata>();
        foreach (var item in metadata)
        {
            if (item is null || !item.IsActive || !item.Tags.Any(t => t.ToUrlSafeString() == tagId))
                continue;
            posts.Add(item);
        }
        return [.. posts.OrderByDescending(p => p.Edited is null ? p.Created : p.Edited)];
    }

    public async Task<BlogPost?> GetPost(string title)
    {
        var metadata = await _client.GetFromJsonAsync<IEnumerable<PostMetadata>>($"post_metadata/posts.json");
        if (metadata is null)
            return null;
        foreach (var item in metadata)
        {
            if (item is null || !item.IsActive || item.Id != title)
                continue;
            var markdown = await _client.GetStringAsync(item.ContentUrl);
            if (markdown is null)
                continue;
            return new BlogPost { Metadata = item, Text = Markdig.Markdown.ToHtml(markdown) };
        }
        return null;
    }
}
