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

public partial class TeachersViewModel : ViewModelBase
{
    private readonly ITeacherService? _teacherService;

    [ObservableProperty]
    public partial ObservableCollection<Teacher> Teachers { get; set; } = [];
    private readonly MainWindowViewModel _mainWindowViewModel;

    public string DeleteId { get; set; }

    public TeachersViewModel(
        ITeacherService teacherService,
        MainWindowViewModel mainWindowViewModel
    )
    {
        _teacherService = teacherService;
        _mainWindowViewModel = mainWindowViewModel;
        PageTitle = "Våra lärare";
        DeleteId = "";

        Init();
    }

    [RelayCommand]
    private async Task Delete(string id)
    {
        try
        {
            DeleteId = id;
            TeacherRestDb teacher = await _teacherService!.Find(DeleteId);
            if (teacher is not null)
            {
                await _teacherService.Delete(teacher._id);
                await LoadTeachers();
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    private async void Init()
    {
        await LoadTeachers();
    }

    private async Task LoadTeachers()
    {
        try
        {
            Teachers = new ObservableCollection<Teacher>(await _teacherService!.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
