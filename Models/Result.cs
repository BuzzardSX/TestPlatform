using System;

namespace TestPlatform.Models;

public class Result
{
	public Guid Id { get; set; }

	public string Test { get; set; }

	public string UserEmail { get; set; }

	public User User { get; set; }

	public int Score { get; set; }

	public int TotalScore { get; set; }

	public DateTime FinishedDate { get; set; }
}