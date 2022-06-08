using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestPlatform.Models;
using TestPlatform.ViewModels.AccountViewModels;

namespace TestPlatform.Controllers;

public class AccountController : Controller
{
	private readonly ILogger<AccountController> _logger;

	private readonly ApplicationContext _app;

	public AccountController(ILogger<AccountController> logger, ApplicationContext app)
	{
		_logger = logger;
		_app = app;
	}

	public IActionResult Login()
	{
		return View(new LoginViewModel());
	}

	[HttpPost]
	public async Task<IActionResult> Login(string email, string password, string returnUrl)
	{
		var user = _app.Users.FirstOrDefault(u => u.Email == email);
		if (user != null)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
			};
			var identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
			identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
			identity.AddClaim(new Claim(ClaimTypes.Surname, user.Surname));
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

			if (returnUrl == null)
			{
				return Redirect("/");
			}
			return Redirect(returnUrl);
		}

		return View(new LoginViewModel());
	}

	public async Task<IActionResult> Logout()
	{
		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

		return RedirectToRoute("login");
	}
}
