using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddTeacherViewModel : ViewModelBase
{
    private readonly ITeacherService _teacherService;

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

    public AddTeacherViewModel(ITeacherService teacherService)
    {
        _teacherService = teacherService;
        PageTitle = "Ny lärare";
    }

    [RelayCommand]
    private async Task Save()
    {
        // Behöver eventuellt göra validering här...
        Teacher teacher = new()
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber,
            Address = Address,
            PostalCode = PostalCode,
            City = City,
            Field = Field,
            Courses = [],
        };

        await _teacherService.Add(teacher);

        ClearData();
    }

    private void ClearData() { }
}
