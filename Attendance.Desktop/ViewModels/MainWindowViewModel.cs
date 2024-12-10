using Attendance.Desktop.ViewModels;
using Domain.UseCase;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System;

namespace Attendance.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    public RoutingState Router { get; } = new RoutingState();

    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        var groupViewModel = serviceProvider.GetRequiredService<GroupViewModel>();
        Router.Navigate.Execute(groupViewModel);
    }
}
