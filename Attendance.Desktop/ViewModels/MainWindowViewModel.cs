using Domain.UseCase;
using ReactiveUI;
using System;

namespace Attendance.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IGroupUseCase _groupService;
        public MainWindowViewModel(IGroupUseCase groupUseCase)
        {
            _groupService = groupUseCase;
        }
        
    }
}
