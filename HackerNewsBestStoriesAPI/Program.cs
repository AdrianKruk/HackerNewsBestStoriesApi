using Microsoft.Extensions.Caching.Memory;
using HackerNewsBestStoriesAPI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient(); 
builder.Services.AddMemoryCache();
var app = builder.Build();

app.MapGet("/best-stories/{count:int}", async (int count, IHttpClientFactory httpClientFactory, IMemoryCache cache) =>
{
    const string bestStoriesUrl = "https://hacker-news.firebaseio.com/v0/beststories.json";
    var client = httpClientFactory.CreateClient();

    // Caching: Store story IDs for 5 minutes to prevent excessive API calls
    var storyIds = await cache.GetOrCreateAsync("bestStories", async entry =>
    {
        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
        return await client.GetFromJsonAsync<List<int>>(bestStoriesUrl) ?? new List<int>();
    });

    if (storyIds == null || storyIds.Count == 0)
        return Results.NotFound("No best stories found.");

    // Limit count to prevent abuse
    count = Math.Clamp(count, 1, 100);

    var tasks = storyIds.Take(count).Select(async id =>
    {
        string storyUrl = $"https://hacker-news.firebaseio.com/v0/item/{id}.json";
        return await cache.GetOrCreateAsync($"story_{id}", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
            return await client.GetFromJsonAsync<HackerNewsStory>(storyUrl);
        });
    });

    var stories = (await Task.WhenAll(tasks)).Where(s => s != null).OrderByDescending(s => s.Score).ToList();
    return Results.Ok(stories);
});

app.Run();