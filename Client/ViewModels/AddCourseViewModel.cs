using System;
using System.Threading.Tasks;
using Client.Enums;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddCourseViewModel : ViewModelBase
{
    private readonly ICourseService _courseService;

    [ObservableProperty]
    public partial string CourseNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Title { get; set; } = string.Empty;

    [ObservableProperty]
    public partial CourseType CourseType { get; set; }

    [ObservableProperty]
    public partial int WeekAmount { get; set; }

    [ObservableProperty]
    public partial DateTime? StartDate { get; set; }

    [ObservableProperty]
    public partial DateTime? EndDate { get; set; }

    public CourseType[] CourseTypes { get; } = Enum.GetValues<CourseType>();

    public AddCourseViewModel(ICourseService courseService)
    {
        _courseService = courseService;
        PageTitle = "Ny kurs";
    }

    [RelayCommand]
    private async Task Save()
    {
        Course course = new()
        {
            CourseNumber = CourseNumber,
            Title = Title,
            CourseType = CourseType,
            WeekAmount = WeekAmount,
            StartDate = DateOnly.FromDateTime(StartDate!.Value),
            EndDate = DateOnly.FromDateTime(EndDate!.Value),
        };

        await _courseService.Add(course);

        ClearData();
    }

    private void ClearData()
    {
        CourseNumber = string.Empty;
        Title = string.Empty;
        CourseType = default;
        WeekAmount = 0;
        StartDate = default;
        EndDate = default;
    }
}
