using Microsoft.AspNetCore.Mvc;

namespace TestPlatform.Controllers;

public class HomeController : Controller
{
	public IActionResult Host() => View();
}
