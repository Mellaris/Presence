using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Presence.Desktop.ViewModels;
using Presence.Desktop.Views;
using ReactiveUI;
using System;

namespace Presence.Desktop
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
