using System.Net.Http.Json;

namespace Eliterate.WebAssembly;

public interface IContentService
{
    Task<IEnumerable<PostMetadata>> GetMetadata();
    Task<IEnumerable<PostMetadata>> GetMetadataByTag(string tag);
    Task<BlogPost?> GetPost(string title);
    Task<BlogPost?> GetLatest();
    Task<int> GetPostCount();
    Task<string> GetRandomTagline();
    Task<IEnumerable<LinkItem>> GetNavItems();
    Task<IEnumerable<LinkItem>> GetCredits();
}

public class ContentService(HttpClient client) : IContentService
{
    private readonly HttpClient _client = client;

    public async Task<IEnumerable<PostMetadata>> GetMetadata()
    {
        var metadata = await _client.GetFromJsonAsync<IEnumerable<PostMetadata>>($"post_metadata/metadata.json");
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
        var metadata = await _client.GetFromJsonAsync<IEnumerable<PostMetadata>>($"post_metadata/metadata.json");
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
        var metadata = await _client.GetFromJsonAsync<IEnumerable<PostMetadata>>($"post_metadata/metadata.json");
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
    public async  Task<BlogPost?> GetLatest()
    {
        var metadata = await _client.GetFromJsonAsync<IEnumerable<PostMetadata>>($"post_metadata/metadata.json");
        if (metadata is null)
            return null;
        var post = metadata.OrderByDescending(p => p.Edited is null ? p.Created : p.Edited).FirstOrDefault();
        if (post is null)
            return null;
        var markdown = await _client.GetStringAsync(post.ContentUrl);
        if (markdown is null)
            return null;
        return new BlogPost { Metadata = post, Text = Markdig.Markdown.ToHtml(markdown) };
    }
    public async Task<int> GetPostCount()
    {
        var metadata = await _client.GetFromJsonAsync<IEnumerable<PostMetadata>>($"post_metadata/metadata.json");
        if (metadata is null)
            return 0;
        return metadata.Count();
    }
    public async Task<string> GetRandomTagline()
    {
        var taglines = await _client.GetFromJsonAsync<IEnumerable<string>>($"resources/taglines.json");
        if (taglines is null)
            return "404 Tagline not found";
        return taglines.ElementAt(Random.Shared.Next(taglines.Count()));
    }
    public async Task<IEnumerable<LinkItem>> GetNavItems()
    {
        var navItems = await _client.GetFromJsonAsync<IEnumerable<LinkItem>>($"resources/navlinks.json");
        if (navItems is null)
            return [];
        return navItems;
    }
    public async Task<IEnumerable<LinkItem>> GetCredits()
    {
        var credits = await _client.GetFromJsonAsync<IEnumerable<LinkItem>>($"resources/credits.json");
        if (credits is null)
            return [];
        return credits;
    }
}
