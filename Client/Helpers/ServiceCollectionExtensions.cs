using System;
using Client.Enums;
using Client.Factories;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddSingleton<PageViewFactory>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<CoursesViewModel>();
        collection.AddTransient<StudentsViewModel>();
        collection.AddTransient<TeachersViewModel>();
        collection.AddTransient<AddCourseViewModel>();
        collection.AddTransient<AddStudentViewModel>();
        collection.AddTransient<AddTeacherViewModel>();
        collection.AddTransient<EditCourseViewModel>();
        collection.AddTransient<EditTeacherViewModel>();
        collection.AddTransient<ICourseService, CourseServices>();
        collection.AddTransient<IStudentService, StudentServices>();
        collection.AddTransient<ITeacherService, TeacherServices>();

        collection.AddSingleton<Func<PageViewsEnum, ViewModelBase>>(c =>
            name =>
                name switch
                {
                    PageViewsEnum.Home => c.GetRequiredService<HomeViewModel>(),
                    PageViewsEnum.AddCourse => c.GetRequiredService<AddCourseViewModel>(),
                    PageViewsEnum.AddStudent => c.GetRequiredService<AddStudentViewModel>(),
                    PageViewsEnum.AddTeacher => c.GetRequiredService<AddTeacherViewModel>(),
                    PageViewsEnum.EditCourse => c.GetRequiredService<EditCourseViewModel>(),
                    PageViewsEnum.EditTeacher => c.GetRequiredService<EditTeacherViewModel>(),
                    PageViewsEnum.Courses => c.GetRequiredService<CoursesViewModel>(),
                    PageViewsEnum.Students => c.GetRequiredService<StudentsViewModel>(),
                    PageViewsEnum.Teachers => c.GetRequiredService<TeachersViewModel>(),

                    _ => throw new InvalidOperationException(),
                }
        );
    }
}
