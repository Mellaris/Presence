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
    }
}
