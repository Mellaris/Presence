using Data.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SQLAttendanceRepository : IAttendanceRepository
    {
        private readonly RemoteDatabaseContext _dbContext;
        public SQLAttendanceRepository(RemoteDatabaseContext remoteDatabaseContext)
        {
            _dbContext = remoteDatabaseContext;
        }
        public bool AddAttendance(Attendance attendance)
        {
            attendance.IdStatus = _dbContext.Statuss.FirstOrDefault(status => status.Id == Convert.ToInt32(attendance.IdStatus));
            attendance.SubjectId = _dbContext.Subjectses.FirstOrDefault(sub => sub.Id == Convert.ToInt32(attendance.SubjectId));
            attendance.IdStudent = _dbContext.Studentses.FirstOrDefault(user => user.Id == Convert.ToInt32(attendance.IdStudent));  
            _dbContext.Attendances.Add(attendance);
            return _dbContext.SaveChanges() != 0;
        }

        public IEnumerable<Attendance> GetAllAttendance()
        {
            return _dbContext.Attendances
               .Include(p => p.IdStudent)
               .ThenInclude(p => p.IdGroup)
               .ThenInclude(p => p.GroupSubjects)
               .ThenInclude(p => p.SubjectId)
               .ThenInclude(p => p.GroupsSubject).ThenInclude(p => p.GroupId)
               .Include(p => p.IdStatus)
               .ToList();
        }

        public bool RemoveAllAttendance()
        {
            _dbContext.Attendances.RemoveRange(_dbContext.Attendances.ToList());
            return _dbContext.SaveChanges() != 0;
        }

        public bool RemoveAttendanceGroup(int Id)
        {
            _dbContext.Attendances.RemoveRange(_dbContext.Attendances.Where(p => p.IdStudent.IdGroup.Id == Id).ToList());
            return _dbContext.SaveChanges() != 0;
        }

        public bool UpdateAttendance(int Id, Attendance attendance)
        {
            Students students = _dbContext.Studentses.FirstOrDefault(students => students.Id == Convert.ToInt32(attendance.IdStudent));
            Subjects subject = _dbContext.Subjectses.FirstOrDefault(sb => sb.Id == Convert.ToInt32(attendance.SubjectId));
            Attendance attendance1 = _dbContext.Attendances.FirstOrDefault(p => p.IdStudent == students && p.SubjectId == subject);

            attendance1.IdStatus = _dbContext.Statuss.FirstOrDefault(status => status.Id == Id);

            return _dbContext.SaveChanges() != 0;
        }
    }
}
