using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.MVC.Models;

namespace CarWorkshop.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult NoAccess()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        var model= new List<Person>()
            {
            new Person()
            {
                FirstName = "Karol",
                LastName = "Kowalski"
            },
            new Person()
            {
                FirstName = "Kuba",
                LastName = "Kwaśny"
            },
        };
        return View(model);
    }
    public IActionResult About()
    {
        var model = new Specification()
            {
                Title= "CarWorkshop application",
                Description = "Some desription",
                Tags= new List<string>() {"car","app","free"}
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
