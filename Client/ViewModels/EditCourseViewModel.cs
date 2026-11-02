using System;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using Client.Enums;
using Client.Helpers;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class EditCourseViewModel : ViewModelBase
{
    private readonly ICourseService _courseService;
    private string _courseNumber = string.Empty;
    private string _objectId = string.Empty;
    private string _courseId = string.Empty;

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

    public EditCourseViewModel(ICourseService courseService)
    {
        _courseService = courseService;
        PageTitle = "Uppdatera kurs: ";
    }

    public async Task Init(string courseNumber)
    {
        _courseNumber = courseNumber;
        await GetCourse();
    }

    private async Task GetCourse()
    {
        var course = await _courseService.Find(_courseNumber);

        _objectId = course._id;
        _courseId = course.Id;

        CourseNumber = course.CourseNumber;
        Title = course.Title;
        CourseType = course.CourseType;
        WeekAmount = course.WeekAmount;
        StartDate = course.StartDate.ToDateTime(TimeOnly.MinValue);
        EndDate = course.EndDate.ToDateTime(TimeOnly.MinValue);
    }

    [RelayCommand]
    private async Task Save()
    {
        Course course = new()
        {
            Id = _courseId,
            CourseNumber = CourseNumber,
            Title = Title,
            CourseType = CourseType,
            WeekAmount = WeekAmount,
            StartDate = DateOnly.FromDateTime(StartDate!.Value),
            EndDate = DateOnly.FromDateTime(EndDate!.Value),
        };

        await _courseService!.Update(course, _objectId);
    }
}
