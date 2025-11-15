using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
