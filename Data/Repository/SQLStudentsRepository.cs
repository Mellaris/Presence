using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SQLStudentsRepository
    {
        private readonly RemoteDatabaseContext _dbContext;
        public SQLStudentsRepository(RemoteDatabaseContext remoteDatabaseContext)
        {
            _dbContext = remoteDatabaseContext;
        }
    }
}
