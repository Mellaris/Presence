using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DAO;
using Data.Repository;
using Domain.Entity;
using Domain.Request;
using Domain.UseCase;

namespace Domain.Service
{
    public class StudentsService : IStudentsUseCase
    {
        private readonly IStudentsRepository _studentsRepository;
        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }
        public void AddStudents(AddStudentsRequest addStudentsRequest)
        {
            _studentsRepository.AddStudents(new Students { Fio = addStudentsRequest.Name, IdGroup = addStudentsRequest.GroupId });
        }

        public IEnumerable<StudentEntity> GetAllUsers()
        {
            return _studentsRepository.getAllStudents()
                  .Select(u => new StudentEntity { Guid = u.Id, Name = u.Fio, Group = new GroupEntity { Name = u.IdGroup.Name } })
                  .ToList();
        }

        public StudentEntity GetUser(int guid)
        {
            Students user = _studentsRepository.getStudent(guid);
            return new StudentEntity
            { Guid = user.Id, Name = user.Fio, Group 
            =  new GroupEntity { Name = user.IdGroup.Name } };
        }

        public void RemoveStudents(RemoveStudentsRequest removeStudentsRequest)
        {
            _studentsRepository.RemoveStudents(removeStudentsRequest.idS);
        }
    }
}
