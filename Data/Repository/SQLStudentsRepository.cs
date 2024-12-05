using Data.DAO;
using Microsoft.EntityFrameworkCore;
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

        public bool AddchangeUserGroup(int Id, int GroupId)
        {
            Students user = _dbContext.Studentses.FirstOrDefault(user => user.Id == Id);
            user.IdGroup = _dbContext.Groupses.FirstOrDefault(group => group.Id == GroupId);
            return _dbContext.SaveChanges() != 0;
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
            return _dbContext.Studentses
                .Include(u => u.Presences)
                .Include(u => u.IdGroup)
                .ToList();
        }

        public Students getStudent(int id)
        {
            return _dbContext.Studentses.Include(u => u.Presences).FirstOrDefault(u => u.Id == id);
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
