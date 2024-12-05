using Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SQLGroupSubjectRepository : IGroupSubjectRepository
    {
        private readonly RemoteDatabaseContext _dbContext;
        public SQLGroupSubjectRepository(RemoteDatabaseContext remoteDatabaseContext)
        {
            _dbContext = remoteDatabaseContext;
        }

        public bool AddGroupSubject(GroupsAndSubject groupSubject)
        {
            _dbContext.GroupsAndSubjects.Add(groupSubject);
            return _dbContext.SaveChanges() != 0;
        }

        public bool RemoveGroupSubject(GroupsAndSubject groupSubject)
        {
            GroupsAndSubject grSub = _dbContext.GroupsAndSubjects
              .FirstOrDefault(g => g.GroupId == groupSubject.GroupId && g.SubjectId == groupSubject.SubjectId);
            _dbContext.GroupsAndSubjects.Remove(groupSubject);
            return _dbContext.SaveChanges() != 0;
        }
    }
}
