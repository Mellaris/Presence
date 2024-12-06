using Data.DAO;
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
            attendance.
        }
    }
}
