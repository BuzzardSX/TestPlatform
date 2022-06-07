namespace TestPlatform.Models;

public enum UserRole
{
	Admin,

	User
}

public class User
{
	public string Email { get; set; }

	public string Password { get; set; }

	public string Name { get; set; }

	public string Surname { get; set; }

	public UserRole Role { get; set; }
}
