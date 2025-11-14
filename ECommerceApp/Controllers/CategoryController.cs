using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers;

public class CategoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
