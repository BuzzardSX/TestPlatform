using System;

namespace TestPlatform.Models;

public class QuestionOption
{
	public Guid Id { get; set; }

	public Guid QuestionId { get; set; }

	public string Text { get; set; }

	public int Number { get; set; }

	public bool IsCorrect { get; set; }
}
