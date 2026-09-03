using Microsoft.AspNetCore.Mvc;

namespace AbujalWebsite.Controllers;

public class AboutController : Controller
{
    public IActionResult Index() => View();
}
