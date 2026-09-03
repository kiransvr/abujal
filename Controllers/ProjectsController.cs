using AbujalWebsite.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbujalWebsite.Controllers;

public class ProjectsController : Controller
{
    private readonly ISiteDataService _data;

    public ProjectsController(ISiteDataService data)
    {
        _data = data;
    }

    public IActionResult Index(string? category)
    {
        var projects = _data.GetProjects().AsEnumerable();
        if (!string.IsNullOrWhiteSpace(category))
        {
            projects = projects.Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        ViewBag.SelectedCategory = category;
        ViewBag.Categories = _data.GetProjects().Select(p => p.Category).Distinct().OrderBy(c => c).ToList();
        return View(projects.ToList());
    }

    public IActionResult Details(string slug)
    {
        var project = _data.GetProjectBySlug(slug);
        if (project is null) return NotFound();
        return View(project);
    }
}
