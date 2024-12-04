using Data.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SQLSubjectRepository : ISubjectRepository
    {
        private readonly RemoteDatabaseContext _dbContext;
        public SQLSubjectRepository(RemoteDatabaseContext remoteDatabaseContext)
        {
            _dbContext = remoteDatabaseContext;
        }

        public bool AddSubject(Subjects subject)
        {
            try
            {
                _dbContext.Subjectses.Add(subject);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveSubject(int Id)
        {
            Subjects subject = _dbContext.Subjectses.FirstOrDefault(s => s.Id == Id);
            _dbContext.Subjectses.Remove(subject);
            return _dbContext.SaveChanges() != 0;
        }

        public bool UpdateSubject(int Id, Subjects subject)
        {
            Subjects subject1 = _dbContext.Subjectses.FirstOrDefault(s => s.Id == Id);
            subject1.Name = subject.Name;
            return _dbContext.SaveChanges() != 0;
        }

        public IEnumerable<Subjects> GetAllSubject()
        {
            return _dbContext.Subjectses
                .Include(subject => subject.GroupsSubject)
                .ToList();
        }

        public Subjects GetSubject(int Id)
        {
            return _dbContext.Subjectses
                .Include(subject => subject.GroupsSubject)
                .FirstOrDefault(s => s.Id == Id);
        }
    }
}
