using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestPlatform.Models;

namespace TestPlatform;

public class Startup
{
	private readonly IConfiguration _config;

	public Startup(IConfiguration config) => _config = config;

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddDbContextFactory<ApplicationContext>(options =>
		{
			options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
		});
		services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddCookie(options =>
			{
				options.LoginPath = new PathString("/login");
			});
		services.AddMvc();
		services.AddServerSideBlazor();
	}

	public void Configure(IApplicationBuilder app)
	{
		app.UseStaticFiles();
		app.UseRouting();
		app.UseAuthentication();
		app.UseAuthorization();
		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllerRoute("login", "/login", new { controller = "Account", action = "Login" });
			endpoints.MapControllerRoute("logout", "/logout", new { controller = "Account", action = "Logout" });
			endpoints.MapBlazorHub();
			endpoints.MapFallbackToController("Host", "Home");
		});
	}
}
