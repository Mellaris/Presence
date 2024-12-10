using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Avalonia.ReactiveUI;
using Attendance.Desktop.ViewModels;
using ReactiveUI;
using Avalonia.Diagnostics;
using System;


namespace Attendance.Desktop.Views
{
    public partial class GroupView : ReactiveUserControl<GroupViewModel>
    {
        private readonly TopLevel _parentTopLevel;
        public GroupView(TopLevel parentTopLevel)
        {
            _parentTopLevel = parentTopLevel;
            this.WhenActivated(action =>
            {
                action(ViewModel!.SelectFileInteraction.RegisterHandler(ShowFileDialog));
            });
            AvaloniaXamlLoader.Load(this);
           
        }

        private async Task ShowFileDialog(IInteractionContext<string?, string?> context)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if(topLevel == null)
            {
                throw new InvalidOperationException("ошибка");
            }
            var storageFile = await topLevel.StorageProvider.OpenFilePickerAsync(
                new FilePickerOpenOptions()
                {
                    AllowMultiple = false,
                    Title = context.Input
                }
            );
            if( storageFile.Count > 0 )
            {
                context.SetOutput(storageFile.First().Path.ToString());
            }
            else
            {
                context.SetOutput(null);
            }
        }
    }
}