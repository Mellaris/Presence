using Data.DAO;
using Data.Repository;
using Domain.Request;
using Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class GroupService : IGroupUseCase
    {
        private readonly IGroupRepository _groupRepository;
        public GroupService(IGroupRepository groupRepository){
            _groupRepository = groupRepository;
        }
        public void AddGroupes(AddGroupRequest addGroupRequest)
        {
            _groupRepository.AddGroup(new Groups { Name = addGroupRequest.Name });
        }

        public void AddGroupWithStudents(AddGroupWithStudentRequest addGroupWithStudent)
        {
            Groups groups = new Groups { Name = addGroupWithStudent.addGroupRequest.Name };
            List<Students> students = addGroupWithStudent
                .AddStudentRequest
                .Select(it => new Students { Fio = it.StudentName })
                .ToList();
            _groupRepository.addGroupWithStudents(groups, students);
        }
    }
}
