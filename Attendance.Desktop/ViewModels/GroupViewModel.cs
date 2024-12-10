using Attendance.Desktop.Models;
using Domain.UseCase;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Attendance.Desktop.ViewModels
{
    public class GroupViewModel : ViewModelBase, IRoutableViewModel
    {
        public ICommand OpenFileDialog { get; }
        public Interaction<string?, string?> SelectFileInteraction => _SelectFileInteraction;
        public readonly Interaction<string?, string?> _SelectFileInteraction;
        private string? _selectedFile;
        public string? SelectedFile
        {
            get => _selectedFile;
            set => this.RaiseAndSetIfChanged(ref _selectedFile, value);
        }
        private readonly List<GroupPresenter> _groupPresentersDataSource = new List<GroupPresenter>();
        private ObservableCollection<GroupPresenter> _groups;
        public ObservableCollection<GroupPresenter> Groups => _groups;
        public GroupPresenter? SelectedGroupItem
        {
            get => _selectedGroupItem;
            set => this.RaiseAndSetIfChanged(ref _selectedGroupItem, value);
        }

        private GroupPresenter? _selectedGroupItem;
        private IGroupUseCase _groupUseCase;
        public ObservableCollection<StudentPresenter> Students { get => _students; }
        public ObservableCollection<StudentPresenter> _students;
        public GroupViewModel(IGroupUseCase groupUseCase)
        {
            _groupUseCase = groupUseCase;
            _SelectFileInteraction = new Interaction<string?, string?>();
            OpenFileDialog = ReactiveCommand.CreateFromTask(SelectFile);
            _students = new ObservableCollection<StudentPresenter>();
            RefreshGroups();
            this.WhenAnyValue(vm => vm.SelectedGroupItem)
                .Subscribe(_ =>
                {
                    RefreshGroups();
                    SetUsers();
                });
        }
        private void SetUsers()
        {
            if (SelectedGroupItem == null) return;
            Students.Clear();
            var group = _groups.First(it => it.Id == SelectedGroupItem.Id);
            if (group.students == null) return;
            foreach (var item in group.students)
            {
                Students.Add(item);
            }
        }
        private void RefreshGroups()
        {
            _groupPresentersDataSource.Clear();
            foreach (var item in _groupUseCase.GetGroupsWithStudents())
            {
                GroupPresenter groupPresenter = new GroupPresenter
                {
                    Id = item.Id,
                    Name = item.Name,
                    students = item.Students?.Select(user => new StudentPresenter
                    {
                        Name = user.Name,
                        IdStudent = user.Guid,
                        Group = new GroupPresenter { Id = item.Id, Name = item.Name }
                    }
                    ).ToList()
                };
                _groupPresentersDataSource.Add(groupPresenter);
            }
            _groups = new ObservableCollection<GroupPresenter>(_groupPresentersDataSource);
        }
        private async Task SelectFile()
        {
            Console.WriteLine("clock");
            SelectedFile = await _SelectFileInteraction.Handle("Chose csv file");
        }
        public string? UrlPathSegment { get; }
        public IScreen HostScreen { get; }
    }
}
