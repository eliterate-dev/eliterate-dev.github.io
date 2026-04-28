using System.Net.Http.Json;

namespace Eliterate.WebAssembly;

public interface IContentService
{
    Task<IEnumerable<PostMetadata>> GetMetadata();
    Task<IEnumerable<PostMetadata>> GetMetadataByTag(string tag);
    Task<BlogPost?> GetPost(string title);
    Task<BlogPost?> GetLatest();
    Task<int> GetPostCount();
    Task<SongQuote?> GetRandomSongQuote();
    Task<IEnumerable<LinkItem>> GetNavItems();
    Task<IEnumerable<LinkItem>> GetCredits();
    Task<IEnumerable<FutureIdea >> GetPlans();
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
        return [.. posts.OrderByDescending(p => p.Edited ?? p.Created)];
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
        return [.. posts.OrderByDescending(p => p.Edited ?? p.Created)];
    }

    public async Task<BlogPost?> GetPost(string title)
    {
        var metadata = await _client.GetFromJsonAsync<IEnumerable<PostMetadata>>($"post_metadata/metadata.json");
        var post = metadata?.FirstOrDefault(m => m.Id == title);
        if (post is null)
            return null;
        var markdown = await _client.GetStringAsync(post.ContentUrl);
        if (string.IsNullOrWhiteSpace(markdown))
            return null;
        return new BlogPost { Metadata = post, Text = Markdig.Markdown.ToHtml(markdown) };
    }
    public async  Task<BlogPost?> GetLatest()
    {
        var metadata = await _client.GetFromJsonAsync<IEnumerable<PostMetadata>>($"post_metadata/metadata.json");
        var post = metadata?.OrderByDescending(p => p.Created).FirstOrDefault();
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
    public async Task<SongQuote?> GetRandomSongQuote()
    {
        var songquotes = await _client.GetFromJsonAsync<IEnumerable<SongQuote>>($"resources/songquotes.json");
        var tagline = songquotes?.ElementAt(Random.Shared.Next(songquotes.Count()));
        return tagline;
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
    public async Task<IEnumerable<FutureIdea>> GetPlans()
    {
        var plans = await _client.GetFromJsonAsync<IEnumerable<FutureIdea>>($"resources/plans.json");
        if (plans is null)
            return [];
        return plans;
    }
}
