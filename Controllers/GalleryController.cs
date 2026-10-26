using Microsoft.AspNetCore.Mvc;

namespace AbujalWebsite.Controllers;

public class GalleryController : Controller
{
    private static readonly HashSet<string> ImageExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".jpg", ".jpeg", ".png", ".gif", ".webp"
    };

    private readonly IWebHostEnvironment _environment;

    public GalleryController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public IActionResult Index()
    {
        var galleryDirectory = Path.Combine(_environment.WebRootPath, "images", "gallery");
        var images = Directory.Exists(galleryDirectory)
            ? Directory.EnumerateFiles(galleryDirectory)
                .Where(filePath => ImageExtensions.Contains(Path.GetExtension(filePath)))
                .Select(Path.GetFileName)
                .OfType<string>()
                .OrderBy(fileName => fileName, StringComparer.OrdinalIgnoreCase)
                .Select(fileName =>
                {
                    var caption = Path.GetFileNameWithoutExtension(fileName)
                        .Replace("-", " ")
                        .Replace("_", " ");
                    caption = System.Text.RegularExpressions.Regex.Replace(caption, @"^\d+[\s._-]*", "").Trim();

                    return new GalleryImage(
                        $"/images/gallery/{Uri.EscapeDataString(fileName)}",
                        string.IsNullOrWhiteSpace(caption) ? null : caption);
                })
                .ToList()
            : new List<GalleryImage>();

        return View(images);
    }
}

public record GalleryImage(string ImageUrl, string? Caption);
