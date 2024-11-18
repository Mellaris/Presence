using Domain.Request;
using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Ui
{
    class GroupUi
    {
        private readonly GroupService _groupService;
        public GroupUi(GroupService groupService)
        {
            _groupService = groupService;
        }

        public void AddGroup()
        {
            Console.WriteLine("Введите имя группы");
            _groupService.AddGroupes(new AddGroupRequest { Name = Console.ReadLine() });
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
