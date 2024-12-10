using Attendance.Desktop.ViewModels;
using Attendance.Desktop.Views;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using ReactiveUI;
using System;

namespace Attendance.Desktop
{
    public class ViewLocator : IViewLocator
    {
        public IViewFor? ResolveView<T>(T? viewModel, string? contract = null) => viewModel switch
        {
            GroupViewModel groupViewModel => new GroupView { DataContext = groupViewModel },       
            _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
        };
    }
}
