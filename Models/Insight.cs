namespace AbujalWebsite.Models;

public class Insight
{
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // Report, Article, Publication
    public DateOnly PublishDate { get; set; }
    public string Summary { get; set; } = string.Empty;
    public string? DownloadUrl { get; set; }
}
