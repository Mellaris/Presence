using Data.DAO;
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

        public IEnumerable<Groups> GetAllGroup()
        {
          return _dbContext.Groupses.ToList();
        }
    }
}
