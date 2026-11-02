using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
    private readonly IStudentService _studentService;

    [ObservableProperty]
    public partial ObservableCollection<Student> Students { get; set; } = [];

    public StudentsViewModel()
    {
        _studentService = new StudentServices();
        PageTitle = "Studentlista";
        Init();
    }

    public StudentsViewModel(IStudentService studentService)
    {
        _studentService = studentService;
        PageTitle = "Studentista";
        Init();
    }

    private async void Init()
    {
        await LoadStudents();
    }

    private async Task LoadStudents()
    {
        try
        {
            var students = await _studentService.List();
            Students = new ObservableCollection<Student>(students);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
