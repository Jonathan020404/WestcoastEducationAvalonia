using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Interfaces;

public interface ITeacherService
{
    Task Add(Teacher teacher);
    Task Delete(string id);
    Task<TeacherRestDb> Find(string itemNumber);
    Task<List<Teacher>> List();
    Task Update(Teacher teacher, string _objectId);
}
