using Data.DAO;
using Domain.Entity;
using Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public interface IStudentsUseCase
    {
        public void AddStudents(AddStudentsRequest addStudentsRequest);
        public void RemoveStudents(RemoveStudentsRequest removeStudentsRequest);
        public IEnumerable<StudentEntity> GetAllUsers();
        public StudentEntity GetUser(int guid);
        public void AddChangeUsersGroup(AddChangeUsersGroupRequest users);
    }
}
