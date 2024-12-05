using Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IStudentsRepository
    {
        public IEnumerable<Students> getAllStudents();
        public Students getStudent(int id);
        public bool AddStudents(Students students);
        public bool RemoveStudents(int idS);
        public bool AddchangeUserGroup(int Id, int GroupId);
    }
}
