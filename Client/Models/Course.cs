using System;
using System.Collections.Generic;
using Client.Enums;

namespace Client.Models;

public record class Course
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string CourseNumber { get; set; }
    public required string Title { get; set; }
    public CourseType CourseType { get; set; }
    public int WeekAmount { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public List<Student> Students { get; set; } = [];
}
