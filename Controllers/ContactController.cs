using AbujalWebsite.Models;
using AbujalWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AbujalWebsite.Controllers;

public class ContactController : Controller
{
    private readonly ISiteDataService _data;
    private readonly ILogger<ContactController> _logger;

    public ContactController(ISiteDataService data, ILogger<ContactController> logger)
    {
        _data = data;
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Services = _data.GetServices();
        return View(new ContactRequest());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(ContactRequest model)
    {
        ViewBag.Services = _data.GetServices();

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Persisting/emailing the submission is a follow-up integration; log for now.
        _logger.LogInformation("Consultation request received from {Email} for {Service}", model.Email, model.ServiceInterest);

        TempData["ContactSuccess"] = "Thank you! Your request has been received. Our team will contact you shortly.";
        return RedirectToAction(nameof(Index));
    }
}
