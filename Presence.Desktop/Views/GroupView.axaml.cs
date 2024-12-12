using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Presence.Desktop.ViewModels;
using ReactiveUI;

namespace Presence.Desktop.Views;

public partial class GroupView : ReactiveUserControl<GroupViewModel>
{
    public GroupView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }

    private void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
    }
}