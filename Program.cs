using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TestPlatform;

public class Program
{
	public static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;
		CreateHostBuilder(args).Build().Run();
	}
	public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
		.ConfigureWebHostDefaults(builder =>
		{
			builder.UseStartup<Startup>();
		});
}
