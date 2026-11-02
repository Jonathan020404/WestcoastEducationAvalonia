using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;

namespace Client.Services;

public class StudentServices : IStudentService
{
    public async Task Add(Student student)
    {
        var httpService = new HttpService<Student>();
        await httpService.Post("students", student);
    }

    public async Task<List<Student>> List()
    {
        HttpService<Student> httpService = new();
        var students = await httpService.Get("students");
        return students;
    }
}
