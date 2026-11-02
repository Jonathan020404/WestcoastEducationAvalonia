using System;
using Client.Factories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly PageViewFactory? _pageViewFactory;

    [ObservableProperty]
    public partial ViewModelBase CurrentView { get; set; } = new();

    public MainWindowViewModel(PageViewFactory pageViewFactory)
    {
        _pageViewFactory = pageViewFactory;
        GoToHome();
    }

    [RelayCommand]
    private void GoToHome() =>
        CurrentView = _pageViewFactory!.LoadPageViewModel(Enums.PageViewsEnum.Home);

    [RelayCommand]
    private void GoToCourses() =>
        CurrentView = _pageViewFactory!.LoadPageViewModel(Enums.PageViewsEnum.Courses);

    [RelayCommand]
    private void GoToStudents() =>
        CurrentView = _pageViewFactory!.LoadPageViewModel(Enums.PageViewsEnum.Students);

    [RelayCommand]
    private void GoToTeachers() =>
        CurrentView = _pageViewFactory!.LoadPageViewModel(Enums.PageViewsEnum.Teachers);

    [RelayCommand]
    private void GoToAddCourse() =>
        CurrentView = _pageViewFactory!.LoadPageViewModel(Enums.PageViewsEnum.AddCourse);

    [RelayCommand]
    private void GoToAddStudent() =>
        CurrentView = _pageViewFactory!.LoadPageViewModel(Enums.PageViewsEnum.AddStudent);

    [RelayCommand]
    private void GoToAddTeacher() =>
        CurrentView = _pageViewFactory!.LoadPageViewModel(Enums.PageViewsEnum.AddTeacher);

    [RelayCommand]
    private void GoToEditCourse(string itemNumber)
    {
        CurrentView = _pageViewFactory!.LoadPageViewModel(Enums.PageViewsEnum.EditCourse);
        ((EditCourseViewModel)CurrentView).Init(itemNumber);
    }

    [RelayCommand]
    private void GoToEditTeacher(string itemNumber)
    {
        CurrentView = _pageViewFactory!.LoadPageViewModel(Enums.PageViewsEnum.EditTeacher);
        ((EditTeacherViewModel)CurrentView).Init(itemNumber);
    }
}
