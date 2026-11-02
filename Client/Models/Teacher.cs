using System.Collections.Generic;

namespace Client.Models;

public record class Teacher : Person
{
    public required string Field { get; set; }

    public required List<Course> Courses { get; set; } = [];
}
