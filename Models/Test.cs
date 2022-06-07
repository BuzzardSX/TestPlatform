using System;
using System.Collections.Generic;

namespace TestPlatform.Models;

public class Test
{
	public Guid Id { get; set; }

	public string Title { get; set; }

	public ICollection<Question> Questions { get; set; }
}
