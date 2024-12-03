using Data.DAO;
using Data.Repository;
using Domain.Entity;
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
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public void AddGroupes(AddGroupRequest addGroupRequest)
        {
            _groupRepository.AddGroup(new Groups { Name = addGroupRequest.Name });
        }
        public void RemoveGroupes(RemoveGroupRequest removeGroupRequest)
        {
            _groupRepository.RemoveGroup(new Groups { Id = removeGroupRequest.Id });
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

        public void UpdateGroupes(int Id, UpdateGroupRequest updateGroupRequest)
        {
            _groupRepository.UpdateGroup(Id, new Groups() { Name = updateGroupRequest.Name });
        }

        public IEnumerable<GroupEntity> GetGroupsWithStudents()
        {
            return _groupRepository.GetAllGroup().Select(
                group => new GroupEntity
                {
                    Id = group.Id,
                    Name = group.Name,
                    Students = group.Students.Select(
                        user => new StudentEntity
                        {
                            Guid = user.Id,
                            Name = user.Fio,
                            Group = new GroupEntity
                            {
                                Id = group.Id,
                                Name = group.Name,
                            }
                        }).ToList()
                }).ToList();
        }

        public GroupEntity GetGroup(int Id)
        {
            Groups group = _groupRepository.GetGroup(Id);
            return new GroupEntity
            {
                Id = group.Id,
                Name = group.Name,
                Students = (IEnumerable<StudentEntity>)group.Students
                .Select(i => new StudentEntity { Guid = i.Id, Name = i.Fio })
            };
        }
    }
}
