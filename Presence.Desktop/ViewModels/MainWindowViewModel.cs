using Domain.UseCase;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DynamicData;
using DynamicData.Binding;
using System;
using System.Linq;
using System.Reactive.Linq;
using Tmds.DBus.Protocol;
using System.Globalization;
using Avalonia.Controls.Selection;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.Metrics;

namespace Presence.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IScreen
    {
        public RoutingState Router { get; } = new RoutingState();

        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            var groupViewModel = serviceProvider.GetRequiredService<GroupViewModel>();
            Router.Navigate.Execute(groupViewModel);
        }
    }
}
