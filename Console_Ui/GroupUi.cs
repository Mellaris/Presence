using Domain.Request;
using Domain.Service;
using Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Console_Ui
{
    class GroupUi
    {
        private readonly IGroupUseCase _groupService;
        public GroupUi(IGroupUseCase groupService)
        {
            _groupService = groupService;
        }

        public void AddGroup()
        {
            Console.WriteLine("Введите имя группы");
            _groupService.AddGroupes(new AddGroupRequest { Name = Console.ReadLine() });
        }
        public void UpdateGroup()
        {
            Console.WriteLine("Введите id группы для обновления");
            int idHelp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите название группы для обновления");
            string name = Console.ReadLine();
            _groupService.UpdateGroupes(idHelp ,new UpdateGroupRequest { Id = idHelp, Name = name }) ;
        }
        public void RemoveGroup()
        {
            Console.WriteLine("Введите id группы для удаления");
            _groupService.RemoveGroupes(new RemoveGroupRequest { Id = Convert.ToInt32(Console.ReadLine()) });
        }
        public void AddGroupWithStudent()
        {
            Console.WriteLine("Введите имя группы");
            AddGroupRequest addGroupRequest = new AddGroupRequest { Name = Console.ReadLine() };
            List<AddStudentRequest> addStudentRequests = new List<AddStudentRequest>() { 
                new AddStudentRequest{StudentName = "123"},
                new AddStudentRequest{StudentName = "312"},
                new AddStudentRequest{StudentName = "222"},
                new AddStudentRequest{StudentName = "444"},
            };
            AddGroupWithStudentRequest addGroupWithStudentRequest = new AddGroupWithStudentRequest { addGroupRequest = addGroupRequest,
                AddStudentRequest = addStudentRequests
            };
            _groupService.AddGroupWithStudents(addGroupWithStudentRequest);
        }
    }
}
