using System;
using System.Collections.Generic;

namespace TestPlatform.Models;

public class Question
{
	public Guid Id { get; set; }

	public Guid TestId { get; set; }

	public string Text { get; set; }

	public int Number { get; set; }

	public ICollection<QuestionOption> Options { get; set; }
}
