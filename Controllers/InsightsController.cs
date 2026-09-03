using AbujalWebsite.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbujalWebsite.Controllers;

public class InsightsController : Controller
{
    private readonly ISiteDataService _data;

    public InsightsController(ISiteDataService data)
    {
        _data = data;
    }

    public IActionResult Index()
    {
        return View(_data.GetInsights());
    }

    public IActionResult Details(string slug)
    {
        var insight = _data.GetInsightBySlug(slug);
        if (insight is null) return NotFound();
        return View(insight);
    }
}
