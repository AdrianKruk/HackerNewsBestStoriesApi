namespace HackerNewsBestStoriesAPI;

public record HackerNewsStory(string Title, string Url, string By, long Time, int Score, int Descendants)
{
    public string Uri => this.Url;
    public string PostedBy => this.By;
    public string TimeFormatted => DateTimeOffset.FromUnixTimeSeconds(this.Time).ToString("yyyy-MM-ddTHH:mm:sszzz");
    public int CommentCount => this.Descendants;
}