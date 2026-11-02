namespace Client.Models;

public record class TeacherRestDb : Teacher
{
    public string _id { get; set; } = string.Empty;
}
