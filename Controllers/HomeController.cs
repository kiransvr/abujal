using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AbujalWebsite.Models;
using AbujalWebsite.Services;
using Microsoft.AspNetCore.Hosting;

namespace AbujalWebsite.Controllers;

public class HomeController : Controller
{
    private readonly ISiteDataService _data;
    private readonly IWebHostEnvironment _environment;

    private static readonly HashSet<string> ClientLogoExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".png", ".jpg", ".jpeg", ".svg", ".webp"
    };

    private static readonly HashSet<string> HeroImageExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".png", ".jpg", ".jpeg", ".webp"
    };

    public HomeController(ISiteDataService data, IWebHostEnvironment environment)
    {
        _data = data;
        _environment = environment;
    }

    public IActionResult Index()
    {
        ViewBag.Services = _data.GetServices();
        ViewBag.FeaturedProjects = _data.GetProjects().Take(3).ToList();

        var heroImageDirectory = Path.Combine(_environment.WebRootPath, "images", "hero-carousel");
        var additionalHeroImages = Directory.Exists(heroImageDirectory)
            ? Directory.EnumerateFiles(heroImageDirectory)
                .Where(filePath => HeroImageExtensions.Contains(Path.GetExtension(filePath)))
                .Select(Path.GetFileName)
                .OfType<string>()
                .OrderBy(fileName => fileName, StringComparer.OrdinalIgnoreCase)
                .Select(fileName => $"/images/hero-carousel/{Uri.EscapeDataString(fileName)}")
            : Enumerable.Empty<string>();
        ViewBag.HeroImages = new[] { "/images/hero.png" }.Concat(additionalHeroImages).ToList();

        const string corporateProfileFileName = "abujal-corporate-profile.pdf";
        var corporateProfilePath = Path.Combine(_environment.WebRootPath, "documents", corporateProfileFileName);
        ViewBag.CorporateProfileUrl = System.IO.File.Exists(corporateProfilePath)
            ? $"/documents/{corporateProfileFileName}"
            : null;

        var clientLogoDirectory = Path.Combine(_environment.WebRootPath, "images", "clients");
        ViewBag.ClientLogos = Directory.Exists(clientLogoDirectory)
            ? Directory.EnumerateFiles(clientLogoDirectory)
                .Where(filePath => ClientLogoExtensions.Contains(Path.GetExtension(filePath)))
                .Select(Path.GetFileName)
                .OfType<string>()
                .OrderBy(fileName => fileName, StringComparer.OrdinalIgnoreCase)
                .ToList()
            : new List<string>();

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
