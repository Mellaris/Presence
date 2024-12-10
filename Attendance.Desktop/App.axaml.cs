using Attendance.Desktop.DI;
using Attendance.Desktop.ViewModels;
using Attendance.Desktop.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace Attendance.Desktop
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
      

        public override void OnFrameworkInitializationCompleted()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCommonService();
            var services = serviceCollection.BuildServiceProvider();
            var mainViewModel = services.GetRequiredService<MainWindowViewModel>();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = mainViewModel,
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

    }
}