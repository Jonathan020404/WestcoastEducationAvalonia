using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
    private readonly ICourseService? _courseService;

    [ObservableProperty]
    public partial ObservableCollection<Course> Courses { get; set; } = [];

    private readonly MainWindowViewModel _mainWindowViewModel;

    public string DeleteId { get; set; }

    public CoursesViewModel(ICourseService courseService, MainWindowViewModel mainWindowViewModel)
    {
        _courseService = courseService;
        _mainWindowViewModel = mainWindowViewModel;
        PageTitle = "Våra kurser";
        DeleteId = "";

        Init();
    }

    [RelayCommand]
    private async Task Delete(string id)
    {
        try
        {
            DeleteId = id;
            CourseRestDb course = await _courseService!.Find(DeleteId);
            if (course is not null)
            {
                await _courseService.Delete(course._id);
                await LoadCourses();
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    private async void Init()
    {
        await LoadCourses();
    }

    private async Task LoadCourses()
    {
        try
        {
            Courses = new ObservableCollection<Course>(await _courseService!.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
