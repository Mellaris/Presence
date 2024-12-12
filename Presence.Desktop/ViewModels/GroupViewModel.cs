using Avalonia.Controls;
using Avalonia.Controls.Selection;
using Domain.UseCase;
using Presence.Desktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presence.Desktop.ViewModels
{
    public class GroupViewModel : ViewModelBase, IRoutableViewModel
    {
        public string? UrlPathSegment => throw new NotImplementedException();

        public IScreen HostScreen => throw new NotImplementedException();

        private readonly IGroupUseCase _groupService;
        private readonly IStudentsUseCase _studentsService;
        private List<GroupPresenter> _groupPresentersDataSource = new List<GroupPresenter>();


        private ObservableCollection<GroupPresenter> _groups;
        public ObservableCollection<GroupPresenter> Groups => _groups;



        private GroupPresenter? _selectedGroupItem;
        public GroupPresenter? SelectedGroupItem
        {
            get => _selectedGroupItem;
            set => this.RaiseAndSetIfChanged(ref _selectedGroupItem, value);
        }



        private ObservableCollection<StudentPresenter> _students;
        public ObservableCollection<StudentPresenter> Students { get => _students; }




        private int _sort;
        public int Sort { get => _sort; set => this.RaiseAndSetIfChanged(ref _sort, value); }


        private bool _MultipleSelected = false;
        public bool MultipleSelected { get => _MultipleSelected; set => this.RaiseAndSetIfChanged(ref _MultipleSelected, value); }
        public SelectionModel<StudentPresenter> Selection { get; }

        private StudentPresenter? _selectedStudent;

        public ICommand RemoveSelectedCommand { get; }
        public ICommand Import { get; }

        public GroupViewModel(IGroupUseCase groupUseCase, IStudentsUseCase studentsService)
        {
            _groupService = groupUseCase;
            _studentsService = studentsService;
            foreach (var item in _groupService.GetGroupsWithStudents())
            {
                GroupPresenter groupPresenter = new GroupPresenter
                {
                    Id = item.Id,
                    Name = item.Name,
                    users = item.Students?.Select(user => new StudentPresenter
                    {
                        IdStudent = user.Guid,
                        Name = user.Name,
                        Group = new GroupPresenter
                        {
                            Id = item.Id,
                            Name = item.Name
                        }
                    }
                    ).ToList()
                };
                _groupPresentersDataSource.Add(groupPresenter);
            }
            _groups = new ObservableCollection<GroupPresenter>(_groupPresentersDataSource);

            _students = new ObservableCollection<StudentPresenter>();

            _sort = 0;
            Selection = new SelectionModel<StudentPresenter>();
            Selection.SingleSelect = false;
            Selection.SelectionChanged += SelectionChanged;
            RemoveSelectedCommand = ReactiveCommand.Create(RemoveSelected);
            Import = ReactiveCommand.Create(RemoveInGroup);
            this.WhenAnyValue(vm => vm.SelectedGroupItem).Subscribe(_ => { RefreshGroups(); SetUsers(); });
            this.WhenAnyValue(vm => vm.Sort).Subscribe(_ => { RefreshGroups(); SetUsers(); });

        }
        //private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if(e.AddedItems.Count > 0)
        //    {
        //        _selectedStudent = e.AddedItems[0] as StudentPresenter;
        //    }
        //}
        public GroupViewModel()
        {

        }
        private void SetUsers()
        {
            if (SelectedGroupItem == null) return;
            if (SelectedGroupItem.users == null) return;
            Students.Clear();
            List<StudentPresenter> users = _groupPresentersDataSource.FirstOrDefault(p => p.Id == SelectedGroupItem.Id).users.ToList();
            if (Sort == 1)
                users = users.OrderBy(user => user.Name).ToList();
            else if (Sort == 2)
                users = users.OrderByDescending(user => user.Name).ToList();
            foreach (var user in users)
            {
                Students.Add(user);
            }
        }

        void SelectionChanged(object sender, SelectionModelSelectionChangedEventArgs e)
        {
            MultipleSelected = Selection.SelectedItems.Count > 1;
           
        }

        private void RemoveSelected()
        {
            List<StudentPresenter> users = _groupPresentersDataSource.FirstOrDefault(p => p.Id == SelectedGroupItem.Id).users.ToList();
            foreach (var user in users)
            {
                _studentsService.RemoveStudents(new Domain.Request.RemoveStudentsRequest { idS = user.IdStudent });
                Students.Remove(user);

            }
            RefreshGroups();
            //_studentsService.RemoveStudents(new Domain.Request.RemoveStudentsRequest { idS = _selectedStudent.IdStudent });
            //Students.Remove(_selectedStudent);
            //RefreshGroups();
        }


        public void RemoveInGroup()
        {
            List<StudentPresenter> users = _groupPresentersDataSource.FirstOrDefault(p => p.Id == SelectedGroupItem.Id).users.ToList();
            if (users.Count != 0)
            {
                foreach (var user in users)
                {
                    _studentsService.RemoveStudents(new Domain.Request.RemoveStudentsRequest { idS = user.IdStudent });
                    Students.Remove(user);

                }
            }
            RefreshGroups();
        }

        private void RefreshGroups()
        {
            _groupPresentersDataSource.Clear();
            foreach (var item in _groupService.GetGroupsWithStudents())
            {
                GroupPresenter groupPresenter = new GroupPresenter
                {
                    Id = item.Id,
                    Name = item.Name,
                    users = item.Students?.Select(user => new StudentPresenter
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
    }
}
