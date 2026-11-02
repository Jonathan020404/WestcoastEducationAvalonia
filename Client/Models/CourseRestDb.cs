namespace Client.Models;

public record class CourseRestDb : Course
{
    public string _id { get; set; } = string.Empty;
}
