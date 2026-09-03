using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AbujalWebsite.Models;
using AbujalWebsite.Services;

namespace AbujalWebsite.Controllers;

public class HomeController : Controller
{
    private readonly ISiteDataService _data;

    public HomeController(ISiteDataService data)
    {
        _data = data;
    }

    public IActionResult Index()
    {
        ViewBag.Services = _data.GetServices();
        ViewBag.FeaturedProjects = _data.GetProjects().Take(3).ToList();
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
