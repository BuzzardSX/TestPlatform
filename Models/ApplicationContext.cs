using Microsoft.EntityFrameworkCore;

namespace TestPlatform.Models;

public class ApplicationContext : DbContext
{
	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

	public DbSet<User> Users { get; set; }

	public DbSet<Test> Tests { get; set; }

	public DbSet<Question> Questions { get; set; }

	public DbSet<QuestionOption> QuestionOptions { get; set; }

	public DbSet<Result> Results { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>(entity =>
		{
			entity.HasKey(u => u.Email);
		});

		modelBuilder.Entity<Result>(entity =>
		{
			entity.HasOne(r => r.User);
		});
	}
}
