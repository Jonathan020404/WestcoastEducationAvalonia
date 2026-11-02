using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;

namespace Client.Services;

public class TeacherServices : ITeacherService
{
    public async Task Add(Teacher teacher)
    {
        var httpService = new HttpService<Teacher>();
        await httpService.Post("teachers", teacher);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Teacher>();
        await httpService.Delete("teachers", id);
    }

    public async Task<TeacherRestDb> Find(string id)
    {
        var httpService = new HttpService<TeacherRestDb>();
        var searchCriteria = "{\"id\":\"" + id + "\"}";

        return await httpService.Get("teachers", searchCriteria);
    }

    public async Task<List<Teacher>> List()
    {
        var httpService = new HttpService<Teacher>();
        var teachers = await httpService.Get("teachers");
        return teachers;
    }

    public async Task Update(Teacher teacher, string _objectId)
    {
        var httpService = new HttpService<Teacher>();
        await httpService.Put("teachers", teacher, _objectId);
    }
}
