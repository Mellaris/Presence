using Data.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SQLGroupRepository : IGroupRepository
    {
        private readonly RemoteDatabaseContext _dbContext;
        public SQLGroupRepository(RemoteDatabaseContext remoteDatabaseContext) {
            _dbContext = remoteDatabaseContext;
        }
        public bool AddGroup(Groups groups)
        {
            try
            {
                _dbContext.Groupses.Add(groups);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveGroup(Groups groups)
        {
            try
            {
                _dbContext.Groupses.Remove(groups);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateGroup(int Id, Groups groups)
        {
            try
            {
                Groups groups1 = _dbContext.Groupses.FirstOrDefault(g => g.Id == Id);
                groups1.Name = groups.Name;
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Groups> GetAllGroup()
        {
          return _dbContext.Groupses.Include(group => group.Students).ToList();
        }
        public Groups GetGroup(int Id)
        {
            return _dbContext.Groupses.Include(group => group.Students).FirstOrDefault(i => i.Id == Id);
        }

        public bool addGroupWithStudents(Groups groups, IEnumerable<Students> students)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                _dbContext.Groupses.Add(groups);
                _dbContext.SaveChanges();
                foreach(var item in students)
                {
                    item.IdGroup = groups;
                    _dbContext.Studentses.Add(item);
                }
                _dbContext.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception ex) 
            {
                transaction.Rollback();
            }
            return false;
        }


        
    }
}
