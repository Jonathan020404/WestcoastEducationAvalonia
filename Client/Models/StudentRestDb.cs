namespace Client.Models;

public record class StudentRestDb : Student
{
    public string _id { get; set; } = string.Empty;
}
