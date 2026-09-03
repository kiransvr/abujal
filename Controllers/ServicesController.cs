using AbujalWebsite.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbujalWebsite.Controllers;

public class ServicesController : Controller
{
    private readonly ISiteDataService _data;

    public ServicesController(ISiteDataService data)
    {
        _data = data;
    }

    public IActionResult Index()
    {
        return View(_data.GetServices());
    }

    public IActionResult Details(string slug)
    {
        var service = _data.GetServiceBySlug(slug);
        if (service is null) return NotFound();
        ViewBag.OtherServices = _data.GetServices().Where(s => s.Slug != slug).ToList();
        return View(service);
    }
}
