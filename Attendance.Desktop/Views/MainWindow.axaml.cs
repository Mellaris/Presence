using Attendance.Desktop.ViewModels;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace Attendance.Desktop.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);

    }
}