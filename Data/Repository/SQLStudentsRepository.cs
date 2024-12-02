using Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SQLStudentsRepository : IStudentsRepository
    {
        private readonly RemoteDatabaseContext _dbContext;
        public SQLStudentsRepository(RemoteDatabaseContext remoteDatabaseContext)
        {
            _dbContext = remoteDatabaseContext;
        }
        public bool AddStudents(Students students)
        {
            try
            {
                students.IdGroup = _dbContext.Groupses.FirstOrDefault(g => g.Id == students.IdGroup.Id);
                _dbContext.Studentses.Add(students);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Students> getAllStudents()
        {
            return _dbContext.Studentses.ToList();
        }

        public bool RemoveStudents(int idS)
        {
            try
            {
                Students students = _dbContext.Studentses.FirstOrDefault(u => u.Id == idS);
                _dbContext.Studentses.Remove(students);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
