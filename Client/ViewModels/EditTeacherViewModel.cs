using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using Client.Helpers;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class EditTeacherViewModel : ViewModelBase
{
    private readonly ITeacherService? _teacherService;
    private string _itemNumber = string.Empty;
    private string _objectId = string.Empty;
    private string _teacherId = string.Empty;
    private List<Course> _courses = [];

    [ObservableProperty]
    public partial string FirstName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string LastName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Email { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string? PhoneNumber { get; set; }

    [ObservableProperty]
    public partial string? Address { get; set; }

    [ObservableProperty]
    public partial string? PostalCode { get; set; }

    [ObservableProperty]
    public partial string? City { get; set; }

    [ObservableProperty]
    public partial string Field { get; set; } = string.Empty;

    public EditTeacherViewModel(ITeacherService teacherService)
    {
        _teacherService = teacherService;
        PageTitle = "Uppdatera lärare: ";
    }

    public async void Init(string id)
    {
        _itemNumber = id;
        await GetTeacher();
    }

    private async Task GetTeacher()
    {
        var teacher = await _teacherService!.Find(_itemNumber);

        _objectId = teacher._id;
        _teacherId = teacher.Id;
        _courses = teacher.Courses;

        FirstName = teacher.FirstName;
        LastName = teacher.LastName;
        Email = teacher.Email;
        PhoneNumber = teacher.PhoneNumber;
        Address = teacher.Address;
        PostalCode = teacher.PostalCode;
        City = teacher.City;
        Field = teacher.Field;
    }

    [RelayCommand]
    private async Task Save()
    {
        Teacher teacher = new()
        {
            Id = _teacherId,
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber,
            Address = Address,
            PostalCode = PostalCode,
            City = City,
            Field = Field,
            Courses = _courses,
        };

        await _teacherService!.Update(teacher, _objectId);
    }
}
