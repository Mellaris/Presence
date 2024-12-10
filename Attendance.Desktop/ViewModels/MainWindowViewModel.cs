using Domain.UseCase;

namespace Attendance.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IGroupUseCase _groupService;
        public MainWindowViewModel(IGroupUseCase groupUseCase)
        {
            _groupService = groupUseCase;
        }
        public string Greeting { get; } = "Welcome to Avalonia!";
    }
}
